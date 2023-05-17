using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : MonoBehaviour, IDamage
{
    public int life = 5;
    [SerializeField]
    private int damage;
    public GameObject bullet;
    public float speed;
    public float radius = 2.5f;
    GameObject player;
    bool retroceder = true;
    Rigidbody rb;
    float bullettimer;
    float maxtimer = 2.5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        RaycastHit hit;
        transform.LookAt(player.transform.position);

        if(Physics.SphereCast(transform.position, radius, transform.forward, out hit, radius))
        {
            rb.velocity = (transform.forward * -1) * speed;
            retroceder = false;
        }
        else
        {
            retroceder = true;
        }
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
    private void OnDrawGizmos()
    {

        if (retroceder)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, radius);
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
