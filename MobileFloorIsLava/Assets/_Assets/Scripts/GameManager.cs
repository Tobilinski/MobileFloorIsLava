using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Transform SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    [SerializeField] private GameObject[] tiles;
    [SerializeField] private Transform spawnPoint;

    private int Index;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            int index = Random.Range(0, tiles.Length); // Generate a random index
            Instantiate(tiles[index], SpawnPoint.position, Quaternion.identity); // Spawn at SpawnPoint position

            yield return new WaitForSeconds(3f); // Wait for 3 seconds before spawning the next object
        }
    }
}
