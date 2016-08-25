using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

class PythonBuilder : AssetPostprocessor
{
    static Interpreter python = new Interpreter();
    static HashSet<string> pyFiles = new HashSet<string>();
    static PythonBuilder()
    {
        pyFiles = GetAssetsOfType(".py");
    }
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        bool changed = false;
        foreach (string str in importedAssets)
        {
            if (str.EndsWith(".py"))
            {
                pyFiles.Add(str);
                changed = true;
            }
        }
        foreach (string str in deletedAssets)
        {
            if (str.EndsWith(".py"))
            {
                pyFiles.Remove(str);
                changed = true;
            }
        }

        for (int i = 0; i < movedAssets.Length; i++)
        {
            pyFiles.Remove(movedFromAssetPaths[i]);
            pyFiles.Add(movedAssets[i]);
            changed = true;
        }
        if(changed)
        {
            string[] pyFilesArr = new string[pyFiles.Count];
            int i = 0;
            foreach (string s in pyFiles)
            {
                pyFilesArr[i] = s;
                i++;
            }
            
            python.CompileToDll("Assets/Python", pyFilesArr);
        }
    }

    /// <summary>
    /// Used to get paths to assets of a certain file extension from entire project
    /// </summary>
    /// <param name="fileExtension">The file extention the type uses eg ".prefab".</param>
    /// <returns>An Object array of assets.</returns>
    public static HashSet<string> GetAssetsOfType(string fileExtension)
    {
        HashSet<string> tempObjects = new HashSet<string>();
        DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
        FileInfo[] goFileInfo = directory.GetFiles("*" + fileExtension, SearchOption.AllDirectories);

        int i = 0; int goFileInfoLength = goFileInfo.Length;
        FileInfo tempGoFileInfo; string tempFilePath;
        for (; i < goFileInfoLength; i++)
        {
            tempGoFileInfo = goFileInfo[i];
            if (tempGoFileInfo == null)
                continue;

            tempFilePath = tempGoFileInfo.FullName;
            tempFilePath = tempFilePath.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
            tempObjects.Add(tempFilePath);
        }

        return tempObjects;
    }
}