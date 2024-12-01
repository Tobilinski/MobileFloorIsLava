using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour, IPlatformBehavior
{
    private GameManager gameManager;
    private Vector3 positionPart;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void OnjumpDestroyAndAddScore()
    {
        StartCoroutine(DelayedDestroyer());
    }

    public IEnumerator DelayedDestroyer()
    {
        yield return new WaitForSeconds(2f);
        AddScore();
        
    }

    public void KillOverlap()
    {
        Destroy(this.gameObject);
    }

    public void AddScore()
    {
        UserManager.Instance.AddScoreToData();
    }
}
