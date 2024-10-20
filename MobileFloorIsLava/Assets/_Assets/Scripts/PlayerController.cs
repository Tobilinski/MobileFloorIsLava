using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;
    float movementSpeed = 10f;
    float jumpForce = 5f;
    [SerializeField] private Platform platform;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private bool groundCheck = false;
    private int jumpCounter;
    [SerializeField] private LayerMask platformLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGroundDectection();
    }
    private void FixedUpdate()
    {
        FixedUpdateMoveInput();
        FixedUpdateFMove();
    }
    void FixedUpdateMoveInput()
    {
        dirX = Input.acceleration.x * movementSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && groundCheck)
            {
                jumpCounter++;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
    }
    void UpdateGroundDectection()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position,groundCheckRadius, -transform.up, 0f, platformLayer);
        if (hit.collider)
        {
            groundCheck = true;
        }
        else if(jumpCounter >= 2) 
        {
            jumpCounter = 0;
            groundCheck = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
    void FixedUpdateFMove()
    {
        rb.linearVelocity = new Vector2(dirX, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IPlatformBehavior interactable = other.gameObject.GetComponent<IPlatformBehavior>();
        if (interactable != null)
        {
            GameObject obj = other.gameObject;
            platform = new Platform(obj);
            
            interactable.OnjumpDestroyAndAddScore();
        }
    }
}
[System.Serializable]
public class Platform
{
    [SerializeField] private GameObject platformGameObject;
    [SerializeField] private SpriteRenderer platformSprite;

    public Platform(GameObject platformGameObject)
    {
        this.PlatformGameObject = platformGameObject;
        this.platformSprite = platformGameObject.GetComponent<SpriteRenderer>();
    }

    public GameObject PlatformGameObject { get => platformGameObject; set => platformGameObject = value; }
    public SpriteRenderer PlatformSprite { get => platformSprite; set => platformSprite = value; }
}
