using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStartAnalytics : MonoBehaviour
{
    private void Start()
    {
        AnalyticsService.Instance.CustomData("LevelStarted", new Dictionary<string, object>()
        {
            { "Level", SceneManager.GetActiveScene()},
        });
    }
}