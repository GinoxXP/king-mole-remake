using System;
using UnityEngine;
using Zenject;

public class ClassicMode : MonoBehaviour
{
    private Player player;

    public event Action OnStroke;

    [SerializeField]
    private int maxStrokes;

    private int strokes;

    private void OnStrokeCompleated()
    {
        OnStroke?.Invoke();

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
    }

    [Inject]
    private void Init(Player player)
    {
        this.player = player;
        player.OnStroke += OnStrokeCompleated;
    }
}
