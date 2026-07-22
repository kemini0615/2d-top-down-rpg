using UnityEngine;

public class AttackAction : Action
{
    [SerializeField] private int damage;
    [SerializeField] private float cooldown;
    private float timer;

    private EnemyController enemyController;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public override void Act()
    {
        // 플레이어 공격
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (enemyController.PlayerTransform == null)
            return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            PlayerHealth playerHealth = enemyController.PlayerTransform.GetComponent<IDamageable>() as PlayerHealth;

            if (playerHealth.IsDead)
                return;

            playerHealth.TakeDamage(damage);
            timer = cooldown;
        }
    }

}
