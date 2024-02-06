using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDirections : Interactable
{
    public Transform target; // O objeto em direção ao qual você quer girar
    public float rotationSpeed = 5f; // A velocidade de rotação

    private bool isRotating = false;

    

    public override void Interact(){
        //StartTowardFunction();
    }

    public void StartTowardFunction(GameObject ObgToRotate){
        if (!isRotating)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(RotateTowardsTarget(ObgToRotate));
        }
    }

    IEnumerator RotateTowardsTarget(GameObject ObgToRotate)
    {
        isRotating = true;

        // Calcula a direção para o alvo
        Vector3 directionToTarget = target.position - transform.position;

        // Calcula a rotação desejada com base na direção para o alvo
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            // Interpola suavemente entre a rotação atual e a rotação desejada
            ObgToRotate.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            yield return null;
        }

        isRotating = false;
    }
}
