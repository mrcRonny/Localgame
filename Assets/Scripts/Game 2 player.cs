using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game2player : MonoBehaviour
{
    public AudioSource audioSource;
    public Button yourButton;

    void Start()
    {
        yourButton.onClick.AddListener(ButtonClick);
    }

    public void ButtonClick()
    {
        // Ses efektini çal
        audioSource.Play();

        // Belirli bir süre bekleyip sonra sahneyi değiştir
        Invoke("ChangeScene", audioSource.clip.length);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("2playerGame");
    }
}
