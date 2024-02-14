using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vultun : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Animator VultunAnimator;
    [SerializeField] private PlayerLifeController PlayerLife;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float Speed;
    private bool isInAttack = false;

    void Update()
    {
        if(!isInAttack){
            Move();
            VerificaAtaque();
        }
            
    }

    private void Move(){
        Vector3 destino = Player.transform.position;
        Vector3 novaPosicao = Vector3.MoveTowards(transform.position, destino, Speed * Time.deltaTime);
        transform.position = novaPosicao;

        transform.LookAt(destino);

    }

    private void VerificaAtaque(){
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceToPlayer <= attackDistance)
        {
            isInAttack = true;
            VultunAnimator.Play("Hook");
            StartCoroutine(AtaqueCurto());
        }
    }

    private IEnumerator AtaqueCurto(){
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if(distanceToPlayer <= attackDistance){
            PlayerLife.PlayerTakeDamage(2);
        }
        yield return new WaitForSeconds(1.3f);
        isInAttack = false;
        VultunAnimator.Play("Running");
    }
}