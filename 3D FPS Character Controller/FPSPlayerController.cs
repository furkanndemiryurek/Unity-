using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerController : MonoBehaviour
{
    // Add it inside of your character
    CharacterController characterController;
    Vector3 velocity;
    public bool isGrounded;

    [SerializeField] private Transform ground;
    [SerializeField] private float distance = .4f;

    [SerializeField] private float speed; // 4
    [SerializeField] private float jumpHeight; // 3
    [SerializeField] private float gravity; // 9.8f
    [SerializeField] private bool isRuning;

    [SerializeField] private LayerMask mask; // ground

    [SerializeField] private float stamina = 10;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        #region IsSprint
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = 12;
            stamina -= Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4;
        }

        if (stamina <= 0)
        {
            speed = 4;
        }
            #endregion
        Movement();
        Gravity();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;

        characterController.Move(movement * speed * Time.deltaTime);
    }

    void Jump()
    {
        velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(ground.position, distance, mask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
