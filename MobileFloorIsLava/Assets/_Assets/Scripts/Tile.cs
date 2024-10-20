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
        positionPart.y += Random.Range(.5f, 1f);
        positionPart.x = Random.Range(-3.5f, 3.5f);
        transform.position = positionPart += gameManager.HighestPlatformPos;
        //Destroy(this.gameObject);
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
