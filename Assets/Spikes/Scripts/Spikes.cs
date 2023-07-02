using UnityEngine;

public class Spikes : MonoBehaviour, IStrokeReceive
{
    [SerializeField]
    private bool isActivated;
    [SerializeField]
    private GameObject activatedState;
    [SerializeField]
    private GameObject deactivatedState;

    private bool isPlayerStayOnSpikes;

    public void ChangeState(bool? state = null)
    {
        if (state.HasValue)
            isActivated = state.Value;
        else
            isActivated = !isActivated;

        activatedState.SetActive(isActivated);
        deactivatedState.SetActive(!isActivated);

        Debug.Log(isPlayerStayOnSpikes && isActivated);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
            isPlayerStayOnSpikes = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
            isPlayerStayOnSpikes = false;
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
