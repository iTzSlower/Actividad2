using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour, IDamage
{
    protected Rigidbody rb;
    int damage = 1;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float timer;
    [SerializeField]
    protected float maxtimer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
        rb.velocity = transform.forward * speed;
    }
    protected void Destroyer()
    {
        if (timer > maxtimer)
        {
            Destroy(this.gameObject);
        }
    }
    public int GetDamage()
    {
        return damage;
    }
}
