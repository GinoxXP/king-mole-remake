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

    public int Strokes { get; private set; }

    public event Action StrokeStarted;

    public event Action StrokeCompleated;

    private void OnStrokeStarted()
    {
        StrokeStarted?.Invoke();
    }

    private void OnStrokeCompleated()
    {
        foreach (var iStrokeReceiver in iStrokeReceivers)
            iStrokeReceiver.OnStroke();

        if (Strokes <= 0)
        {
            loadScene.Reload();
            player.IsCanMove = false;
        }

        Strokes--;

        StrokeCompleated?.Invoke();
    }

    private void OnDestroy()
    {
        player.StrokeCompleated -= OnStrokeCompleated;
    }

    private void Start()
    {
        iStrokeReceivers = FindObjectsOfType<MonoBehaviour>(true).OfType<IStrokeReceive>().ToArray();
    }

    [Inject]
    private void Init(Player player, LoadScene loadScene)
    {
        this.player = player;
        this.loadScene = loadScene;

        Strokes = maxStrokes;

        player.StrokeStarted += OnStrokeStarted;
        player.StrokeCompleated += OnStrokeCompleated;
    }
}
