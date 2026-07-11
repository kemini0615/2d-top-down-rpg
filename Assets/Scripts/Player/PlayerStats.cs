using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "Scriptable Object/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int level;

    [Header("Health")]
    public int currentHealth;
    public int maxHealth;

    [Header("Mana")]
    public int currentMana;
    public int maxMana;

    public void Reset()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }
}
