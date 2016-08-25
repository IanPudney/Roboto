using UnityEngine;
using System.Collections;
using IronPython.Hosting;
using IronPython.Modules;
using System.Collections.Generic;
using Microsoft.Scripting.Hosting;
using System.Reflection;
using System.Linq;

//class defines functions useful for command line
static public class PyHelper  {
    //run a python script in the current scope
    public static void RunScript(string path)
    {
        Interpreter.Current.Compile(path, Microsoft.Scripting.SourceCodeKind.File);
    }
    //import all Unity scripts in the root namespace. 
    public static void ImportAllRoot()
    {
        foreach(System.Type typ in Assembly.GetExecutingAssembly().GetTypes())
        {
            if(typ.Namespace == null)
            {
                string importline = "try:\n import " + typ.Name+ ";\nexcept:\n pass;";
                Interpreter.Current.Compile(importline, Microsoft.Scripting.SourceCodeKind.Statements);
            }
        }
    }
}
