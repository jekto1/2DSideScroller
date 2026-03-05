using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public enum TypeTag
{
    Player,
    Trap,
    Checkpoint,
    Finish,
    Trigger,
}
public class TriggerEvent : MonoBehaviour
{
    public TypeTag targetTag;
    public UnityEvent<GameObject> OnTrigger;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == targetTag.ToString())
        {
            //Debug.Log(gameObject.tag + " Kena! " + col.gameObject.tag);
            OnTrigger?.Invoke(col.gameObject);
        }
    }

}