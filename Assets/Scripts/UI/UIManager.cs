using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _consumableButton;
    [SerializeField] private Button _nonConsumableButton;
    [SerializeField] private TextMeshProUGUI _gunText;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private PurchaseHandler _purchaseHandler;
    [SerializeField] private CoinsContainer _coinsContainer;

    private void OnEnable()
    {
        _consumableButton.onClick.AddListener(_purchaseHandler.BuyConsumable);
        _nonConsumableButton.onClick.AddListener(_purchaseHandler.BuyNonConsumable);
        _nonConsumableButton.onClick.AddListener(DisableButtonAfterBuy);
        _coinsContainer.OnCoinsAmountUpdated += UpdateCoinsText;
        _purchaseHandler.OnNonConsumableBought += UpdateGunText;
    }

    private void OnDisable()
    {
        _consumableButton.onClick.RemoveListener(_purchaseHandler.BuyConsumable);
        _nonConsumableButton.onClick.RemoveListener(_purchaseHandler.BuyNonConsumable);
        _nonConsumableButton.onClick.RemoveListener(DisableButtonAfterBuy);
        _coinsContainer.OnCoinsAmountUpdated -= UpdateCoinsText;
        _purchaseHandler.OnNonConsumableBought -= UpdateGunText;
    }

    private void DisableButtonAfterBuy()
    {
        _nonConsumableButton.enabled = false;
        var colors = _nonConsumableButton.colors;
        colors.normalColor = new Color(colors.normalColor.r, colors.normalColor.g, colors.normalColor.b, 0.5f);
        _nonConsumableButton.colors = colors;
    }

    private void UpdateGunText()
    {
        _gunText.text = "Gun obtained";
    }

    private void UpdateCoinsText(int amount)
    {
        _coinsText.text = $"Coins: {amount}";
    }
}