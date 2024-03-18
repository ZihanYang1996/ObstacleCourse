using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 moveInput;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        // Debug.Log("Move: " + moveInput);
    }

    void Move()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
        // transform.position += movement; // alternative way to move the object
    }
}
