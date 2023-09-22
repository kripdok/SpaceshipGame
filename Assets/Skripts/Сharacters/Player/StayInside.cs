using UnityEngine;

public class StayInside : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    void Update()
    {
        ChangePosition();
    }

    private void ChangePosition()
    {
        Vector3 newPosition = transform.position;

        float screenHalfWidth = _camera.orthographicSize * Screen.width / Screen.height;
        float screenHalfHeight = _camera.orthographicSize;

        newPosition.x = Mathf.Clamp(newPosition.x, -screenHalfWidth, screenHalfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenHalfHeight, screenHalfHeight);

        transform.position = newPosition;
    }
}