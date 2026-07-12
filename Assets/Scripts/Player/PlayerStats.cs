using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "Scriptable Object/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;

    [Header("Mana")]
    public int currentMana;
    public int maxMana;

    [Header("Exp")]
    public int currentLevel;    // 현재 레벨
    public int currentExp;      // 현재 경험치
    public int maxExp;          // 레벨 업 경험치
    public int initialMaxExp;   // 레벨 업 경험치(레벨 1)
    [Range(1, 100)] public int expMultiplier;

    public void Reset()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        currentLevel = 1;
        currentExp = 0;
        maxExp = initialMaxExp;
    }
}
