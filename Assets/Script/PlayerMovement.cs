using UnityEngine;
public class PlayerMovement : MonoBehaviour
{   
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private float horizontalInput;
    private float forwardInput;
    private bool lookingRight;
    public GameObject playerUpperBody;
    public GameObject playerLowerBody;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;

    private bool isGrounded;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
 
    }
    
    // Update is called once per frame
    void Update()
    {
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
            Debug.Log("ON GROUND");
        }
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);     
    }
    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(transform.localScale.x,transform.position.y + transform.localScale.y/2),
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        isGrounded = hit.collider != null;
    }
  
}
