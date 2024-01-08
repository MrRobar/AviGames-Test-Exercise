using System;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class CoinsContainer : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private PurchaseHandler _purchaseHandler;
    public event Action<int> OnCoinsAmountUpdated;

    private void OnEnable()
    {
        _purchaseHandler.OnConsumableBought += UpdateAmount;
    }

    private void OnDisable()
    {
        _purchaseHandler.OnConsumableBought -= UpdateAmount;
    }

    private void UpdateAmount(int coins)
    {
        _coins += coins;
        OnCoinsAmountUpdated?.Invoke(_coins);
        AnalyticsService.Instance.CustomData("CoinsBought", new Dictionary<string, object>
        {
            { "Coins", coins },
        });
    }
}