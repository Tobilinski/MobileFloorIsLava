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
    
}
