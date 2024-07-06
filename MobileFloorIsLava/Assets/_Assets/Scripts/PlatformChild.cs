using UnityEngine;

public class PlatformChild : MonoBehaviour
{
    private GameObject objectToAttach;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToAttach = collision.gameObject;
            objectToAttach.transform.SetParent(transform);
        }
    }
    private void Start()
    {
        //objectToAttach = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToAttach = collision.gameObject;
            objectToAttach.transform.parent = null;
        }
    }
}