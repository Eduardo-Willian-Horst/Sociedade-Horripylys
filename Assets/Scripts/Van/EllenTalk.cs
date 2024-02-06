using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenTalk : Interactable
{
    [SerializeField] private TalkSystem Ts;
    [SerializeField] private BoxCollider Caixa, Porta;

    

    void Start(){
        StartCoroutine(TalkComplete());
    }

    IEnumerator Talk(string fala){
        Ts.SendMsg("Ellen: " + fala);
        yield return new WaitForSeconds(4.5f);
    }
    IEnumerator TalkComplete(){
        Ts.tempoDeFala = 2f;
        yield return new WaitForSeconds(2f);
        yield return Ts.ShowMsg("Ellen: Olá Eleonora!");
        yield return Ts.ShowMsg("Ellen: Vamos direto ao ponto...");
        yield return Ts.ShowMsg("Ellen: Um homem foi encontrado dentro de uma floresta");
        yield return Ts.ShowMsg("Ellen: E os nossos informantes suspeitam que possa ter sido algo relacionado ao sobrenatural.");
        yield return Ts.ShowMsg("Ellen: Não temos nenhuma informação do caso, aconteceu esta manhã.");
        yield return Ts.ShowMsg("Ellen: A sua missão é investigar. E se tiver algum indício de ação sobrenatural, deter.");
        yield return Ts.ShowMsg("Ellen: Ninguém pode ficar sabendo, e muito menos ver nada sobrenatural,");
        yield return Ts.ShowMsg("Ellen: Isso só causaria um enfraquecimento maior da barreira.");
        yield return Ts.ShowMsg("Ellen: Antes de começar a investigação, certifique-se de tirar a polícia do local.");
        yield return Ts.ShowMsg("Ellen: Como a polícia já foi acionada. Preparamos essa maleta pra você.");
        yield return Ts.ShowMsg("Ellen: Aí dentro tem um distintivo");
        yield return Ts.ShowMsg("Ellen: Da Policia Federal.");
        yield return Ts.ShowMsg("Ellen: Boa sorte.");
        Caixa.enabled = true;
        Porta.enabled = true;
        Ts.tempoDeFala = 1f;
        

        
    }
}
