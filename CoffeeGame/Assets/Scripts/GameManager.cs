using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerHUD hud;
    public PlayerController player;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterPlayer(PlayerController player)
    {
        this.player = player;
        hud.SetPlayer(player);
    }
}
