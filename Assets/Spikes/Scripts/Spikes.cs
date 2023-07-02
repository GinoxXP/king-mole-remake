using UnityEngine;
using Zenject;

public class Spikes : MonoBehaviour
{
    private ClassicMode classicMode;

    [SerializeField]
    private bool isActivated;
    [SerializeField]
    private GameObject activatedState;
    [SerializeField]
    private GameObject deactivatedState;

    private void OnDestroy()
    {
        classicMode.OnStroke -= OnStrokeCompleated;
    }

    private void Start()
    {
        activatedState.SetActive(isActivated);
        deactivatedState.SetActive(!isActivated);
    }

    [Inject]
    private void Init(ClassicMode classicMode)
    {
        this.classicMode = classicMode;
        classicMode.OnStroke += OnStrokeCompleated;
    }

    private void OnStrokeCompleated()
    {
        isActivated = !isActivated;

        activatedState.SetActive(isActivated);
        deactivatedState.SetActive(!isActivated);
    }
}
