using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementPlatfomer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed = 5f;
    public float JumpForce = 9f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Onjump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.linearVelocityY = JumpForce;
        }
    }


    void Update()
    {
        
    }
}
