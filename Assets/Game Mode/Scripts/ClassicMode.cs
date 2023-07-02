using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ClassicMode : MonoBehaviour
{
    private IStrokeReceive[] iStrokeReceivers;

    private Player player;

    [SerializeField]
    private int maxStrokes;

    private int strokes;

    private void OnStrokeCompleated()
    {
        foreach (var iStrokeReceiver in iStrokeReceivers)
            iStrokeReceiver.OnStroke();

        if (strokes == 0)
            Debug.Log("Player death");

        strokes--;
        Debug.Log($"Strokes: {strokes}");
    }

    private void OnDestroy()
    {
        player.OnStroke -= OnStrokeCompleated;
    }

    private void Start()
    {
        strokes = maxStrokes;
        iStrokeReceivers = FindObjectsOfType<MonoBehaviour>(true).OfType<IStrokeReceive>().ToArray();
    }

    [Inject]
    private void Init(Player player)
    {
        this.player = player;
        player.OnStroke += OnStrokeCompleated;
    }
}
