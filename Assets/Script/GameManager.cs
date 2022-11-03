using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int reachedLevel { get; private set; } = 0;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        // Get all unlocked levels at the start of each gaming session
        reachedLevel = PlayerPrefs.GetInt("reachedLevel", reachedLevel);
    }

    public void UnlockNextLevel()
    {
        reachedLevel++;
        PlayerPrefs.SetInt("reachedLevel", reachedLevel);
    }
}