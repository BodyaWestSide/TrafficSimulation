using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public enum TransitionType
{
    EndPoint,
    Transition
}

public abstract class Transition : MonoBehaviour
{
    public TransitionType Type;
    protected List<QueuePosition> QueuePositions;

    public QueuePosition Entrypoint { get; private set; }
    public QueuePosition Endpoint { get; private set; }

    [UsedImplicitly]
    private void Awake()
    {
        QueuePositions = GetComponentsInChildren<QueuePosition>().ToList();
        QueuePositions.Sort((p1, p2) => string.Compare(p1.name, p2.name, StringComparison.Ordinal));

        Entrypoint = QueuePositions.First();
        Endpoint = QueuePositions.Last();

        if(QueuePositions.Count < 1)
        {
            Debug.LogError("Invalid queue size");
        }
        else
        {
            BuildLink();    
        }
    }

    private void BuildLink()
    {
        var length = QueuePositions.Count;
        if(length > 1)
        {
            Entrypoint.Next = QueuePositions[1];
            Endpoint.Prev = QueuePositions[length - 2];
        }

        for(var i = 1; i < length - 1; i++)
        {
            QueuePositions[i].Prev = QueuePositions[i - 1];
            QueuePositions[i].Next = QueuePositions[i + 1];
        }
    }

    public bool HasPlace
    {
        get { return !Entrypoint.IsOccupied; }
    }

    public void Push(Car car)
    {
        Entrypoint.Push(car);
    }
}