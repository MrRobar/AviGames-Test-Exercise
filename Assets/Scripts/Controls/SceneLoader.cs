using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneLoader : MonoBehaviour
{
    [SerializeField] protected string _sceneKey;

    protected virtual void LoadScene()
    {
        AnalyticsService.Instance.CustomData("LevelPassed", new Dictionary<string, object>
        {
            { "Level", SceneManager.GetActiveScene() },
        });
    }
}