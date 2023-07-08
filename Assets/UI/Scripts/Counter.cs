using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class Counter : MonoBehaviour
{
    private ClassicMode classicMode;

    private TMP_Text counter;

    private void OnStrokeStarted(int strokes)
        => counter.text = strokes.ToString();

    private void Start()
    {
        counter = GetComponent<TMP_Text>();
    }

    private void OnDestroy()
    {
        classicMode.StrokeStarted -= OnStrokeStarted;
    }

    [Inject]
    private void Init(ClassicMode classicMode)
    {
        this.classicMode = classicMode;
        classicMode.StrokeStarted += OnStrokeStarted;
    }
}
