using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;

    private void Awake()
    {
        winText.gameObject.SetActive(false);
    }

    public void DisplayWinText()
    {
        winText.gameObject.SetActive(true);
        winText.text = "You won";
    }
}
