using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEventTrigger : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnter;
    public UnityEvent<GameObject> OnExit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)
        {
            OnEnter?.Invoke(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other != null)
        {
            OnExit?.Invoke(other.gameObject);
        }
    }



}
