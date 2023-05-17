using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int life;
    public float speed;
    public GameObject bullet;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x,0,z).normalized * speed;
        if(rb.velocity != Vector3.zero)
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
    void Shoot()
    {
        GameObject a = Instantiate(bullet);
        a.transform.position = transform.position + (transform.forward * 1.5f);
        a.transform.rotation = transform.rotation;
    }

    void ChangeLife(int value)
    {
        life += value;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDamage>() != null) 
        {
            ChangeLife(-collision.gameObject.GetComponent<IDamage>().GetDamage());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamage>() != null)
        {
            ChangeLife(-other.gameObject.GetComponent<IDamage>().GetDamage());
        }
    }

}
