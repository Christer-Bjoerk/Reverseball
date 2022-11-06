using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameEvent onDeleteSaveData;

    [HideInInspector]
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

        Screen.autorotateToPortraitUpsideDown = true;

        Screen.orientation = ScreenOrientation.PortraitUpsideDown;
    }

    public void UnlockNextLevel()
    {
        reachedLevel++;
        PlayerPrefs.SetInt("reachedLevel", reachedLevel);
    }

    public void DeleteSaveData()
    {
        PlayerPrefs.SetInt("reachedLevel", 0);
        reachedLevel = PlayerPrefs.GetInt("reachedLevel", 0);

        onDeleteSaveData.TriggerEvent();
    }
}