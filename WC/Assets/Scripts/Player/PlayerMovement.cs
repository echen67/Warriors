using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public static GameObject self;

    public float playerSpeed;
    public float absVelX = 0f;
    public float absVelY = 0f;
    public bool standing;
    public float standingThreshold;

    public bool currentDirection = false;  //left is false, right is true
    public bool newDirection;
    public bool walking = false;
    public bool jumping = false;
    public bool crouching = false;

    private Animator animator;
    private Rigidbody2D body2D;
    private Transform playerTransform;
    private BoxCollider2D collider2d;
    private Vector2 originalSize;
    private Vector2 originalOffset;

    void Awake()
    {
        if (self == null)
        {
            DontDestroyOnLoad(gameObject);
            self = gameObject;
        }
        else if (self != this)
        {
            Destroy(gameObject);
        }
        body2D = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        collider2d = GetComponent<BoxCollider2D>();
        originalSize = collider2d.size;
        originalOffset = collider2d.offset;
    }

    void Update()
    {
        absVelX = System.Math.Abs(body2D.velocity.x);
        absVelY = System.Math.Abs(body2D.velocity.y);

        standing = absVelY <= standingThreshold;

        //Jumping
        if (standing == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * playerSpeed;
                jumping = true;
            }
        }

        //Crouching
        if (Input.GetKey(KeyCode.DownArrow))
        {
            collider2d.size = new Vector2(originalSize.x, originalSize.y-2);
            float difference = originalSize.y - (originalSize.y-2);
            collider2d.offset = new Vector2(originalOffset.x, -(originalSize.y-2));
            animator.SetInteger("Test", 3);
            crouching = true;
            playerSpeed = 5f;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            collider2d.size = originalSize;
            collider2d.offset = originalOffset;
            animator.SetInteger("Test", 0);
            crouching = false;
            playerSpeed = 10f;
        }

        //Change direction based on the last key (left or right) pressed
        if (currentDirection != newDirection)
        {
            transform.Rotate(new Vector3(0, -180, 0));
            currentDirection = newDirection;
        }

        //Moving Left and Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed, Space.World);
            newDirection = true;
            if (crouching)
            {
                animator.SetInteger("Test", 3);
            } else
            {
                animator.SetInteger("Test", 1);
            }
            walking = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed, Space.World);
            newDirection = false;
            if (crouching)
            {
                animator.SetInteger("Test", 3);
            }
            else
            {
                animator.SetInteger("Test", 1);
            }
            walking = true;
        }

        //Idling
        if (absVelY == 0 && !walking && !crouching)
        {
            animator.SetInteger("Test", 0);
        }

        //Stop walking left and right
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (!crouching)
            {
                animator.SetInteger("Test", 0);
            }
            walking = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (!crouching)
            {
                animator.SetInteger("Test", 0);
            }
            walking = false;
        }

        //Jumping animation
        if (absVelY > 0)
        {
            if (!crouching)
            {
                animator.SetInteger("Test", 2);
            }
        }
    } 

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HELLOOOOO???");
        if (Input.GetKey(KeyCode.UpArrow) && other.tag == "Tree")
        {
            body2D.mass = 0;
            Debug.Log("HI");
            transform.Translate(Vector2.up * Time.deltaTime * playerSpeed, Space.World);
        }
    }
}
