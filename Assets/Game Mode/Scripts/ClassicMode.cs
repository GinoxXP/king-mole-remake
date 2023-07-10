using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ClassicMode : MonoBehaviour
{
    private IStrokeReceive[] strokeReceivers;
    private List<IVictoryCondition> victoryConditions;

    private Player player;
    private LoadScene loadScene;

    [SerializeField]
    private int maxStrokes;

    private int strokes;

    public int Strokes { get; private set; }

    public event Action StrokesChanged;

    public event Action StrokeCompleated;

    private void OnStrokeCompleated()
    {
        foreach (var iStrokeReceiver in strokeReceivers)
            iStrokeReceiver.OnStroke();

        if (Strokes <= 0)
        {
            loadScene.Reload();
            player.IsCanMove = false;
        }        
        
        StrokeCompleated?.Invoke();
    }

    private void OnVictoryConditionMet(IVictoryCondition victoryCondition)
    {
        victoryCondition.ConditionMet -= OnVictoryConditionMet;
        victoryConditions.Remove(victoryCondition);

        if(victoryConditions.Count == 0)
        {
            loadScene.Load();
            player.IsCanMove = false;
        }
    }

    private void OnDestroy()
    {
        player.StrokeCompleated -= OnStrokeCompleated;

        foreach (var condition in victoryConditions)
            condition.ConditionMet -= OnVictoryConditionMet;
    }

    private void Start()
    {
        strokeReceivers = FindObjectsOfType<MonoBehaviour>(true).OfType<IStrokeReceive>().ToArray();
        victoryConditions = FindObjectsOfType<MonoBehaviour>(true).OfType<IVictoryCondition>().ToList();

        foreach (var condition in victoryConditions)
            condition.ConditionMet += OnVictoryConditionMet;
    }

    [Inject]
    private void Init(Player player, LoadScene loadScene)
    {
        this.player = player;
        this.loadScene = loadScene;

        Strokes = maxStrokes;

        player.StrokeCompleated += OnStrokeCompleated;
    }
}
