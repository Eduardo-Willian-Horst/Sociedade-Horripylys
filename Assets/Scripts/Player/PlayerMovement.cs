using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public float m_Speed = 3f;
    [SerializeField] private PlayerStats Stats;
    private Transform m_CameraTransform;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_CameraTransform = Camera.main.transform;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.LeftShift)) m_Speed = 5f;
        if(Input.GetKeyUp(KeyCode.LeftShift)) m_Speed = 3f;

        
    }
    void FixedUpdate()
    {   
        
        
        if(!Stats.isInspecItem){
            // Obtém a direção para a frente da câmera, projetando no plano horizontal
            Vector3 cameraForward = Vector3.ProjectOnPlane(m_CameraTransform.forward, Vector3.up).normalized;

            // Obtém a entrada de movimento
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // Calcula a nova posição do jogador baseado na direção da câmera
            Vector3 moveDirection = cameraForward * m_Input.z + m_CameraTransform.right * m_Input.x;
            m_Rigidbody.MovePosition(transform.position + moveDirection * Time.deltaTime * m_Speed);
            
        }
        
    }

    
}
