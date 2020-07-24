using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace HamiUnityObserver.Editor
{
    public class EventNames : EditorWindow
    {
        private List<string> events;
        private string basePath;
        private string path;
        private Vector2 scrollPos = Vector2.zero;

        private void Awake()
        {
            basePath = $"{Directory.GetCurrentDirectory()}\\..\\Resource\\HamiObserver\\";
            path = $"{basePath}HamiUnityObserver_events.json";
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            try
            {
                if (File.Exists(path)) events = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(path));
                else events = new List<string>();
            }
            catch (Exception e)
            {
                MonoBehaviour.print(e);
                events = new List<string>();
            }
        }

        [MenuItem("Hami/HamiObserver/EventNames")]
        private static void ShowWindow()
        {
            var window = GetWindow<EventNames>();
            window.titleContent = new GUIContent("HamiObserver Event Names");
            window.Show();
        }

        private void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            for (int i = 0; i < events.Count; i++)
            {
                GUILayout.BeginHorizontal();
                events[i] = EditorGUILayout.TextField(events[i]);
                if (GUILayout.Button("Delete")) events.RemoveAt(i);
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(10);
            if (GUILayout.Button("Add Element"))
                events.Add("ENTER EVENT NAME HERE!");

            GUILayout.Space(10);
            if (GUILayout.Button("Apply"))
                OnDestroy();
            
            EditorGUILayout.EndScrollView();
        }

        private void OnDestroy()
        {
            events = events.Distinct().ToList();
            File.WriteAllText($"{path}", JsonConvert.SerializeObject(events,Formatting.Indented));
            File.WriteAllText($"{basePath}HamiObserverEvents.cs", GetConstantClassStructure("HamiObserverEvents"));
        }

        private string GetConstantClassStructure(string className)
        {
            string result = $"public static class {className} {{\n";
            foreach (string s in events)
            {
                string[] varName = s.Split(' ');
                for (int i = 0; i < varName.Length; i++) varName[i] = varName[i].ToUpper();
                result += $"\tpublic const string __{string.Join("_", varName)} = \"{s}\";\n";
            }

            return result + "}";
        }
    }
}