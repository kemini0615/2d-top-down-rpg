using UnityEngine;

public class PatrolAction : Action
{
    [SerializeField] private float patrolSpeed;

    private Waypoint waypoint;
    private int wayPointIndex;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    public override void Act()
    {
        // 패트롤
        MoveTowardsWaypoint(); // 웨이포인트로 이동
        SetNextWaypointIfReached(); // 웨이포인트에 도달하면 다음 웨이포인트 설정
    }

    private void MoveTowardsWaypoint()
    {
        // MoveTowards 메소드는 목표 지점(target)과의 거리가 이번 프레임에 이동할 거리(maxDistanceDelta)보다 가까워졌을 때
        // 남은 거리가 이동 거리보다 작으면 target을 그대로 반환하는 내부 로직이 있어서, 정확히 target 위치에 도달한다
        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoint.CalcPointPosition(wayPointIndex),
            patrolSpeed * Time.deltaTime
        );
    }

    private void SetNextWaypointIfReached()
    {
        if (Vector3.Distance(transform.position, waypoint.CalcPointPosition(wayPointIndex)) <= 0.01f)
        {
            wayPointIndex++;
            wayPointIndex %= waypoint.Points.Length;
        }
    }
}
