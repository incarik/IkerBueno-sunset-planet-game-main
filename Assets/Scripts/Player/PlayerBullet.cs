using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.CompareTag("Player"))
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
