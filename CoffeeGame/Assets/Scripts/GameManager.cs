using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
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
        Cursor.visible = currentDevice == InputModeType.Controller ? false : true;
        pauseMenu.GetComponent<GraphicRaycaster>().enabled = currentDevice == InputModeType.Controller ? false : true;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
