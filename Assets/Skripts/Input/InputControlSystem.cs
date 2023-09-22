using UnityEngine;

public class InputControlSystem : MonoBehaviour
{
    public InputActionControls Input { get; private set; }

    private void Awake()
    {
        Input = new InputActionControls();
    }
}