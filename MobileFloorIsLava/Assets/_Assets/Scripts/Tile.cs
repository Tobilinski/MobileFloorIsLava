using UnityEngine;

public class Tile : MonoBehaviour
{
    float speed = 1f;
    [SerializeField] private LayerMask respawnMask;

    private float rayDistance = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        Detect();
        Debug.DrawRay(transform.position, -Vector2.up * rayDistance, Color.green);
        //Debug.DrawLine(this.transform.position, this.transform.position + this.transform.up);
    }

    void Detect()
    {
        // Perform a 2D raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, respawnMask);

        // Check if the raycast hit something
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Trigger"))
            {
                // Perform your respawn action here
                this.transform.position = GameManager.Instance.SpawnPoint.position;
                Debug.Log("Hit");
            }
        }
    }
}
