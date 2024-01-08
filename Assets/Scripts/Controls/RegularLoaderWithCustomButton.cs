using UnityEngine;
using UnityEngine.SceneManagement;

public class RegularLoaderWithCustomButton : SceneLoader
{
    [SerializeField] private Object2DButton _button;

    private void OnEnable()
    {
        _button.OnObjectClicked += LoadScene;
    }

    private void OnDisable()
    {
        _button.OnObjectClicked -= LoadScene;
    }

    protected override void LoadScene()
    {
        base.LoadScene();
        SceneManager.LoadScene(_sceneKey);
    }
}