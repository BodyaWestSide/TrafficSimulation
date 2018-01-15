using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;

public class UniformGenerator : MonoBehaviour, IGenerator
{
    public float MinSpawnTime;
    public float MaxSpawnTime;
    
    private readonly Random rnd = new Random();
    private float dT;

    [UsedImplicitly]
    private void Awake()
    {
        dT = MaxSpawnTime - MinSpawnTime;
    }

    public float Next() { return dT * (float)rnd.NextDouble() + MinSpawnTime; }
}