using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PythonScript))]
public class PythonScriptEditor : Editor
{
    bool showConfigurableValues = false;
    public override void OnInspectorGUI()
    {
        PythonScript myTarget = (PythonScript)target;
        myTarget.pythonClass = EditorGUILayout.TextField("Python Class Name", myTarget.pythonClass);

        ConfigurableValue prev = null;
        for(int i = 0; i < myTarget.keyValues.Length; ++i)
        {
            if(myTarget.keyValues[i] == null || myTarget.keyValues[i] == prev)
            {
                myTarget.keyValues[i] = new ConfigurableValue();
            }
            prev = myTarget.keyValues[i];
        }

        showConfigurableValues = EditorGUILayout.Foldout(showConfigurableValues, "Configurable Values");
        if(showConfigurableValues)
        {
            myTarget.keyValuesLength = SafeIntField("Size", myTarget.keyValuesLength);
            EditorGUI.indentLevel++;
            for (int i = 0; i < myTarget.keyValues.Length; ++i)
            {
                drawConfigurableValue(myTarget.keyValues[i]);
            }
            EditorGUI.indentLevel--;
        }
        //DrawDefaultInspector();
    }
    public void drawConfigurableValue(ConfigurableValue myTarget)
    {
        try
        {
            myTarget.name = EditorGUILayout.TextField("Name", myTarget.name);
        }
        catch (System.ArgumentException)
        {
            return;
        }
        myTarget.type = (ConfigurableValue.ConfigurableValueType)EditorGUILayout.EnumPopup("Type", myTarget.type);
        if (myTarget.type == ConfigurableValue.ConfigurableValueType.Int)
        {
            myTarget.valueInt = EditorGUILayout.IntField("Value", myTarget.valueInt);
        }
        else if (myTarget.type == ConfigurableValue.ConfigurableValueType.Float)
        {
            myTarget.valueFloat = EditorGUILayout.FloatField("Value", myTarget.valueFloat);
        }
        else if (myTarget.type == ConfigurableValue.ConfigurableValueType.Vector3)
        {
            myTarget.valueVector3 = EditorGUILayout.Vector3Field("Value", myTarget.valueVector3);
        }
        else if (myTarget.type == ConfigurableValue.ConfigurableValueType.Color)
        {
            myTarget.valueColor = EditorGUILayout.ColorField("Value", myTarget.valueColor);
        }
        else if (myTarget.type == ConfigurableValue.ConfigurableValueType.Object)
        {
            myTarget.valueObject = EditorGUILayout.ObjectField("Value", myTarget.valueObject, typeof(Object), true);
        }
    }


    public static string s_EditedValue = string.Empty;
    public static string s_LastTooltip = string.Empty;
    public static int s_EditedField = 0;

    /// <summary>
    /// Creates an special IntField that only chages th actual value when pressing enter or losing focus
    /// </summary>
    /// <param name="label">The label of the int field</param>
    /// <param name="value">The value of the intfield</param>
    /// <returns>The valuefo the intfield</returns>
    public static int SafeIntField(string label, int value)
    {
        // Get current control id
        int controlID = GUIUtility.GetControlID(FocusType.Passive);

        // Assign real value if out of focus or enter pressed,
        // the edited value cannot be empty and the tooltip must match to the current control
        if ((controlID.ToString() == s_LastTooltip || s_EditedValue != string.Empty) &&
            ((Event.current.Equals(Event.KeyboardEvent("[enter]")) || Event.current.Equals(Event.KeyboardEvent("return")) || Event.current.Equals(Event.KeyboardEvent("tab")) || (Event.current.type == EventType.MouseDown))))

        {
            // Draw textfield, somehow this makes it work better when pressing enter
            // No idea why...
            EditorGUILayout.BeginHorizontal();
            s_EditedValue = EditorGUILayout.TextField(new GUIContent(label, controlID.ToString()), s_EditedValue, EditorStyles.numberField);
            EditorGUILayout.EndHorizontal();

            // Parse number
            int number = 0;
            if (int.TryParse(s_EditedValue, out number))
            {
                value = number;
            }

            // Reset values, the edite value must go bak to its orginal state
            s_EditedValue = value.ToString();
            s_EditedField = 0;
            return value;
        }
    else
    {
            // Only draw this if the field is not being edited
            if (s_EditedField != controlID)
            {
                // Draw textfield with current original value
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.TextField(new GUIContent(label, controlID.ToString()), value.ToString(), EditorStyles.numberField);
                EditorGUILayout.EndHorizontal();

                // Save last tooltip if gets focus... also save control id
                if (GUI.tooltip == controlID.ToString())
                {
                    s_LastTooltip = GUI.tooltip;
                    s_EditedField = controlID;
                }
            }
            else
            {
                // Draw textfield, now with current edited value
                EditorGUILayout.BeginHorizontal();
                s_EditedValue = EditorGUILayout.TextField(new GUIContent(label, controlID.ToString()), s_EditedValue, EditorStyles.numberField);
                EditorGUILayout.EndHorizontal();
            }
        }

        return value;
    }

}