using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Crossroad : RoadPart
{

    private OutTransition[] outTransitions;
    private InTransition[] inTransitions;

    [UsedImplicitly]
    private void Awake()
    {
        outTransitions = GetComponentsInChildren<OutTransition>();
        inTransitions = GetComponentsInChildren<InTransition>();
    }

    // TODO: Impelement traffic light switch behaviour
}

public abstract class RoadPart : MonoBehaviour
{
    
}