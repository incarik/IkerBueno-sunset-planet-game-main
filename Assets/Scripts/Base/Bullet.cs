using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public int damage = 1;
	[SerializeField] private float _bulletSpeed = 5;

    [SerializeField] private float maxAliveTime = 0.4f;
    [SerializeField] private float aliveTime = 0f;

    void OnEnable()
    {
        aliveTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        BulletLifeTimer();
    }

    void BulletLifeTimer()
    {
        aliveTime += Time.deltaTime;
        if (aliveTime > maxAliveTime) 
        {
        	gameObject.SetActive(false);
        }
    }

    void Movement()
    {
        transform.position += transform.right * _bulletSpeed * Time.deltaTime;
    }
}
