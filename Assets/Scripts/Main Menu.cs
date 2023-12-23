using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayAnimationOnButtonClick : MonoBehaviour
{
    public Animator anim; // Animator bileşeninin referansı
    public Button button;

    private void Start()
    {
        Debug.Log("Start1");
        // Animasyonun başlangıçta çalışmasını istemiyorsanız bu satırı kaldırabilirsiniz
        //anim.enabled = false;
    }


    void PlayAnimation()
    {
        Debug.Log("Animation Started");
        // Animasyonu çalıştır
        //anim.enabled = true;
        anim.SetTrigger("Bool"); // YourAnimationName, çalıştırmak istediğiniz animasyonun adı
        //button.enabled = false;
    }

    void PlayAnimation2()
    {
        Debug.Log("Animation Started");
        // Animasyonu çalıştır
        //anim.enabled = true;
        anim.SetTrigger("Bool2"); // YourAnimationName, çalıştırmak istediğiniz animasyonun adı
        //button.enabled = false;
    }


    public void Sender()
    {
        PlayAnimation();
    }

    public void Sender2()
    {
        PlayAnimation2();
    }
}