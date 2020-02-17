using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkSpeed;
    Rigidbody rb;
    Vector3 moveDirection;
    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }
    void FixedUpdated()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
    }
}
