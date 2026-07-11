using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private Player player;

    public bool IsDead => player.stats.currentHealth <= 0;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void TakeDamage(int damage)
    {
        player.stats.currentHealth -= damage;

        // 체력이 0 이하가 되면
        if (IsDead)
        {
            player.stats.currentHealth = 0; // 체력을 0으로 설정
            Die(); // 플레이어 죽음
        }
    }

    private void Die()
    {
        player.animator.SetTrigger("die");
    }

    public void Revive()
    {
        player.stats.Reset();
        player.animator.SetTrigger("revive");
    }

    // TEMP
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }
}
