using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CommandLine : MonoBehaviour
{
    public InputField input;
    public Text output; 
    public GameObject field;
    public Interpreter python;  
    public string[] defaultCommands;
    int commandHistoryCursor = 0;
    List<string> commandHistory = new List<string>();
    // Use this for initialization
    void Start()
    {
        field.SetActive(false);
        python = new Interpreter();

        foreach (string cmd in defaultCommands)
        {
            RunCommand(cmd);
        }
        //object c = python.ConstructPyClass("PythonClass", "PythonClass"); //some test code
        //python.Engine.Operations.InvokeMember(c, "test", new object[0]);
    }

    bool keyPushed = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Open Command Line") > 0)
        {
            if (keyPushed) return;
            keyPushed = true;
            if (field.activeSelf)
            {
                input.text = "";
                field.SetActive(false);

            }
            else
            {
                field.SetActive(true);
                Focus();
            }

        } else if (field.activeSelf && Input.GetAxis("Command Line Scroll Up") > 0)
        {
            if (keyPushed) return;
            keyPushed = true;
            commandHistoryCursor--;
            if(commandHistoryCursor == -1)
            {
                commandHistoryCursor = 0;
                return;
            }
            input.text = commandHistory[commandHistoryCursor];
        }
        else if (field.activeSelf && Input.GetAxis("Command Line Scroll Down") > 0)
        {
            if (keyPushed) return;
            keyPushed = true;
            commandHistoryCursor++;
            if (commandHistoryCursor > commandHistory.Count)
            {
                commandHistoryCursor = commandHistory.Count;
                return;
            } else if(commandHistoryCursor == commandHistory.Count)
            {
                input.text = "";
                return;
            }
            input.text = commandHistory[commandHistoryCursor];
        }
        else if (field.activeSelf && Input.GetAxis("Command Line Submit") > 0)
        {
            if (keyPushed) return;
            keyPushed = true;
            Submit();
        }
        else
        {
            keyPushed = false;
        }
    }

    public void Focus()
    {
        PointerEventData e = new PointerEventData(EventSystem.current);
        EventSystem.current.SetSelectedGameObject(input.gameObject, e);
        input.OnPointerClick(e);
    }

    public void Submit()
    {
        commandHistory.Add(input.text);
        commandHistoryCursor = commandHistory.Count;
        RunCommand(input.text);
        input.text = "";
        Focus();
    }
    public void RunCommand(string cmd)
    {
        output.text += cmd + "\n";
        string results = "";
        try
        {
            python.Compile(cmd, Microsoft.Scripting.SourceCodeKind.InteractiveCode);
        } catch (System.Exception ex)
        {
            results += ex.ToString();
            throw ex;
        } finally
        {
            results = python.GetOutput() + results;
            output.text += results + "\n";
            
        }

    }
        
}
