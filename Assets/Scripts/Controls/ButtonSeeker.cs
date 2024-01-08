using UnityEngine;

public class ButtonSeeker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                var button = hit.collider.GetComponent<Object2DButton>();
                if (button != null)
                {
                    button.OnClick();
                }
            }
        }
    }
}