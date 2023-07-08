using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class Counter : MonoBehaviour
{
    private ClassicMode classicMode;

    private TMP_Text counter;

    private void OnStrokeCompleated(int strokes)
        => counter.text = strokes.ToString();

    private void Start()
    {
        counter = GetComponent<TMP_Text>();
        classicMode.StrokeCompleated += OnStrokeCompleated;
    }

    private void OnDestroy()
    {
        classicMode.StrokeCompleated -= OnStrokeCompleated;
    }

    [Inject]
    private void Init(ClassicMode classicMode)
    {
        this.classicMode = classicMode;
    }
}
