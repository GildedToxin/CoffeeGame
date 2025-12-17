using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGame;
    public Button settings;
    public Button quit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null); // clear old selection
        EventSystem.current.SetSelectedGameObject(newGame.gameObject);
    }  
    public void StartNewGame()
    {
        GameManager.Instance.LoadScene("ProgrammingTestScene");
    }
    public void OpenSettings()
    {
        print("Settings Menu opened");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
