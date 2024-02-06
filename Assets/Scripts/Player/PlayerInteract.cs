using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public TextMeshProUGUI textoAcao;
    private bool isOverInteractiveObject = false;
    [SerializeField] private PlayerStats ps;
    void Awake(){
        textoAcao.enabled = false;
    }
    void Update()
    {
        RaycastHit hit;
        bool hitInteractiveObject = Physics.Raycast(transform.position, transform.forward, out hit, 2) && hit.collider.CompareTag("Interactive");
        Debug.DrawLine(transform.position, transform.position + transform.forward * 2f, isOverInteractiveObject ? Color.green : Color.red);
        if (hitInteractiveObject != isOverInteractiveObject)
        {
            // Atualiza o estado apenas quando o estado mudar
            isOverInteractiveObject = hitInteractiveObject;
            textoAcao.enabled = isOverInteractiveObject;
        }

        if (isOverInteractiveObject && Input.GetMouseButtonDown(0) && ps.isInspecItem == false)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // Chame a função de interação do objeto
                interactable.Interact();
            }
        }
    }
}
