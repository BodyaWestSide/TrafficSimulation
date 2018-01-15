using UnityEngine;


public class TrafficSimulation : MonoBehaviour
{
    private CarGenerator generator;
    private Crossroad[] crossroads;
    private Road[] roads;

    public void GenerateSceneFromFile(string path)
    {
        
    }

    private void Awake()
    {
        generator = GetComponent<CarGenerator>();
        Invoke("Init", 2);
    }

    public void Init()
    {
        generator.Init();
    }

    public void Resume()
    {
        generator.Resume();
    }

    public void Stop()
    {
        generator.Stop();
    }

    public void Pause()
    {
        generator.Pause();
    }
}

internal class Road
{ }