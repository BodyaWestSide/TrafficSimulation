using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TrafficLightSwitch : MonoBehaviour
{
    public Dictionary<LightColor, TrafficLight> TrafficLights;
    public LightColor InitColor = LightColor.Default;

    private LightColor lightColor;
    private Dictionary<LightColor, LightColor> nextColors;

    [UsedImplicitly]
    private void Awake()
    {
        lightColor = InitColor;
        nextColors = new Dictionary<LightColor, LightColor>
        {
            { LightColor.Red, LightColor.Green },
            { LightColor.Green, LightColor.Yellow },
            { LightColor.Yellow, LightColor.Red }
        };

        TrafficLights = TrafficLights ?? DefaultTrafficLight;

        // TODO: remove
        Invoke("InitSimulation", 2);
    }

    public Dictionary<LightColor, TrafficLight> DefaultTrafficLight
    {
        get
        {
            return new Dictionary<LightColor, TrafficLight>
            {
                { LightColor.Red, gameObject.transform.Find("Red").GetComponent<TrafficLight>() },
                { LightColor.Yellow, gameObject.transform.Find("Yellow").GetComponent<TrafficLight>() },
                { LightColor.Green, gameObject.transform.Find("Green").GetComponent<TrafficLight>() }
            };
        }
    }

    public void InitSimulation()
    {
        StartCoroutine(TrafficLightCoroutine());
    }

    private IEnumerator TrafficLightCoroutine()
    {
        while (lightColor != LightColor.Default)
        {
            var trafficLight = TrafficLights[lightColor];
            trafficLight.Activate();

            // awaits previous light to finish
            yield return new WaitForSeconds(trafficLight.Duration);

            // switches to new colour
            lightColor = nextColors[lightColor];
        }
    }
}

public enum LightColor
{
    Default, Red, Yellow, Green 
}