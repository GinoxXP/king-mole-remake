using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour, IStrokeReceive
{
    [SerializeField]
    private bool isActivated;
    [SerializeField]
    private GameObject activatedState;
    [SerializeField]
    private GameObject deactivatedState;

    private ISpikesStep spikesStep;

    public bool IsActivated => isActivated;

    public void ChangeState(bool? state = null)
    {
        if (state.HasValue)
            isActivated = state.Value;
        else
            isActivated = !isActivated;

        activatedState.SetActive(isActivated);
        deactivatedState.SetActive(!isActivated);

        if (!isActivated || spikesStep == null)
            return;

        spikesStep.StepOnSpike();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ISpikesStep>(out var spikesStep))
            this.spikesStep = spikesStep;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ISpikesStep>(out var _))
            spikesStep = null;
    }

    private void Start()
    {
        activatedState.SetActive(isActivated);
        deactivatedState.SetActive(!isActivated);
    }

    public void OnStroke()
    {
        ChangeState();
    }
}
