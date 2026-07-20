using UnityEngine;

public class DetectPlayerDecision : Decision
{
    [SerializeField] private float detectRange;
    [SerializeField] private LayerMask playerMask;

    private EnemyController enemyController;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public override bool Decide()
    {
        return DetectPlayer();
    }

    private bool DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(
            transform.position,
            detectRange,
            playerMask
        );

        if (playerCollider != null)
        {
            enemyController.PlayerTransform = playerCollider.transform;
            return true;
        }
        else
        {
            enemyController.PlayerTransform = null;
            return false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
