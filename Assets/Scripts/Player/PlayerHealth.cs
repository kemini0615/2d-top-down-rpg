using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private Player player;

    private Animator animator;

    public bool IsDead { get; private set; } = false;

    private void Awake()
    {
        player = GetComponent<Player>();

        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        player.stats.currentHealth -= damage;

        // 체력이 0 이하가 되면
        if (player.stats.currentHealth <= 0)
        {
            player.stats.currentHealth = 0; // 체력을 0으로 설정
            Die(); // 플레이어 죽음
        }
    }

    private void Die()
    {
        IsDead = true;
        animator.SetTrigger("isDead");
    }

    // 임시 코드
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }
}
