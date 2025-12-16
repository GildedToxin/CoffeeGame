using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerHUD hud;
    public PauseMenu pauseMenu;
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
    public void TogglePause()
    {
        IsPaused = !IsPaused;

        player.canMove = !IsPaused;

        pauseMenu.gameObject.SetActive(IsPaused);
        if (IsPaused)
        {
            EventSystem.current.SetSelectedGameObject(null); // clear old selection
            EventSystem.current.SetSelectedGameObject(pauseMenu.resume.gameObject);
        }
    }
}
