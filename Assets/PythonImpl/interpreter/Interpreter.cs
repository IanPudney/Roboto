using System;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Text;
using System.Collections;
using IronPython.Hosting;
using IronPython.Modules;
using System.Collections.Generic;
using Microsoft.Scripting.Hosting;

    /// <summary>
    /// Interpreter for IronPython.
    /// </summary>
public class Interpreter
{
    static Stack<Foo.InterpreterFrame> interpreterStack = new Stack<Foo.InterpreterFrame>();
    public static Interpreter Current {
        get
        {
            if (interpreterStack.Count == 0) return null;
            return interpreterStack.Peek().interpreter;
        }
    }
    /// <summary>
    /// The scope.
    /// </summary>
    public ScriptScope Scope;

    /// <summary>
    /// The engine.
    /// </summary>
    public ScriptEngine Engine;

    /// <summary>
    /// The source.
    /// </summary>
    private ScriptSource Source;

    /// <summary>
    /// The compiled.
    /// </summary>
    private CompiledCode Compiled;

    /// <summary>
    /// The operation.
    /// </summary>
    private ObjectOperations Operation;

    /// <summary>
    /// The python class.
    /// </summary>
    private object PythonClass;
    MemoryStream stream;
    StreamWriter writer;
    /// <summary>
    /// Initializes a new instance of the <see cref="Interpreter"/> class.
    /// </summary>
    public Interpreter()
    {
        Engine = Python.CreateEngine();
        Scope = Engine.CreateScope();
        SetLibrary();
        stream = new MemoryStream();
        writer = new StreamWriter(stream);
        //Set IO Ouput of execution
        Engine.Runtime.IO.SetOutput(stream, writer);
        LoadRuntime();
        Operation = Engine.CreateOperations();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Interpreter"/> class.
    /// </summary>
    /// <param name="source">Source.</param>
    public Interpreter(string src) : this()
    {
        Compile(src);
    }

    /// <summary>
    /// Compile the specified src.
    /// </summary>
    /// <param name="src">Source.</param>
    public void Compile(string src, Microsoft.Scripting.SourceCodeKind CodeKind =
                                        Microsoft.Scripting.SourceCodeKind.SingleStatement)
    {
        if (src == string.Empty)
            return;
        

    Source = (CodeKind == Microsoft.Scripting.SourceCodeKind.File) ?
                            Engine.CreateScriptSourceFromFile(src) :
                            Engine.CreateScriptSourceFromString(src, CodeKind);

        ErrorHandle errors = new ErrorHandle();

        Compiled = Source.Compile(errors);
        if(errors.Message != null)
        {
            writer.Write(errors.Message);
            throw new Exception(errors.Message);
        }
        
        interpreterStack.Push(new Foo.InterpreterFrame(this));
        Compiled.Execute(Scope);
        interpreterStack.Pop();
    }

    public string GetOutput()
    {
        string output = FormatOutput(ReadFromStream(stream));
        return output;
    }

    /// <summary>
    /// Formats the output of execution
    /// </summary>
    /// <returns>The output.</returns>
    /// <param name="output">Output.</param>
    private string FormatOutput(string output)
    {
        return string.IsNullOrEmpty(output) ? string.Empty
        : string.Join("\n", output.Remove(output.Length - 1)
                                        .Split('\n')
                                        .Reverse().ToArray());
    }

    public void CompileToDll(string assemblyName, string[] filenames)
    {
        Scope.ImportModule("clr");
        object clr = Scope.GetVariable("clr");
        List<string> args = new List<string>(filenames);
        args.Insert(0, assemblyName + ".dll");
        Engine.Runtime.Operations.InvokeMember(clr, "CompileModules", args.ToArray());

    }
    
    /// <summary>
    /// Reads MemoryStream.
    /// </summary>
    /// <returns>The from stream.</returns>
    /// <param name="ms">Ms.</param>
    private string ReadFromStream(MemoryStream ms)
    {
        int length = (int)(ms.Length);
        Byte[] bytes = new Byte[ms.Length];
        ms.Seek(0, SeekOrigin.Begin);
        ms.Read(bytes, 0, length);
        ms.SetLength(0);

        return Encoding.GetEncoding("utf-8").GetString(bytes, 0, length);
    }

    /// <summary>
    /// Set sys paths
    /// </summary>
    private void SetLibrary()
    {
        if (PythonBase.SysPath.Count > 0)
        {

            ICollection<string> SysPath = Engine.GetSearchPaths();

            foreach (string path in PythonBase.SysPath)
                SysPath.Add(path);

            Engine.SetSearchPaths(SysPath);

        }
    }

    /// <summary>
    /// Load runtime Assemblies of Unity3D
    /// </summary>
    private void LoadRuntime()
    {
        System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (System.Reflection.Assembly assy in assemblies)
        {
            Engine.Runtime.LoadAssembly(assy);
        }
        Engine.Runtime.LoadAssembly(this.GetType().Assembly);
    }

    public void AddRuntime<T>()
    {
        Engine.Runtime.LoadAssembly(typeof(T).Assembly);
    }

    public void AddRuntime(Type type)
    {
        Engine.Runtime.LoadAssembly(type.Assembly);
    }

    /// <summary>
    /// Gets the variable or class
    /// </summary>
    /// <returns>The variable.</returns>
    /// <param name="name">Name.</param>
    public object GetVariable(string name)
    {
        return Operation.Invoke(Scope.GetVariable(name));
    }

    /// <summary>
    /// Calls the method.
    /// </summary>
    /// <param name="name">Name.</param>
    public void InvokeMethod(object nameClass, string Method, params object[] parameters)
    {
        object output = new object();
        if (Operation.TryGetMember(nameClass, Method, out output))
        {
            object Func = Operation.GetMember(nameClass, Method);
            Operation.Invoke(Func, parameters);
        }
    }

    public ScriptScope LoadPyModule(string module)
    {
        Scope.ImportModule(module);
        ScriptScope PyDll = Scope.GetVariable<ScriptScope>(module);
        return PyDll;
    }
    public object ConstructPyClass(string module, string classname, params object[] initargs) {
        ScriptScope PyDll = LoadPyModule(module);
        object Class = PyDll.GetVariable(classname);
        object ClassInstance = Engine.Operations.Invoke(Class, initargs);
        return ClassInstance;
    }
}

namespace Foo
{
    public class InterpreterFrame
    {
        public Interpreter interpreter;
        public InterpreterFrame(Interpreter i)
        {
            interpreter = i;
        }
    }
}