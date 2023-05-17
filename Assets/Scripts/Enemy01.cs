using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour, IDamage
{
    public int life = 5;
    [SerializeField]
    private int damage;
    public GameObject bullet;
    public float speed;
    public float maxtimer;
    Rigidbody rb;
    float direction = 1;
    public float timer;
    float bullettimer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        bullettimer += Time.deltaTime;
        if (bullettimer > maxtimer)
        {
            Shoot();
            bullettimer = 0;
        }
    }
    void Move()
    {
        timer += Time.deltaTime;
        if (timer < 1)
        {
            rb.velocity = new Vector3(0, 0, direction) * speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (timer < 2)
        {
            rb.velocity = new Vector3(0, 0, -direction) * speed;
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            timer = 0;
        }

    }
    void ChangeLife(int value)
    {
        life += value;
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Shoot()
    {
        GameObject a = Instantiate(bullet);
        a.transform.position = transform.position + (transform.forward * 1.5f);
        a.transform.rotation = transform.rotation;
    }
    public int GetDamage()
    {
        return damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamage>() != null)
        {
            ChangeLife(-other.gameObject.GetComponent<IDamage>().GetDamage());
        }
    }
}
