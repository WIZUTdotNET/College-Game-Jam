using System;
using UnityEngine;

public class DoorsMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody2D.MovePosition(transform.position + Vector3.up);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            _rigidbody2D.MovePosition(transform.position + Vector3.down);
        }
    }
}
