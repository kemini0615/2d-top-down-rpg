using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [Header("Level")]
    [SerializeField] private TextMeshProUGUI levelText;

    [Header("Health Bar")]
    [SerializeField] private Image healthBarImage;
    [SerializeField] private TextMeshProUGUI healthBarText;

    [Header("Mana Bar")]
    [SerializeField] private Image manaBarImage;
    [SerializeField] private TextMeshProUGUI manaBarText;

    [Header("Experience Bar")]
    [SerializeField] private Image expBarImage;
    [SerializeField] private TextMeshProUGUI expBarText;

    private void Update()
    {
        UpdatePlayerStatusPanel();
    }

    private void UpdatePlayerStatusPanel()
    {
        // 레벨
        levelText.text = "Level: " + player.stats.currentLevel;

        // HP
        healthBarText.text = player.stats.currentHealth + " / " + player.stats.maxHealth;
        healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, player.stats.currentHealth / (float)player.stats.maxHealth, 10 * Time.deltaTime); // 두 값을 보간하여 UI의 변화를 스무스하게

        // MP
        manaBarText.text = player.stats.currentMana + " / " + player.stats.maxMana;
        manaBarImage.fillAmount = Mathf.Lerp(manaBarImage.fillAmount, player.stats.currentMana / (float)player.stats.maxMana, 10 * Time.deltaTime);

        // EXP
        expBarText.text = player.stats.currentExp + " / " + player.stats.maxExp;
        expBarImage.fillAmount = Mathf.Lerp(expBarImage.fillAmount, player.stats.currentExp / (float)player.stats.maxExp, 10 * Time.deltaTime);

    }
}
