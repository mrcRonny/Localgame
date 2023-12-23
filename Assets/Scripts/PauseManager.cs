using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Pause menüsü oyun nesnesi

    private bool isPaused = false;

    public void PauseGame()
    {
        Time.timeScale = 0f; // Zamanı duraklat
        isPaused = true;
        pauseMenuUI.SetActive(true); // Pause menüsünü aktif et
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Zamanı devam ettir
        isPaused = false;
        pauseMenuUI.SetActive(false); // Pause menüsünü devre dışı bırak
    }

    public void RestartGame2Player()
    {
        Time.timeScale = 1f; // Zamanı devam ettir
        SceneManager.LoadScene("2playerGame"); // Ana menü sahnesini yükle
    }

    public void RestartGameAI()
    {
        Time.timeScale = 1f; // Zamanı devam ettir
        SceneManager.LoadScene("PlayAgainstAI"); // Ana menü sahnesini yükle
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Zamanı devam ettir
        SceneManager.LoadScene("StartScene"); // Ana menü sahnesini yükle
    }

    // Diğer pause menü işlevleri buraya eklenebilir
}
