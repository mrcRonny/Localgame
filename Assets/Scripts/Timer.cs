using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    public float gameTime = 180f + 5f; // 3 dakika (180 saniye)
    public TextMeshProUGUI timerText; // Zamanı gösterecek metin alanı
    public Canvas newCanvas; // Yeni Canvas

    public TextMeshProUGUI scoreRed;
    public TextMeshProUGUI scoreBlue;

    private float currentTime;
    private bool isGamePaused = false;

    void Start()
    {
        currentTime = gameTime;
        UpdateTimerDisplay();
        StartCoroutine(StartGameTimer());
    }

    IEnumerator StartGameTimer()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);

            if (!isGamePaused)
            {
                currentTime--;
                UpdateTimerDisplay();
            }
        }

        // Zaman dolduğunda buraya gelinecek - istediğiniz olayları burada gerçekleştirebilirsiniz
        Debug.Log("Zaman Doldu!");

        PauseGameAndShowNewCanvas();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Timer'ı güncelleyin
        if (timerText != null)
        {
            timerText.text = timeString;
        }
    }

    void PauseGameAndShowNewCanvas()
    {
        Time.timeScale = 0f; // Oyunu duraklat

        RectTransform rectTransform = scoreRed.GetComponent<RectTransform>();

        rectTransform.localPosition = new Vector3(100, 100, 0);

        RectTransform rectTransform2 = scoreBlue.GetComponent<RectTransform>();

        rectTransform2.localPosition = new Vector3(-100, 100, 0);

        newCanvas.gameObject.SetActive(true); // Yeni Canvas'i etkinleştir

    }

}
