using UnityEngine;

public class AttackPlayerDecision : Decision
{
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerMask;

    private EnemyController enemyController;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public override bool Decide()
    {
        return CanAttackPlayer();
    }

    private bool CanAttackPlayer()
    {
        if (enemyController.PlayerTransform == null)
            return false;

        Collider2D playerCollider = Physics2D.OverlapCircle(
            transform.position,
            attackRange,
            playerMask
        );

        return playerCollider != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
