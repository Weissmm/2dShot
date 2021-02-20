using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public GameObject fire;
    public GameObject special;
    public GameObject fireLight;
    public GameObject SpecialfireLight;
    public Animator anim;
    public float flashTime;
    public int Health;

    private SpriteRenderer sr;
    private Color originColor;

    [Header("移动参数")]
    public float speed = 8f;
    public float gapTime=0.25f;
    public float shotBack = 0.02f;

    [Header("跳跃参数")]
    public float jumpForce = 6.3f;
    public float jumpHoldForce=1.9f;
    public float jumpHoldDuration=0.1f;

    float jumpTime;
    float invokeTime;
    float invokeTime2;

    [Header("状态")]
    public bool isOnGround;
    public bool isJump;

    [Header("环境检测")]
    public LayerMask groundLayer;
    public float footOffset = 0.2f;
    public float groundDis = 0.6f;

    float xVelocity;

    //按键设置
    bool jumpPressed;
    bool jumpHeld;



    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originColor = sr.color;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        invokeTime = gapTime;
        invokeTime2 = gapTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        jumpPressed = Input.GetButtonDown("Jump");
        jumpHeld = Input.GetButton("Jump");
        GroundMovement();
        MidAirMovement();
        if (Input.GetKey(KeyCode.J))
        {
            invokeTime += Time.deltaTime;
            if (invokeTime - gapTime > 0)
            {
                Shoot();
                GameController.camShake.Shake();
                invokeTime = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            invokeTime = gapTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            invokeTime2 += Time.deltaTime;
            if (invokeTime2 - gapTime > 0)
            {
                SpecialShoot();
                GameController.camShake.Shake();
                invokeTime2 = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            invokeTime2 = gapTime;
        }
    }

    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);

    }
    void ResetColor()
    {
        sr.color = originColor;
    }

    void PhysicsCheck()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundDis, groundLayer);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundDis, groundLayer);

        //if (coll.IsTouchingLayers(groundLayer))
        //    isOnGround = true;
        //else
        //    isOnGround = false;
        if (leftCheck || rightCheck)
            isOnGround = true;
        else
            isOnGround = false;
    }

    private void FixedUpdate()
    {
        PhysicsCheck();
    }

    void Shoot()  //普通射击
    {
        anim.SetBool("isShot", true);
        Instantiate(fire, transform.position, transform.rotation);
        GameObject gb11 = Instantiate(fireLight, transform.position, transform.rotation) as GameObject;
        Destroy(gb11, 1.0f);
        if (transform.localRotation.y==0)
            transform.position = new Vector3(transform.position.x-shotBack, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x + shotBack, transform.position.y, transform.position.z);
    }
    void SpecialShoot()     //特殊射击
    {
        anim.SetBool("isShot", true);
        Instantiate(special, transform.position, transform.rotation);
        GameObject gb11=Instantiate(SpecialfireLight, transform.position, transform.rotation) as GameObject;
        Destroy(gb11, 1.0f);
        if (transform.localRotation.y == 0)
            transform.position = new Vector3(transform.position.x - shotBack, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x + shotBack, transform.position.y, transform.position.z);
    }
    void GroundMovement()
    {
        xVelocity = Input.GetAxis("Horizontal");
        float facedDirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        anim.SetFloat("running",Mathf.Abs(facedDirection));
        FilpDirection();
    }

    void FilpDirection()
    {
        if (xVelocity < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (xVelocity > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }


    void MidAirMovement()
    {
        if (jumpPressed && isOnGround && !isJump)
        {
            isOnGround = false;
            isJump = true;
            anim.SetBool("isJump", true);

            jumpTime = Time.time + jumpHoldDuration;

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        else if (isJump)
        {
            if (jumpTime < Time.time)
            {
                isJump = false;
                anim.SetBool("isJump", false);
            }
        }
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float dis, LayerMask layer)
    {
        Vector2 pos = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, dis, layer);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDirection * dis,color);

        return hit;
    }
}
