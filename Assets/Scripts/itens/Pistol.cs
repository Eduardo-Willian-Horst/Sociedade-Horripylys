using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Animator PistolAnimator;
    [SerializeField] private GameObject CameraPrincipal, FireShot;

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            
            PistolAnimator.Play("PistolShot");
            RaycastHit hit;
            if (Physics.Raycast(CameraPrincipal.transform.position, transform.forward, out hit, 15f))
            {
                // Verifica se o que foi atingido é um inimigo
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    // Se for um inimigo, aplique o dano
                    enemy.TakeDamage(5);
                }
            }
            StartCoroutine(ShowFire());
        }
    }

    private IEnumerator ShowFire(){
        FireShot.SetActive(true);
        FireShot.transform.Rotate(0f, 0f, Random.Range(0f,360f));
        yield return new WaitForSeconds(0.02f);
        FireShot.SetActive(false);
    }
}
