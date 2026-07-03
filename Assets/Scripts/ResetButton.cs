using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public Transform target;
    public void ResetGame()
    {
        Time.timeScale = 1f;
        target.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
