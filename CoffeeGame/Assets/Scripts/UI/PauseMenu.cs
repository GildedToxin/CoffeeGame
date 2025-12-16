using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button resume;
    public Button settings;
    public Button quit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        GameManager.Instance.TogglePause();
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
