using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour
{

    private Door[] doors;

    [SerializeField]
    private int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
        {
            foreach (var door in doors)
            {
                door.ChangeState(true);
            }

            Destroy(gameObject);
        }
    }

    private void Start()
    {
        doors = FindObjectsOfType<Door>(true).Where(x => x.ID == id).ToArray();
    }
}
