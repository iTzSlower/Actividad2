using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void Update()
    {
        rb.velocity = transform.forward * speed;
        timer += Time.deltaTime;
        Destroyer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
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
