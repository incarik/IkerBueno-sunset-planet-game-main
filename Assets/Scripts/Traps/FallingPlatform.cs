using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _platformRigidBody;
    private Vector3 _shakePosition1;
    private Vector3 _shakePosition2;
    private Vector3 _destination;

    [SerializeField] private float _shakeMovement = 0.5f;
    [SerializeField] private float _shakeSpeed = 5;
    [SerializeField] private bool _startShake = false;
    [SerializeField] private float _fallDelay = 2f;
    private float _fallTimer = 0;

    void Awake()
    {
        _platformRigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _shakePosition1 = new Vector3(transform.position.x + _shakeMovement, transform.position.y, transform.position.z);
        _shakePosition2 = new Vector3(transform.position.x - _shakeMovement, transform.position.y, transform.position.z);

        transform.position = _shakePosition1;
    }

    // Update is called once per frame
    void Update()
    {
        if(_startShake)
        {
            ShakePlatForm();

            if(_fallTimer < _fallDelay)
            {
                _fallTimer += Time.deltaTime;
            }
            else
            {
                _platformRigidBody.bodyType = RigidbodyType2D.Dynamic;
                _startShake = false;
            }

        }
    }

    void ShakePlatForm()
    {
        if(transform.position == _shakePosition1)
        {
            _destination = _shakePosition2;
        }
        else if(transform.position == _shakePosition2)
        {
            _destination = _shakePosition1;
        }

        transform.position = Vector3.MoveTowards(transform.position, _destination, _shakeSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _startShake = true;
            return;
        }
        
        Destroy(gameObject);

    }
}
