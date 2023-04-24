using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float mouseSensibility = 3f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float mass = 1f;
    [SerializeField] Transform cameraTransform;

    CharacterController controller;
    Vector3 velocity;
    Vector2 look;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Teleport(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        Physics.SyncTransforms();
        look.x = rotation.eulerAngles.y;
        look.y = rotation.eulerAngles.z;
        velocity = Vector3.zero; 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGravity();
        UpdateLook();
        UpdateMovement();
    }

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1f : velocity.y + gravity.y;
    }

    void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSensibility;
        look.y += Input.GetAxis("Mouse Y") * mouseSensibility;

        look.y = Mathf.Clamp(look.y, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }

    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += cameraTransform.forward * y;
        input += cameraTransform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y += jumpSpeed;
        }

        //cameraTransform.Translate(input * movementSpeed * Time.deltaTime, Space.World);
        controller.Move((input * movementSpeed + velocity) * Time.deltaTime); 
    }
}
