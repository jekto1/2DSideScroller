using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    public Vector2 playerCurrentPosition;
    public Vector2 currentCheckpointPosition;

    #region Condition
    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
    }
    public void OnEnemy()
    {
        ChangePlayerPosition(currentCheckpointPosition);
    }

    public void OnFinish()
    {
        GameManager.Instance.ChangeLevel(1);
        GameManager.Instance.ChangeScene(0);
    }
    #endregion

    #region SaveLoad
    public PlayerPos playerPostitionData;
    private void LoadPosition()
    {
        transform.position = playerPostitionData.position;
    }

    private void SavePosition(Vector2 newPosition)
    {
        playerPostitionData.position = newPosition;
    }
    #endregion

    #region Instruction
    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
    #endregion
}
