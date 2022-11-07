using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameEvent onDeleteSaveData;
    [SerializeField] private GameEvent loadScene;
    [SerializeField] private GameEvent gemCollected;

    [HideInInspector]
    public int reachedLevel { get; private set; } = 0;

    [SerializeField] private int totalLevels = 3;

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

        SetScreenOrientation();
    }

    private void SetScreenOrientation()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void UnlockNextLevel()
    {
        // Unlock the next level
        if (reachedLevel < totalLevels)
        {
            reachedLevel++;
            // Save progress
            PlayerPrefs.SetInt("reachedLevel", reachedLevel);
        }
        else if (reachedLevel >= totalLevels)
        {
            // Play credits if completed the last level
            loadScene.TriggerEvent();
        }
    }

    public void DeleteSaveData()
    {
        PlayerPrefs.SetInt("reachedLevel", 0);
        PlayerPrefs.SetInt("LvL 1", 0);

        reachedLevel = PlayerPrefs.GetInt("reachedLevel", 0);
        onDeleteSaveData.TriggerEvent();
    }
}