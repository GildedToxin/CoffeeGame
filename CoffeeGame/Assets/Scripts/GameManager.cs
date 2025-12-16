using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerHUD hud;
    public PlayerController player;

    public static bool IsPaused { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void RegisterPlayer(PlayerController player, PlayerInventory inventory)
    {
        this.player = player;
        hud.SetPlayer(player, inventory);
    }

    public void PauseGame()
    {
        IsPaused = true;
        print("paused");
    }
    public void UnpauseGame()
    {
        IsPaused = false;
    }
}
