using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public Transform target;
    public void ResetGame()
    {
        Time.timeScale = 1f; //lanjut game
        //Vector3 targetPosition = new Vector3(36f, -0.02f, 0f); //lokasi teleport
        //target.position = targetPosition; //teleport
        target.transform.eulerAngles = new Vector3(0, 0, 0); //balik lurus
    }
}
