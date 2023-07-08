using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class ClassicMode : MonoBehaviour
{
    private IStrokeReceive[] iStrokeReceivers;

    private Player player;
    private LoadScene loadScene;

    [SerializeField]
    private int maxStrokes;

    private int strokes;

    public event Action<int> StrokeStarted;

    public event Action<int> StrokeCompleated;

    private void OnStrokeStarted()
    {
        StrokeStarted?.Invoke(strokes);
    }

    private void OnStrokeCompleated()
    {
        foreach (var iStrokeReceiver in iStrokeReceivers)
            iStrokeReceiver.OnStroke();

        if (strokes <= 0)
        {
            loadScene.Reload();
            player.IsCanMove = false;
        }

        strokes--;

        StrokeCompleated?.Invoke(strokes);
    }

    private void OnDestroy()
    {
        player.StrokeCompleated -= OnStrokeCompleated;
    }

    private void Start()
    {
        strokes = maxStrokes;
        iStrokeReceivers = FindObjectsOfType<MonoBehaviour>(true).OfType<IStrokeReceive>().ToArray();
    }

    [Inject]
    private void Init(Player player, LoadScene loadScene)
    {
        this.player = player;
        this.loadScene = loadScene;

        player.StrokeStarted += OnStrokeStarted;
        player.StrokeCompleated += OnStrokeCompleated;
    }
}
