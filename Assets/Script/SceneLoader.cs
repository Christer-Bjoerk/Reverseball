using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int sceneCount;
    private List<string> sceneList = new List<string>();

    private void Awake()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount; i++)
        {
            sceneList.Add(Path.GetFileNameWithoutExtension(
                          SceneUtility.GetScenePathByBuildIndex(i)));
        }
    }

    // Load scene by its name
    public void LoadScene(string sceneName)
    {
        for (int i = 0; i < sceneList.Count; i++)
        {
            if (sceneName == sceneList[i])
            {
                SceneManager.LoadScene(sceneName);
            }
            else if (sceneName != sceneList[i])
            {
                Debug.Log(sceneName + "is missing from the buildIndex or doesn't exist");
            }
        }
    }
}