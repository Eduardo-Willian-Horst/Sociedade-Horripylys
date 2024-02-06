using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Talk_TMP;
    private float fadeDuration = 1f;
    private bool isTalking = false;
    public float tempoDeFala = 1f;

    public void SendMsg(string texto){
        if(isTalking) return;
        isTalking = true;
        Talk_TMP.text = texto;
        StartCoroutine(Msg());
        
    }
    public IEnumerator ShowMsg(string texto){
        isTalking = true;
        Talk_TMP.text = texto;
        yield return Msg();
    }

    private IEnumerator Msg(){
        yield return FadeIn();
        yield return new WaitForSeconds(tempoDeFala);
        yield return FadeOut();
        isTalking = false;
    }

    private IEnumerator FadeOut()
    {
        // Inicia a opacidade em 1 (totalmente visível)
        float alpha = 1f;

        // Tempo decorrido
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Calcula a nova opacidade com base no tempo decorrido
            alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            // Aplica a opacidade ao componente TextMeshPro
            Talk_TMP.color = new Color(Talk_TMP.color.r, Talk_TMP.color.g, Talk_TMP.color.b, alpha);

            // Aguarda um quadro
            yield return null;

            // Atualiza o tempo decorrido
            elapsedTime += Time.deltaTime;
        }

        // Garante que a opacidade seja definida como 0 no final
        Talk_TMP.color = new Color(Talk_TMP.color.r, Talk_TMP.color.g, Talk_TMP.color.b, 0f);
    }

    private IEnumerator FadeIn()
    {
        // Inicia a opacidade em 1 (totalmente visível)
        float alpha = 0f;

        // Tempo decorrido
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Calcula a nova opacidade com base no tempo decorrido
            alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            // Aplica a opacidade ao componente TextMeshPro
            Talk_TMP.color = new Color(Talk_TMP.color.r, Talk_TMP.color.g, Talk_TMP.color.b, alpha);

            // Aguarda um quadro
            yield return null;

            // Atualiza o tempo decorrido
            elapsedTime += Time.deltaTime;
        }

        // Garante que a opacidade seja definida como 0 no final
        Talk_TMP.color = new Color(Talk_TMP.color.r, Talk_TMP.color.g, Talk_TMP.color.b, 1f);
    }
}
