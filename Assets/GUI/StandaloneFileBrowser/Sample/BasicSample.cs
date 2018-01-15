using System.Collections;
using UnityEngine;
using SFB;

public class BasicSample : MonoBehaviour {
    private string _path;

    void OnGUI() {
        var guiScale = new Vector3(Screen.width / 1920.0f, Screen.height / 1080.0f, 1.0f);
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, guiScale);

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginVertical();

        if (GUILayout.Button("Open File")) {
            WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Start")) {
            //TrafficSimulation.Init();
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Pause")) {
            //TrafficSimulation.Pause();
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Resume")) {
            //TrafficSimulation.Resume();
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Stop")) {
            //TrafficSimulation.Stop();
        }
        

        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.Label(_path);
        GUILayout.EndHorizontal();
    }

    public void WriteResult(string[] paths) {
        if (paths.Length == 0) {
            return;
        }

        _path = "";
        foreach (var p in paths) {
            _path += p + "\n";
        }
    }

    public void WriteResult(string path) {
        _path = path;
    }
}
