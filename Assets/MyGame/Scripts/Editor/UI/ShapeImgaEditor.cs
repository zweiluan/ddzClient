using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
[CustomEditor(typeof(ShapeImage),true)]
public class ShapeImgaEditor : ImageEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ShapeImage img = (ShapeImage) target;
        SerializedProperty sp1 = serializedObject.FindProperty("offset1");
        EditorGUILayout.PropertyField(sp1, new GUIContent("offset1 偏移"));
        SerializedProperty sp2 = serializedObject.FindProperty("offset2");
        EditorGUILayout.PropertyField(sp2, new GUIContent("offset2 偏移"));
        SerializedProperty sp3 = serializedObject.FindProperty("offset3");
        EditorGUILayout.PropertyField(sp3, new GUIContent("offset3 偏移"));
        SerializedProperty sp4 = serializedObject.FindProperty("offset4");
        EditorGUILayout.PropertyField(sp4, new GUIContent("offset4 偏移"));
        serializedObject.ApplyModifiedProperties();
    }
}
