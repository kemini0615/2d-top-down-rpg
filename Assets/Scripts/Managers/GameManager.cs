using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Update()
    {
        // 플레이어 사망 시, R 키를 입력하면 부활
        if (player.health.IsDead && Input.GetKeyDown(KeyCode.R))
        {
            player.health.Revive();
        }
    }
}
