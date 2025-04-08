using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarEnemyBullet : Bullet
{
    [SerializeField] private GameObject _puddlePrefab;

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

        //6 = Ground Layer
        if(col.gameObject.layer == 6)
        {
            //Instantiate(_puddlePrefab, transform.position, Quaternion.Euler(0, 0, 0));.
            Instantiate(_puddlePrefab, col.bounds.ClosestPoint(transform.position), Quaternion.Euler(0, 0, 0));
        }
        

        gameObject.SetActive(false);
	}
}
