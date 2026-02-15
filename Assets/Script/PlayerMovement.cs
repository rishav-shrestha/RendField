using UnityEngine;
public class PlayerMovement : MonoBehaviour
{   
    public float speed = 2.0f;
    public float jumpforce = 5.0f;
    private Rigidbody2D rb;
    private float horizontalInput;
    private float forwardInput;
    private bool lookingRight;
    public GameObject playerUpperBody;
    public GameObject playerLowerBody;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;
    private Collider2D col;
    private Vector2[] pos = new Vector2[3];

    private bool isGrounded;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
         col = GetComponent<Collider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        pos[0] = new Vector2(
            col.bounds.min.x+groundCheckRadius+0.03f,
            col.bounds.min.y
        );
        pos[1] = new Vector2(
            col.bounds.center.x,
            col.bounds.min.y
        );
        pos[2] = new Vector2(
            col.bounds.max.x-groundCheckRadius-0.03f,
            col.bounds.min.y
        );
        
        
        //walking
        horizontalInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput == 0)
        {
            playerUpperBody.GetComponent<Animator>().SetBool("walking",false);
            playerLowerBody.GetComponent<Animator>().SetBool("walking",false);
        }
        if (horizontalInput > 0)
        {
            playerUpperBody.GetComponent<Animator>().SetBool("walking",true);
            playerLowerBody.GetComponent<Animator>().SetBool("walking",true);
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (lookingRight)
            {
                transform.localScale = transform.localScale* new Vector2(-1,1);
                lookingRight = false;
            }
        }
        if(horizontalInput < 0)
        {
            playerUpperBody.GetComponent<Animator>().SetBool("walking",true);
            playerLowerBody.GetComponent<Animator>().SetBool("walking",true);
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (!lookingRight)
            {
                transform.localScale = transform.localScale* new Vector2(-1,1);
                lookingRight = true;
            }
        }
        //Jumping
        CheckGround();
        if (isGrounded)
        {
            playerUpperBody.GetComponent<Animator>().SetBool("jumping",false);
            playerLowerBody.GetComponent<Animator>().SetBool("jumping",false);
        }
        else
        {
            playerUpperBody.GetComponent<Animator>().SetBool("jumping",true); 
            playerLowerBody.GetComponent<Animator>().SetBool("jumping",true);
        }
        if (isGrounded&&forwardInput > 0)
        {
               Jump();
              
        }
    }
    void CheckGround()
    {
        RaycastHit2D[] hit =
        {
            Physics2D.CircleCast(
                pos[0],
                groundCheckRadius,
                Vector2.down,
                groundCheckRadius,
                groundLayer),
            Physics2D.CircleCast(
                pos[1],
                groundCheckRadius,
                Vector2.down,
                groundCheckRadius,
                groundLayer),
            Physics2D.CircleCast(
                pos[2],
                groundCheckRadius,
                Vector2.down,
                groundCheckRadius,
                groundLayer)
        };
        for (int i = 0; i < pos.Length; i++)
        {
            isGrounded = hit[i].collider !=null;
            if (isGrounded)
            {
                return;
            }
        }
      
    }
    void OnDrawGizmosSelected()
    {
        
        if (!col) col = GetComponent<Collider2D>();
        Gizmos.color = Color.yellow;
        for (int i = 0; i < pos.Length; i++)
        {
            Gizmos.DrawWireSphere(pos[i], groundCheckRadius); 
        }
       
    }
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
    }
}
