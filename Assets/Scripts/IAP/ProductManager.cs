using UnityEngine.Purchasing;

public class ProductManager
{
    private IStoreController _storeController;

    public ProductManager(IStoreController controller)
    {
        _storeController = controller;
    }

    public void BuyProduct(string id)
    {
        _storeController.InitiatePurchase(id);
    }
}