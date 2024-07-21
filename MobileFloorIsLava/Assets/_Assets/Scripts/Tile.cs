using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour, IPlatformBehavior
{
    public void OnjumpDestroy()
    {
        StartCoroutine(DelayedDestroyer());
    }

    public IEnumerator DelayedDestroyer()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    public void KillOverlap()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        IPlatformBehavior interactable = other.gameObject.GetComponent<IPlatformBehavior>();
        if (interactable != null)
        {
            interactable.KillOverlap();
        }
    }
}
