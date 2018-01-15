using JetBrains.Annotations;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transition spawnTransition;
    private IGenerator generator;

    [UsedImplicitly]
    private void Awake()
    {
        spawnTransition = GetComponentInParent<Transition>();
        generator = GetComponentInParent<IGenerator>();
    }
    
    public void Spawn(GameObject prefab, Material mat, int materialIndex)
    {
        if(spawnTransition.HasPlace)
        {
            var spawnTransform = spawnTransition.Entrypoint.transform;
            var car = Instantiate(prefab, spawnTransform.position, spawnTransform.rotation);
            SetMaterial(car, mat, materialIndex);

            spawnTransition.Push(car.GetComponent<Car>());    
        }
    }

    public float GetNextSpawnInterval() { return generator.Next(); }

    private static void SetMaterial(GameObject car, Material mat, int materialIndex)
    {
        var renderer = car.GetComponentInChildren<Renderer>();
        var mats = renderer.materials;
        mats[materialIndex] = mat;
        renderer.materials = mats;
    }
}