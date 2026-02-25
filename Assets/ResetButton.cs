using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public Transform target;
    public void ResetGame()
    {
        Time.timeScale = 1f;
        Vector3 targetPosition = new Vector3(-7.77f, -0.02f, 0f);
        target.position = targetPosition;
    }
}
