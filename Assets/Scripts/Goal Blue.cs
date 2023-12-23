using TMPro;
using UnityEngine;

public class GoalBlue : MonoBehaviour

{
    ScoreController scoreController;
    Reset resetPos;

    public Animator anim;
    public TextMeshProUGUI animText;


    void Start()
    {
        // ScoreController sınıfını bir GameObject üzerinden al
        scoreController = FindObjectOfType<ScoreController>();
        resetPos = FindObjectOfType<Reset>();

        if (scoreController == null)
        {
            Debug.LogError("ScoreController bulunamadı!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("top"))
        {
            animText.text = "Blue Scored";

            Color maviRenk = new Color(0f, 0f, 1f);

            // Renk ayarla
            animText.color = maviRenk;

            Debug.Log("sensorRed, topa dokundu!");

            anim.SetTrigger("GoalAnim");

            // Kırmızı skoru arttır
            if (scoreController != null)
            {
                scoreController.MaviSkoruArttir(1);
            }
            else
            {
                Debug.LogError("ScoreController bulunamadığı için skor arttırılamıyor!");
            }

            if (resetPos != null)
            {
                resetPos.BaslangicPozisyonunaGetir();
            }
            else
            {
                Debug.LogError("Reset bulunamadığı için oyun resetlenemiyor!");
            }
        }
    }
}
