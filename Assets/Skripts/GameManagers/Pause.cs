using UnityEngine;

public class Pause : MonoBehaviour
{
    public void StopGameTime() 
    {
        Time.timeScale = 0;
    }

    public void StartGameTime()
    {
        Time.timeScale = 1f;
    }
}
