using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour, IDamage
{
    public int life = 5;
    [SerializeField]
    private int damage;
    public GameObject bullet;
    public float speed;
    GameObject player;
    public float maxtimer;
    float timer;
    Rigidbody rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        timer += Time.deltaTime;
        if(timer > maxtimer)
        {
            Shoot();
            timer = 0;
        }
    }
    void Move()
    {
        transform.LookAt(player.transform.position);
        rb.velocity = transform.forward * speed;
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
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
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
