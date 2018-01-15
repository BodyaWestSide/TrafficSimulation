using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public float Duration;
    public Material DefaultMaterial;
    public Material ActiveMaterial;

    private Renderer lightRenderer;

    [UsedImplicitly]
    private void Awake()
    {
        lightRenderer = GetComponent<Renderer>();

        ActiveMaterial = ActiveMaterial ?? lightRenderer.material;
        lightRenderer.material = DefaultMaterial;
    }

    public void Activate()
    {
        StartCoroutine(ActivateCoroutine());
    }

    private IEnumerator ActivateCoroutine()
    {
        lightRenderer.material = ActiveMaterial;
        yield return new WaitForSeconds(Duration);
        lightRenderer.material = DefaultMaterial;
    }
}