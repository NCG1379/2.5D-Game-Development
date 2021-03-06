using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField]
    private Transform pointAPos;
    [SerializeField]
    private Transform pointBPos;

    Transform _target;

    private float _speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        _target = pointBPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlatformMovement();
    }

    void PlatformMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == pointBPos.position)
        {
            _target = pointAPos;

        }
        else if (transform.position == pointAPos.position)
        {
            _target = pointBPos;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }


}
