using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] public float turnSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;

    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    [SerializeField] float moveDirection;

    void Start()
    {
        
    }

    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        moveDirection = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, -turnAmount));
        transform.Translate( new Vector3(0, moveDirection, 0));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
}
