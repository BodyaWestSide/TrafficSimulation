using System;
using System.Collections.Generic;
using UnityEngine;

public class OutTransition : Transition
{
    [Serializable]
    private class TurnProbability
    {
        public InTransition transition;
        public float probability;
    }

    [SerializeField] private List<TurnProbability> turns;

    public void SetTrafficLight()
    {
        
    }
}