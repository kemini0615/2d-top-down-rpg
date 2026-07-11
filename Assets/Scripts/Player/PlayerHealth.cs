using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStats playerStats;

    public void TakeDamage(int damage)
    {
        playerStats.currentHealth -= damage;

        // 체력이 0 이하가 되면
        if (playerStats.currentHealth <= 0)
        {
            playerStats.currentHealth = 0; // 체력을 0으로 설정
            Die(); // 플레이어 죽음
        }
    }

    private void Die()
    {
        Debug.Log("Player Died."); // 플레이어 죽음 로그 출력
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
