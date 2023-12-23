using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using Mirror;

public class StartFunctionsforOnline : NetworkBehaviour
{
    public GameObject player1; // 1. Oyuncu karakteri
    public GameObject player2; // 2. Oyuncu karakteri
    public TextMeshProUGUI countdownText; // Geri sayım metni
    public float countdownTime = 3f; // Geri sayım süresi (saniye)
    PlayerController playerController1; // PlayerController1 scriptini temsil eden değişken
    PlayerController playerController2; // PlayerController1 scriptini temsil eden değişken

    public void Start()
    {
        Invoke("StartAfter", 3f);
    }

    void StartAfter()
    {

        StartCoroutine(StartGameWithCountdown());
    }

    IEnumerator StartGameWithCountdown()
    {
        // Devre dışı bırakılacak PlayerController1 ve PlayerController2 script'lerini al
        playerController1 = player1.GetComponent<PlayerController>();
        playerController2 = player2.GetComponent<PlayerController>();

        // PlayerController1 ve PlayerController2 script'leri varsa devre dışı bırak
        if (playerController1 != null)
        {
            playerController1.enabled = false;

        }

        if (playerController2 != null)
        {
            playerController2.enabled = false;

        }

        RemoveRigidbodyFromAIControllers(); // Rigidbody2D'yi kaldırma fonksiyonunu çağır



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
