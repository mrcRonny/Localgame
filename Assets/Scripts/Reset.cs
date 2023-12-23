using TMPro;
using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour
{
    public Transform Ball; // Topun transform bileşeni
    public Transform Player1; // Mavi oyuncunun transform bileşeni
    public Transform Player2; // Kırmızı oyuncunun transform bileşeni

    public GameObject player1; // 1. Oyuncu karakteri
    public GameObject player2; // 2. Oyuncu karakteri
    public TextMeshProUGUI countdownText; // Geri sayım metni
    public float countdownTime = 3f; // Geri sayım süresi (saniye)
    PlayerController playerController1; // PlayerController1 scriptini temsil eden değişken
    PlayerController playerController2; // PlayerController1 scriptini temsil eden değişken
    public GameObject redLine;
    public GameObject blueLine;

    public AudioSource goalSound;

    public Animator anim;


    public void BaslangicPozisyonunaGetir()
    {
        // Topun hareketini durdur


        Ball = GameObject.Find("Ball").transform;
        Player1 = GameObject.Find("Player1").transform;
        Player2 = GameObject.Find("Player2").transform;

        Debug.Log("ResetOyun fonksiyonu çağrıldı.");

        //Rigidbody2D topRigidbody = Ball.GetComponent<Rigidbody2D>();
        //topRigidbody.velocity = Vector2.zero;

        //topRigidbody.simulated = false;

        redLine.SetActive(false);
        blueLine.SetActive(false);

        if (goalSound != null)
        {
            goalSound.Play();
        }

        // 3 saniye bekle
        Invoke("ResetOyun", 5f);
    }


    public void ResetOyun()
    {
        Debug.Log("ResetOyun fonksiyonu çağrıldı.");

        anim.SetTrigger("BackGoalAnim");

        Ball = GameObject.Find("Ball").transform;
        Player1 = GameObject.Find("Player1").transform;
        Player2 = GameObject.Find("Player2").transform;

        Rigidbody2D topRigidbody = Ball.GetComponent<Rigidbody2D>();
        topRigidbody.velocity = Vector2.zero;

        redLine.SetActive(true);
        blueLine.SetActive(true);

        // Topu, mavi oyuncuyu ve kırmızı oyuncuyu başlangıç pozisyonuna getir
        Ball.position = new Vector2(0, 0);
        Player1.position = new Vector2(-5, 0);
        Player2.position = new Vector2(5, 0);

        // Topun hareketsizliğini kaldır
        Ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        Ball.GetComponent<Rigidbody2D>().simulated = true;

        StartCoroutine(StartGameWithCountdown());
    }

    IEnumerator StartGameWithCountdown()
    {
        // Devre dışı bırakılacak PlayerController1 ve PlayerController2 script'lerini al
        playerController1 = player1.GetComponent<PlayerController>();
        playerController2 = player2.GetComponent<PlayerController>();

        countdownText.gameObject.SetActive(true);

        // PlayerController1 ve PlayerController2 script'leri varsa devre dışı bırak
        if (playerController1 != null)
        {
            playerController1.enabled = false;

        }

        if (playerController2 != null)
        {
            playerController2.enabled = false;

        }

        RemoveRigidbodyFromAIControllers();



        // Geri sayım
        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        // Geri sayım bitti, PlayerController1 ve PlayerController2 script'lerini etkinleştir
        if (playerController1 != null)
        {
            playerController1.enabled = true;
        }

        if (playerController2 != null)
        {
            playerController2.enabled = true;
        }

        EnableRigidbodyFromAIControllers();

        // Geri sayım metni görünmez hale getir
        countdownText.gameObject.SetActive(false);

    }

    void RemoveRigidbodyFromAIControllers()
    {
        AIController[] aiControllers = FindObjectsOfType<AIController>();
        foreach (AIController ai in aiControllers)
        {
            ai.DisableRigidbody2DFromAI(); // Rigidbody2D'yi etkisiz hale getirme fonksiyonunu çağır
        }
    }

    void EnableRigidbodyFromAIControllers()
    {
        AIController[] aiControllers = FindObjectsOfType<AIController>();
        foreach (AIController ai in aiControllers)
        {
            ai.EnableRigidbody2DFromAI(); // Rigidbody2D'yi etkisiz hale getirme fonksiyonunu çağır
        }
    }
}
