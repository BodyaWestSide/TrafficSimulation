using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;

[RequireComponent(typeof(Button))]
public class ButtonOpenFile : MonoBehaviour, IPointerDownHandler
{
    private readonly ExtensionFilter[] extensions = {
        new ExtensionFilter("JSON", "json"),
        new ExtensionFilter("All Files", "*" )
    };

    [SerializeField] private TrafficSimulation simulation;

    //
    // Standalone platforms & editor
    //
    public void OnPointerDown(PointerEventData eventData) { }

    [UsedImplicitly]
    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
        if (paths.Length > 1)
        {
            simulation.GenerateSceneFromFile(paths.First());
        }
    }
}