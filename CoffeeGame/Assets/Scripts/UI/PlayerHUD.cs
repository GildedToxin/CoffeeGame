using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player.OnHealthChanged += UpdateHealth;
    }

    void UpdateHealth(float current, float max)
    {
    }

    void OnDestroy()
    {
        player.OnHealthChanged -= UpdateHealth;
    }
    public void SetPlayer(PlayerController player)
    {
        this.player = player;
        player.OnHealthChanged += UpdateHealth;
    }
}
