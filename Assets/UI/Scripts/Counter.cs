using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class Counter : MonoBehaviour
{
    private ClassicMode classicMode;

    private TMP_Text counter;

    private void OnStrokesChanged()
        => counter.text = classicMode.Strokes.ToString();

    private void Start()
    {
        counter = GetComponent<TMP_Text>();
        classicMode.StrokesChanged += OnStrokesChanged;

        OnStrokesChanged();
    }

    private void OnDestroy()
    {
        classicMode.StrokesChanged -= OnStrokesChanged;
    }

    [Inject]
    private void Init(ClassicMode classicMode)
    {
        this.classicMode = classicMode;
    }
}
