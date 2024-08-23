using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Tile : MonoBehaviour, IPlatformBehavior
{
    private Vector3 newPos;

    [SerializeField] private Vector3 gameManagerPlatformPos;
    private void Start()
    {
        StartCoroutine(Delayer());  
    }
    public void OnjumpDestroyAndAddScore()
    {
        StartCoroutine(DelayedDestroyer());
    }

    public IEnumerator DelayedDestroyer()
    {
        yield return new WaitForSeconds(2f);
        AddScore();

        newPos.y = Random.Range(.5f, 1f);
        newPos.x = Random.Range(-3.5f, 3.5f);
        //gameManagerPlatformPos.y += newPos.y;
        //gameManagerPlatformPos.x = newPos.x;
        //transform.position = gameManagerPlatformPos;


        Destroy(this.gameObject);
    }

    public void KillOverlap()
    {
        Destroy(this.gameObject);
    }

    public void AddScore()
    {
        UserManager.Instance.AddScoreToData();
    }
    public IEnumerator Delayer()
    {
        yield return new WaitForSeconds(0.6f);
        gameManagerPlatformPos = GameManager.Instance.SpawnPositionPart;

    }
}
