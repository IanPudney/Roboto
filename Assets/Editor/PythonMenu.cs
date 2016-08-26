using UnityEngine;
using System.Collections;
using UnityEditor;

public class MenuItems
{
    [MenuItem("Python/Regenerate")]
    private static void RegeneratePython()
    {
        AssetDatabase.Refresh();
    }
}