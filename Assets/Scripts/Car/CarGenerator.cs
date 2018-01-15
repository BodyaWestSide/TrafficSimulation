using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

using Random = System.Random;

public class CarGenerator : MonoBehaviour
{
    public GameObject CarPrefab;
    public int MaterialId;
    public List<Material> MaterialPool;

    private Spawner[] spawners;
    private bool simulating;
    private readonly Random rnd = new Random();

    [UsedImplicitly]
    private void Awake() { spawners = FindObjectsOfType<Spawner>(); }

    public void Init()
    {
        simulating = true;
        foreach(var spawner in spawners)
        {
            StartCoroutine(SpawnerCoroutine(spawner));
        }
    }

    public void Resume()
    {
        Init();
    }

    public void Stop() { simulating = false; }

    public void Pause()
    {
        Stop();
    }

    private IEnumerator SpawnerCoroutine(Spawner spawner)
    {
        while(simulating)
        {
            yield return new WaitForSeconds(spawner.GetNextSpawnInterval());
            spawner.Spawn(CarPrefab, NextMaterial, MaterialId);
        }
    }

    private Material NextMaterial
    {
        get
        {
            return MaterialPool[rnd.Next(MaterialPool.Count)];
        }
    }
}