using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoomerang : Bullet
{
    private void Start()
    {
        maxtimer *= 2;
    }
    protected override void Update()
    {
        
        if(timer < maxtimer/2)
            rb.velocity = transform.forward * speed;
        else
            rb.velocity = transform.forward * -speed;

        timer += Time.deltaTime;
        Destroyer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GetDamage();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
