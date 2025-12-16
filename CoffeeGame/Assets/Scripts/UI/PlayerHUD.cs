using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    private PlayerController player;
    private PlayerInventory inventory;
    public GameObject HealthBar;
    public GameObject Money;

    void Start()
    {
        player.OnHealthChanged += UpdateHealth;
        inventory.OnMoneyChanged += UpdateMoney;
    }

    void UpdateHealth(float current, float max)
    {
        HealthBar.GetComponent<UnityEngine.UI.Slider>().value = current / max;
    }
    void UpdateMoney(int money)
    {
        Money.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText($"{money}");
    }

    void OnDestroy()
    {
        player.OnHealthChanged -= UpdateHealth;
        inventory.OnMoneyChanged -= UpdateMoney;
    }
    public void SetPlayer(PlayerController player, PlayerInventory inventory)
    {
        this.player = player;
        this.inventory = inventory;
        player.OnHealthChanged += UpdateHealth;
        inventory.OnMoneyChanged += UpdateMoney;
    }
}
