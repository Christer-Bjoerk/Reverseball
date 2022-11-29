using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;

    private void Awake()
    {
        winText.gameObject.SetActive(false);
    }

    private void DisplayWinText()
    {
        winText.gameObject.SetActive(true);
        winText.text = "You won";
    }
}