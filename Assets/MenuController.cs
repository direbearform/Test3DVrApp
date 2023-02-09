using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Security.Cryptography.X509Certificates;

class TestCertificateHandler : CertificateHandler
{
    private static string PUB_KEY="000410048135F5DB9CF071EFC931374A" +
            "FAD1AFF94D8EC133772683AEE6DE01E5" +
            "D4B8F44AD97BDFA06109EFAF289888E9" +
            "6FD0554F2CC3867FA8D37FD0388D7FAD" +
            "BADE";

    protected override bool ValidateCertificate(byte[] certificateData)
    {
        Debug.Log("Entering ValidateCertificate ...");
        X509Certificate2 certificate = new X509Certificate2(certificateData);

        string pk = certificate.GetPublicKeyString();
        Debug.Log($"Certificate is: {pk}");
        return pk.Equals(PUB_KEY);
    }
}

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

    public void ClickButton2()
    {
        Debug.Log("Entering ClickButton2 ...");
        StartCoroutine(GetWebRequestWithCertPinning());
    }


    public void UpdateStatusText(string text)
    {
        _status.text = text;
    }

    IEnumerator GetWebRequest()
    {
        Debug.Log("Entering GetWebRequest ...");
        using(var www = UnityWebRequest.Get(url))
        {
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

    IEnumerator GetWebRequestWithCertPinning()
    {
        Debug.Log("Entering GetWebRequestWithCertPinning ...");
        using(var www = UnityWebRequest.Get(url))
        {
            www.certificateHandler = new TestCertificateHandler();
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
}
