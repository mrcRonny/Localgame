using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public StartFunctions startFunctions;

    public void LoadScene(int sceneID)
    {
        StartCoroutine(LoadScene_Coroutine(sceneID));

        startFunctions = new StartFunctions();
    }

    IEnumerator LoadScene_Coroutine(int sceneID)
    {
        // Asenkron sahne yükleme işlemini başlat
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        while (!operation.isDone)
        {
            // Yükleme işlemi tamamlanana kadar bekleyin
            yield return null;
        }
    }

}
