using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPos", menuName = "Scriptable Objects/PlayerPos")]
public class PlayerPos : ScriptableObject
{
    public Vector2 position;

    //panggil jika kena finish
    public void ResetData()
    {
        position = Vector2.zero;
    }
}
