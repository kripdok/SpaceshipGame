using UnityEngine;

public class StayInside : MonoBehaviour
{
    void Update()
    {
        Vector3 newPosition = transform.position;

        float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        float screenHalfHeight = Camera.main.orthographicSize;

        newPosition.x = Mathf.Clamp(newPosition.x, -screenHalfWidth, screenHalfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenHalfHeight, screenHalfHeight);

        transform.position = newPosition;
    }
}