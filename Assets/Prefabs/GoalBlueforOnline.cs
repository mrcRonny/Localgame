using UnityEngine;
using UnityEngine;

public class GoalBlueforOnline : MonoBehaviour

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
            Debug.Log("sensorBlue, topa dokundu!");

            anim.SetTrigger("Goal Blue");

            // Kırmızı skoru arttır
            if (scoreController != null)
            {
                scoreController.MaviSkoruArttir(1);
            }
            else
            {
                Debug.LogError("ScoreController bulunamadığı için skor arttırılamıyor!");
            }

            resetPos.BaslangicPozisyonunaGetir();
        }
    }
}
