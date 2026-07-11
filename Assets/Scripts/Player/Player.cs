using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerHealth health;
    public PlayerStats stats;

    private void Awake()
    {
        if (movement == null)
            movement = GetComponent<PlayerMovement>();
        
        if (health == null)
            health = GetComponent<PlayerHealth>();
    }
}
