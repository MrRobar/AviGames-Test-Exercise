using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        AnalyticsService.Instance.CustomData("LevelStarted", new Dictionary<string, object>
        {
            { "userLevel", 54 },
        });
    }
}