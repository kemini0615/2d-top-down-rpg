using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMana : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void useMana(int mana)
    {
        if (player.stats.currentMana >= mana)
        {
            player.stats.currentMana -= mana;
        }
        else
        {
            Debug.Log("Not enough mana!");
        }
    }

    // 임시 코드
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            useMana(1);
        }
    }
}
