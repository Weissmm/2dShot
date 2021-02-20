using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{

    public float speed;
    public float radius;
    public int health;
    public int damage;
    public float flashTime;
    public GameObject floatPoint;
    public GameObject boom;

    private SpriteRenderer sr;
    private Color originColor;

    private Rigidbody2D rb;
    private Transform playerTransform;

    public float waitTime;
    public Transform[] movePos;

    private int i = 0;
    private bool right = true;
    private float wait;


    // Start is called before the first frame update 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        originColor = sr.color;
        wait = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject gb1=Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
            Destroy(gb1,2f);
            Destroy(gameObject);
        }
        
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < radius)
            {
                FilpDirection();
                transform.position = Vector2.MoveTowards(transform.position,
                                                playerTransform.position,
                                                speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
                if (transform.position.x - movePos[i].position.x < 0)
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                if (transform.position.x - movePos[i].position.x > 0)
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
                {
                    //在巡逻边缘位置的停止等待时间
                    if (waitTime >= 0)
                    {
                        waitTime -= Time.deltaTime;
                    }
                    else
                    {
                        if (right)
                        {
                            transform.eulerAngles = new Vector3(0, 180, 0);
                            right = false;

                        }
                        else
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            right = true;
                        }


                        if (i == 0)
                        {
                            i = 1;
                        }
                        else
                        {
                            i = 0;
                        }

                        waitTime = wait;
                    }
                }
            }
        }
    }
    void FilpDirection()
    {
        if (transform.position.x - playerTransform.position.x < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (transform.position.x - playerTransform.position.x > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    public void TakeDamage(int d)
    {
        health -= d;
        GameObject gb=Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = d.ToString();
        FlashColor(flashTime);
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
}
