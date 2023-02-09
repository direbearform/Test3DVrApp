using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MenuController : MonoBehaviour
{
    private string url = "https://testsafebrowsing.appspot.com/";

    [SerializeField]
    private Text _status;

    public void ClickButton()
    {
        Debug.Log("Entering ClickButton ...");
        StartCoroutine(GetWebRequest());
    }

    public void UpdateStatusText(string text)
    {
        _status.text = text;
    }

    IEnumerator GetWebRequest()
    {
        Debug.Log("Entering GetWebRequest ...");
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        Debug.Log("Returning result ...");
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log($"Status {www.error}");
            UpdateStatusText($"Status {www.error}");
        }
        else
        {
            // string responseContent = www.downloadHandler.text;
            Debug.Log($"Status: Suceeded!");
            UpdateStatusText("Status: Suceeded!");
        }
    }
}
