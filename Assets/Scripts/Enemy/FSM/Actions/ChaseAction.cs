using UnityEngine;

public class ChaseAction : Action
{
    [SerializeField] private float chaseSpeed;
    private float minDistanceFromPlayer = 1.0f;

    private EnemyController enemyController;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public override void Act()
    {
        if (enemyController.PlayerTransform == null)
            return;

        // 플레이어를 추적하지만, 최소한의 거리(minDistanceFromPlayer)를 유지한다
        Vector3 deltaPosition = enemyController.PlayerTransform.position - transform.position;
        if (deltaPosition.magnitude >= minDistanceFromPlayer)
        {
            transform.Translate(deltaPosition.normalized * chaseSpeed * Time.deltaTime);
        }
    }
}
