using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // 엔티티(에너미/NPC) 기준 상대 좌표(offset) 배열
    [SerializeField] private Vector3[] points;
    public Vector3[] Points => points;

    // 엔티티 현재 위치
    public Vector3 EntityPosition { get; set; }

    private bool gameStarted;

    private void Start()
    {
        EntityPosition = transform.position;
        gameStarted = true;
    }

    private void OnDrawGizmos()
    {
        if (!gameStarted)
        {
            EntityPosition = transform.position;
        }
    }
}
