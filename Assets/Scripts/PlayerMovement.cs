using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{   
    /*<--------Movement Variables-------->*/
    
    public float speed = 2.0f;
    public float sprintMultiplier = 2.0f;
    public float jumpforce = 5.0f;
    
    /*<--------Components-------->*/
    private Rigidbody2D rb;
    
    private float _horizontalInput;
    public float HorizontalInput => _horizontalInput;
    
    private float _forwardInput;
    public float ForwardInput => _forwardInput;
    
    public bool _lookingRight;
    public bool LookingRight => _lookingRight;
    
    /*<--------Player Components-------->*/
    
    public GameObject playerUpperBody;
    public GameObject playerLowerBody;
    
    /*<--------Ground Check Variables-------->*/
    
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f; //Radius of the ground check circle
    
    private Collider2D _col2d; //Player collider
    public Collider2D Col2D => _col2d;
    
    private Vector2[] _groundCheckPos = new Vector2[3]; //Positions of the ground check circles
    public Vector2[] GroundCheckPos => _groundCheckPos;
    
    private bool isGrounded;
    public bool IsGrounded => isGrounded;
    
    /*<--------Wall Check Variables-------->*/
    
    public LayerMask wallLayer;
    public float wallCheckRadius = 0.1f; //Radius of the wall check circle
    
    private Vector2[] _wallCheckPosLeft = new Vector2[3]; //Positions of the left wall check circles
    public Vector2[] WallCheckPosLeft => _wallCheckPosLeft;
    
    private Vector2[] _wallCheckPosRight = new Vector2[3]; //Positions of the right wall check circles
    public Vector2[] WallCheckPosRight => _wallCheckPosRight;
    
    public bool isTouchingWallLeft;
    
    public bool isTouchingWallRight;
   
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        _col2d = GetComponent<Collider2D>();
        
        // Initialize looking direction based on initial scale
        _lookingRight = transform.localScale.x > 0;
    }
    
    void Update()
    {
      UpdateGroundCheckPostions();
      UpdateWallCheckPostions();
      //walking
      CheckWall();
      //get horizontal and vertical input
      _horizontalInput = Input.GetAxisRaw("Horizontal");
      _forwardInput = Input.GetAxisRaw("Vertical");
      // Check if Shift is held for sprinting
      bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
      
      float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;
        
        if (_horizontalInput > 0) {
            if (!_lookingRight) {
                transform.localScale = transform.localScale* new Vector2(-1,1);
                _lookingRight = true;
            }
           
           
        }
        if(_horizontalInput < 0) {
            if (_lookingRight) {
                transform.localScale = transform.localScale* new Vector2(-1,1);
                _lookingRight = false;
            }
            
        } 
        if (!isTouchingWallLeft && !isTouchingWallRight)
        {
            if (_horizontalInput == 0) SetAnimationVariables(
                new string[] {"walking", "running"}, new bool[] {false, false});
            else
            {
                if (isSprinting) SetAnimationVariables(
                    new string[] {"walking", "running"}, new bool[] {false, true});
                
            
                else SetAnimationVariables(
                    new string[] {"walking", "running"}, new bool[] {true, false});
                
            }
            
           
            if (_horizontalInput > 0 || _horizontalInput < 0)
            {
                Vector2 direction = _horizontalInput > 0 ? Vector2.right : Vector2.left;
                gameObject.transform.Translate(direction * Time.deltaTime * currentSpeed); 
            }
            
      
        }
        //if player is touching a wall while on ground, player stops moving
        else
        {
            SetAnimationVariables(new string[] {"walking", "running"}, new bool[] {false, false});
        }
       
        
        //Jumping
        
        CheckGround();
    
        
        if (isGrounded) {
            SetAnimationVariables("jumping",false);
            
        }
        else {
            
            SetAnimationVariables("jumping",true);
            
        }
        if (isGrounded&&_forwardInput > 0) {
            
               Jump();
              
        }
    }
    void CheckWall()
    {
        Vector2 checkDirection = _lookingRight ? Vector2.right : Vector2.left;
        Vector2[] checkPositions = _lookingRight ? _wallCheckPosRight : _wallCheckPosLeft;
        
        RaycastHit2D[] hit =
        {
            
            Physics2D.CircleCast(
                checkPositions[0],
                wallCheckRadius,
                checkDirection,
                wallCheckRadius,
                wallLayer),
            
            Physics2D.CircleCast(
                checkPositions[1],
                wallCheckRadius,
                checkDirection,
                wallCheckRadius,
                wallLayer),
            
            Physics2D.CircleCast(
                checkPositions[2],
                wallCheckRadius,
                checkDirection,
                wallCheckRadius,
                wallLayer)
            
        };
        
        for (int i = 0; i < checkPositions.Length; i++) {
            
            if (_lookingRight) {
                Debug.Log("Checking Right");
                isTouchingWallLeft = false;
                isTouchingWallRight = hit[i].collider != null;
                if (isTouchingWallRight) return;
                
            } 
            
            else {
                Debug.Log("Checking Left");
                isTouchingWallRight = false;
                isTouchingWallLeft = hit[i].collider != null;
                if (isTouchingWallLeft) return;
                
            }
        }
    }
    //Circles to check if the player is on ground
    void CheckGround()
    {
        
        RaycastHit2D[] hit =
        {
            
            Physics2D.CircleCast(
                _groundCheckPos[0],
                groundCheckRadius,
                Vector2.down,
                groundCheckRadius,
                groundLayer),
            
            Physics2D.CircleCast(
                _groundCheckPos[1],
                groundCheckRadius,
                Vector2.down,
                groundCheckRadius,
                groundLayer),
            
            Physics2D.CircleCast(
                _groundCheckPos[2],
                groundCheckRadius,
                Vector2.down,
                groundCheckRadius,
                groundLayer)
            
        };
        
        for (int i = 0; i < _groundCheckPos.Length; i++) {
            
            isGrounded = hit[i].collider !=null;
            if (isGrounded) return;
            
        }
    }
    
    //visualizer
    void OnDrawGizmosSelected()
    {
        
        //Ground check visualizer
        if (!_col2d) _col2d = GetComponent<Collider2D>();
        
        Gizmos.color = Color.yellow;
    
        for (int i = 0; i < _groundCheckPos.Length; i++) {
            
            Gizmos.DrawWireSphere(_groundCheckPos[i], groundCheckRadius); 
            
        } 
        
        //Wall check visualizer
        if (_lookingRight) {
            Gizmos.color = Color.blue;
        
            for (int i = 0; i < _wallCheckPosRight.Length; i++) {
                
                Gizmos.DrawWireSphere(_wallCheckPosRight[i], wallCheckRadius); 
                
            }
        } else {
            Gizmos.color = Color.red;
        
            for (int i = 0; i < _wallCheckPosLeft.Length; i++) {
                
                Gizmos.DrawWireSphere(_wallCheckPosLeft[i], wallCheckRadius); 
            }
        }
       
    }
    //Jump function


    private void UpdateGroundCheckPostions()
    {
        //Ground Circle positions
        
        _groundCheckPos[0] = new Vector2(
            _col2d.bounds.min.x+groundCheckRadius+0.03f,
            _col2d.bounds.min.y
        );
        
        _groundCheckPos[1] = new Vector2(
            _col2d.bounds.center.x,
            _col2d.bounds.min.y
        );
        
        _groundCheckPos[2] = new Vector2(
            _col2d.bounds.max.x-groundCheckRadius-0.03f,
            _col2d.bounds.min.y
        );
        
     
    }
    private void UpdateWallCheckPostions()
    {
        // Left wall positions
        _wallCheckPosLeft[0] = new Vector2(
            _col2d.bounds.min.x,
            _col2d.bounds.min.y+wallCheckRadius+0.03f
      
        );
        
        _wallCheckPosLeft[1] = new Vector2(
            _col2d.bounds.min.x,
            _col2d.bounds.center.y
        );
        
        _wallCheckPosLeft[2] = new Vector2(
            _col2d.bounds.min.x,
            _col2d.bounds.max.y-wallCheckRadius-0.03f
           
        );
   
        
        // Right wall positions
        _wallCheckPosRight[0] = new Vector2(
            _col2d.bounds.max.x,
            _col2d.bounds.min.y+wallCheckRadius+0.03f
      
        );
        
        _wallCheckPosRight[1] = new Vector2(
            _col2d.bounds.max.x,
            _col2d.bounds.center.y
        );
        
        _wallCheckPosRight[2] = new Vector2(
            _col2d.bounds.max.x,
            _col2d.bounds.max.y-wallCheckRadius-0.03f
           
        );
    }
    void Jump()
    {
        
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        
    }
    
    
    
    
    //Animation variable functions

    private void SetAnimationVariables(String variable, bool value)
    {
            playerUpperBody.GetComponent<Animator>().SetBool(variable, value); 
            playerLowerBody.GetComponent<Animator>().SetBool(variable, value); 
    }
    private void SetAnimationVariables(String[] variables, bool[] values)
    {
        for (int i = 0; i < variables.Length; i++) {
            playerUpperBody.GetComponent<Animator>().SetBool(variables[i], values[i]);
            playerLowerBody.GetComponent<Animator>().SetBool(variables[i], values[i]); 
        }
    }
    private void SetUpperBodyAnimationVariables(String[] variables, bool[] values)
    {
        for (int i = 0; i < variables.Length; i++) {
            playerUpperBody.GetComponent<Animator>().SetBool(variables[i], values[i]);
        }
    }
    private void SetUpperBodyAnimationVariables(String variable, bool value)
    {
        playerUpperBody.GetComponent<Animator>().SetBool(variable, value); 
    }
    private void SetLowerBodyAnimationVariables(String[] variables, bool[] values)
    {
        for (int i = 0; i < variables.Length; i++) {
            playerLowerBody.GetComponent<Animator>().SetBool(variables[i], values[i]);
        }
    }
    private void SetLowerBodyAnimationVariables(String variable, bool value)
    {
        playerLowerBody.GetComponent<Animator>().SetBool(variable, value); 
    }

  
}

