using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class AddressablesLoader : SceneLoader
{
    [SerializeField] private Button _loadButton;

    private void OnEnable()
    {
        _loadButton.onClick.AddListener(LoadScene);
    }

    private void OnDisable()
    {
        _loadButton.onClick.RemoveListener(LoadScene);
    }

    protected override void LoadScene()
    {
        base.LoadScene();
        Addressables.LoadSceneAsync(_sceneKey);
    }
}