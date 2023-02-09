using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MenuController : MonoBehaviour
{
    private string url = "https://testsafebrowsing.appspot.com/";

    public GameManagerScript gameManager;

    public void ClickButton()
    {
        StartCoroutine(GetWebRequest());
    }

    IEnumerator GetWebRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            gameManager.UpdateStatusText($"Status {www.error}");
        }
        else
        {
            // string responseContent = www.downloadHandler.text;
            gameManager.UpdateStatusText("Status: Suceeded!");
        }
    }
}
