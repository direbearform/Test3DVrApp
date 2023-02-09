using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private Text _status;

    public void UpdateStatusText(string text)
    {
        _status.text = text;
    }
}
