using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerHealth health;
    public PlayerMana mana;
    public PlayerStats stats;

    public Animator animator;

    private void Awake()
    {
        if (movement == null)
            movement = GetComponent<PlayerMovement>();
        
        if (health == null)
            health = GetComponent<PlayerHealth>();

        if (mana == null)
            mana = GetComponent<PlayerMana>();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    // TEMP
    private void Start()
    {
        stats.Reset(); // 게임 시작 시 플레이어 스탯 초기화
    }
}
