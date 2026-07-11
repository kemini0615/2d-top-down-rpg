using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "Scriptable Object/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int level;

    public int currentHealth;
    public int maxHealth;
}
