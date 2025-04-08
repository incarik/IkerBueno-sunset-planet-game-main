using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            return;
        }

        if(col.gameObject.CompareTag("ShadowZone"))
        {
            return;
        }	
        
        IDamageable damageable = col.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.TakeDamage(damage);
        }


        gameObject.SetActive(false);		
	}
}
