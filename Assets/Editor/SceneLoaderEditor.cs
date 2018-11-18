using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(SceneLoader))]
public class SceneLoaderEditor : Editor {

    private ReorderableList playerList;
    private ReorderableList spawnableList;

    private void OnEnable()
    {
        SetPlayerList();
        SetSpawnableList();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        playerList.DoLayoutList();
        spawnableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    private void SetPlayerList()
    {
        playerList = new ReorderableList(serializedObject,
                serializedObject.FindProperty("playerPrefabs"),
                true, true, false, false);

        playerList.drawElementCallback =
            (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = playerList.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                    element, GUIContent.none);
            };

        playerList.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Player prefabs");
        };
    }

    private void SetSpawnableList()
    {
        spawnableList = new ReorderableList(serializedObject,
                serializedObject.FindProperty("spawnablePrefabs"),
                true, true, true, true);

        spawnableList.drawElementCallback =
            (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = spawnableList.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                    element, GUIContent.none);
            };

        spawnableList.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Spawnable prefabs");
        };
    }
}
