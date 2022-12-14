using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // IMPORTANT, the buttons needs to be sorted in numeric order for it to work
    [SerializeField] private List<Button> levelButtons = new List<Button>();

    private void Start()
    {
        AvailableLevels();
    }
    public void AvailableLevels()
    {
        // Only highlight levels the player has unlocked
        for (int i = 0; i < levelButtons.Count; i++)
        {
            if (i > GameManager.instance.reachedLevel)
                // Else the levels are non interactable
                levelButtons[i].interactable = false;
        }
    }
}