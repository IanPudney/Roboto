using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class RobotEditor : MonoBehaviour {
    public Text input;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Submit()
    {
        Thread t = new Thread(RunCommand);
        t.Start();
    }
    public void RunCommand()
    {
        string cmd = input.text; // todo: fix this race condition (input could change before thread runs)
        Interpreter python = new Interpreter();
        string results = "";
        try
        {
            python.Compile("from UnityEngine import *");
            PyHelper.ImportAllRoot(python);
            CompileBinder toCall = new CompileBinder(python, "robot = GameObject.Find('Robot').GetComponent[Robot]()\n", Microsoft.Scripting.SourceCodeKind.SingleStatement);
            MainThread.Func func = toCall.execute;
            MainThread.main.Run(func);
            python.Compile(cmd, Microsoft.Scripting.SourceCodeKind.Statements);
        }
        catch (System.Exception ex)
        {
            results += ex.ToString();
            throw ex;
        }
        finally
        {
            results += python.GetOutput();
            Debug.Log(results);
        }

    }
}
class CompileBinder
{
    public Interpreter python;
    public string source;
    public Microsoft.Scripting.SourceCodeKind kind;
    public CompileBinder(Interpreter python, string source, Microsoft.Scripting.SourceCodeKind kind)
    {
        this.python = python;
        this.source = source;
        this.kind = kind;
    }
    public void execute()
    {
        python.Compile(source, kind);
    }
}
