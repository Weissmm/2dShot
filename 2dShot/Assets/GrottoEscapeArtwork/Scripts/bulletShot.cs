using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShot : MonoBehaviour
{
    public GameObject fire;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Shoot"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        anim.SetBool("isShot", true);
        Instantiate(fire, transform.position, transform.rotation);
    }
}
