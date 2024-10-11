using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 6.0f;
    public float mouseSensitivity = 100.0f;
    public float gravity = -9.81f;



    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;

    public Transform playerCamera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movimento do Mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        // Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        // Movimento do Jogador
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Aplicação de Gravidade
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    // public float moveSpeed = 5.0f;
    // public float mouseSenivity = 2.0f;
    // private float verticalLookRotation = 0;
    // private CharacterController characterController;
    // private Camera playerCamera;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     characterController = GetComponent<CharacterController>();
    //     playerCamera = Camera.main;

    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     float mouseX = Input.GetAxis("Mouse X") * mouseSenivity;
    //     float mouseY = Input.GetAxis("Mouse Y") * mouseSenivity;

    //     // Rotacionar o personagem em torno do eixo Y
    //     transform.localRotation = Quaternion.Euler(0f, transform.localEulerAngles.y + mouseX, 0f);

    //     // Rotacionar a câmera para cima e para baixo, com limite de 90 graus
    //     verticalLookRotation -= mouseY;
    //     verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
    //     playerCamera.transform.localEulerAngles = new Vector3(verticalLookRotation, 0f, 90f);

    //     // Movimento com as teclas WASD
    //     float moveFoward = Input.GetAxis("Vertical");
    //     float moveSideways = Input.GetAxis("Horizontal");

    //     // Direção do movimento relativo ao personagem
    //     Vector3 moveDirection = transform.forward * moveFoward + transform.right * moveSideways;
    //     characterController.Move(moveDirection * moveSpeed * Time.deltaTime) ;
    // }

    
}
