using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerHealth health;
    public PlayerMana mana;
    public PlayerStats stats;

    private void Awake()
    {
        if (movement == null)
            movement = GetComponent<PlayerMovement>();
        
        if (health == null)
            health = GetComponent<PlayerHealth>();

        if (mana == null)
            mana = GetComponent<PlayerMana>();
    }

    private void Start()
    {
        // 임시 코드
        stats.Reset(); // 게임 시작 시 플레이어 스탯 초기화
    }
}
