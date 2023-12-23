using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
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
        Invoke("ChangeScene", 0);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
