using UnityEngine;

public class Spikes : MonoBehaviour, IStrokeReceive
{
    [SerializeField]
    private bool isActivated;
    [SerializeField]
    private GameObject activatedState;
    [SerializeField]
    private GameObject deactivatedState;

    public void ChangeState(bool? state = null)
    {
        if (state.HasValue)
            isActivated = state.Value;
        else
            isActivated = !isActivated;

        activatedState.SetActive(isActivated);
        deactivatedState.SetActive(!isActivated);
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
