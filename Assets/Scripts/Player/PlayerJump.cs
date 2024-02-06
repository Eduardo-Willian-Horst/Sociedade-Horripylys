using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float groundCheckDistance = 0.2f;
    private Rigidbody playerRigidbody;
    private bool isGrounded;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Verifica se o jogador está no chão
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, isGrounded ? Color.green : Color.red);
        // Pula se o jogador estiver no chão e pressionar a tecla de pulo (por exemplo, barra de espaço)
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Aplica uma força para cima ao rigidbody para simular o pulo
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
