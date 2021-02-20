using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{

    public float speed;
    public int damages;
    public float destoryDistance;

    private Rigidbody2D rg2d;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        rg2d.velocity = transform.right * speed;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        if (distance > destoryDistance)
        {
            Destroy(gameObject);
        }
    }

    //伤害我写死了
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")&& other.GetType().ToString()=="UnityEngine.BoxCollider2D")
        {
            other.GetComponent<GhostMove>().TakeDamage(damages);

            Vector2 difference = other.transform.position - transform.position;
            other.transform.position = new Vector2(other.transform.position.x + difference.x / 4, other.transform.position.y + difference.y/4);
            if(gameObject.tag!="Player")
                Destroy(gameObject);
        }
    }
}
