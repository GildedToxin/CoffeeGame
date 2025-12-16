using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    private PlayerController player;
    public GameObject HealthBar;

    void Start()
    {
        HealthBar.GetComponent<UnityEngine.UI.Slider>().value = 1;
        player.OnHealthChanged += UpdateHealth;
    }

    void UpdateHealth(float current, float max)
    {
        HealthBar.GetComponent<UnityEngine.UI.Slider>().value = current / max;
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
