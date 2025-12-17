using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerHUD hud;
    public PauseMenu pauseMenu;
    public PlayerController player;
    public InputMode inputMode;
    public bool isUIOpen;

    public static bool IsPaused { get; private set; }


    void Awake()
    {
        Instance = this;
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        
    }
    void Start()
    {
        inputMode.OnDeviceChanged += UpdateDevice;
    }
    private void OnDestroy()
    {
        inputMode.OnDeviceChanged -= UpdateDevice;
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

        if (isUIOpen)
        {
            CloseUI();
        }
        if (IsPaused)
        {
            isUIOpen = true;
            EventSystem.current.SetSelectedGameObject(null); // clear old selection
            EventSystem.current.SetSelectedGameObject(pauseMenu.resume.gameObject);
        }
    }

    public void CloseUI()
    {
        if (!isUIOpen)
            return;

        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        isUIOpen = false;
    }
    public void UpdateDevice(InputModeType lastDevice, InputModeType currentDevice)
    {
        if (isUIOpen)
        {
            if(currentDevice != InputModeType.Mouse)
            {
                //Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                print("Mouse is showing");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}
