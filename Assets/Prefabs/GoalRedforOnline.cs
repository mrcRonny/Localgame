using UnityEngine;

public class GoalRedforOnline : MonoBehaviour

{
    ScoreController scoreController;
    ResetforOnline resetPos;

    public Animator anim;

    void Start()
    {
        // ScoreController sınıfını bir GameObject üzerinden al
        scoreController = FindObjectOfType<ScoreController>();
        resetPos = FindObjectOfType<ResetforOnline>();

        if (scoreController == null)
        {
            Debug.LogError("ScoreController bulunamadı!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("top"))
        {
            Debug.Log("sensorRed, topa dokundu!");

            anim.SetTrigger("Goal Red");

            // Kırmızı skoru arttır
            if (scoreController != null)
            {
                scoreController.KirmiziSkoruArttir(1);
            }
            else
            {
                Debug.LogError("ScoreController bulunamadığı için skor arttırılamıyor!");
            }

            resetPos.BaslangicPozisyonunaGetir();
        }
    }
}
