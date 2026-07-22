using UnityEngine;

public class WanderAction : Action
{
    [SerializeField] private float wanderSpeed;
    [SerializeField] private float wanderDuration;
    [SerializeField] private Vector2 wanderRange;

    private Vector3 targetPosition;
    private float timer;

    private void Start()
    {
        SetRandomTargetPosition();
    }

    public override void Act()
    {
        // 주변 배회
        Wander();
    }

    private void Wander()
    {
        timer -= Time.deltaTime;
        Vector3 wanderDirection = (targetPosition - transform.position).normalized;

        if (Vector3.Distance(transform.position, targetPosition) >= 0.5f)
        {
            // Translate 메소드는 변위(displacement)를 인자로 받는다
            Vector3 deltaPosition = wanderDirection * wanderSpeed * Time.deltaTime;
            transform.Translate(deltaPosition); // TODO: 이동에 Transform 사용중
        }

        if (timer <= 0f)
        {
            SetRandomTargetPosition();
            timer = wanderDuration;
        }
    }

    private void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-wanderRange.x, wanderRange.x);
        float randomY = Random.Range(-wanderRange.y, wanderRange.y);
        targetPosition = transform.position + new Vector3(randomX, randomY, 0);
    }

    private void OnDrawGizmosSelected()
    {
        if (wanderRange == Vector2.zero)
            return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, wanderRange * 2f);
        Gizmos.DrawLine(transform.position, targetPosition);
    }
}
