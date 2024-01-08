using System;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using Product = UnityEngine.Purchasing.Product;

public class PurchaseHandler : MonoBehaviour, IDetailedStoreListener
{
    [SerializeField] private string _consumableProductId;
    [SerializeField] private string _nonConsumableProductId;
    private ProductManager _productManager;
    private IStoreController _storeController;

    public event Action OnNonConsumableBought;
    public event Action<int> OnConsumableBought;

    private void Start()
    {
        InitializeBuilder();
    }

    private void InitializeBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(_consumableProductId, ProductType.Consumable);
        builder.AddProduct(_nonConsumableProductId, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyConsumable()
    {
        _productManager.BuyProduct(_consumableProductId);
    }

    public void BuyNonConsumable()
    {
        _productManager.BuyProduct(_nonConsumableProductId);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        OnInitializeFailed(error, null);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        var errorMessage = $"Purchasing failed to initialize. Reason: {error}.";

        if (message != null)
        {
            errorMessage += $" More details: {message}";
        }

        Debug.Log(errorMessage);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;
        Debug.Log($"Processing purchase: {product.definition.id}");
        if (product.definition.id == _consumableProductId)
        {
            OnConsumableBought?.Invoke(10);
            Debug.Log($"Bought {_consumableProductId}");
        }
        else if (product.definition.id == _nonConsumableProductId)
        {
            OnNonConsumableBought?.Invoke();
            AnalyticsService.Instance.CustomData("GunBought");
            Debug.Log($"Bought {_nonConsumableProductId}");
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Failed to purchase {product.definition.id}, reason: {failureReason}");
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;
        _productManager = new ProductManager(_storeController);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log($"Failed to purchase {product.definition.id}, description: {failureDescription}");
    }
}