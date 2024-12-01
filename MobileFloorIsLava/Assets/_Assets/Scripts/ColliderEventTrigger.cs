using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class ColliderEventTrigger : MonoBehaviour
{
    [SerializeField] private bool isOnGameManger = false;
    public UnityEvent<GameObject> OnEnter;
    public UnityEvent<GameObject> OnExit;
    public UnityEvent<GameObject> OnTriggerEnter;
    public UnityEvent<GameObject> OnTriggerExit;
    [HideIf("isOnGameManger")]
    public UnityEvent<GameObject> OnTriggerEnterPlatform;

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOnGameManger)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                OnTriggerEnterPlatform?.Invoke(other.gameObject);
            }
        }
        else if (other != null)
        {
            OnTriggerEnter?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            OnTriggerExit?.Invoke(other.gameObject);
        }
    }
}
