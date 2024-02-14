using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LifeTMP, PsicoTMP;
    [SerializeField] private int Life;
    [SerializeField] private int Psico;
    void Start()
    {
        Life = PlayerPrefs.GetInt("LifePoints");
        Psico = PlayerPrefs.GetInt("PsicoPoints");
        AtualizaStats();
    }

    public void PlayerTakeDamage(int Dano){
        Life -= Dano;
        AtualizaStats();
    }

    private void AtualizaStats(){
        LifeTMP.text = "Vida: " + Life.ToString();
        PsicoTMP.text = "Psicológico: " + Psico.ToString();
    }

    
}
