using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;
using System;
using System.IO;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using IronPython.Modules;
using System.Collections.Generic;
using Microsoft.Scripting.Hosting;
public class RobotEditor : MonoBehaviour {
    public Text input;
    public UnityEngine.Object robot;

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
            PyHelper.ImportAllRoot(python);
            //object threadWrapper = python.ConstructPyClass("ThreadWrapper", "ThreadWrapper", robot);
            python.Compile("from UnityEngine import *");
            python.Scope.SetVariable("robot", robot);
            //CompileBinder toCall = new CompileBinder(python, "robot = GameObject.Find('Robot').GetComponent[Robot]()\n", Microsoft.Scripting.SourceCodeKind.SingleStatement);
            //MainThread.Func func = toCall.execute;
            //MainThread.main.Run(func);

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
            if(results.Length > 0)
            {
                Debug.Log(results);
            } else
            {
                Debug.Log("<Empty python response>");
            }
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
