using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void AddExp(int exp)
    {
        int remaining = exp;

        // 획득한 경험치가 레벨 업에 필요한 경험치 이상이라면
        while (remaining >= GetRemainingExpForLevelUp())
        {
            remaining -= GetRemainingExpForLevelUp(); // 레벨 업에 사용하고 남은 경험치 갱신
            LevelUp(); // 레벨 업
        }

        player.stats.currentExp += remaining; // 경험치 획득
    }

    private void LevelUp()
    {
        player.stats.currentLevel += 1;
        player.stats.currentExp = 0;
        player.stats.maxExp = (int)(player.stats.maxExp * (1 + player.stats.expMultiplier / 100f));
    }

    private int GetRemainingExpForLevelUp()
    {
        return player.stats.maxExp - player.stats.currentExp;
    }

    // TEMP
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExp(50);
        }
    }
}
