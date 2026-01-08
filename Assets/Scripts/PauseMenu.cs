using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameOverUI;
    private bool _isPaused;


    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape) || gameOverUI.activeSelf) return;
        if (_isPaused) Resume();
        else Pause();
    }
    
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}