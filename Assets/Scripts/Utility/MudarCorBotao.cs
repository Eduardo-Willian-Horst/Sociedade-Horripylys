using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MudarCorTexto : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI texto;
    public Color corHover = new Color(0.4f, 0.4f, 0.4f);  // A cor que você quer quando o mouse passa por cima

    private Color corOriginal;  // A cor original do TextMeshPro

    void Start()
    {
        // Salve a cor original
        corOriginal = texto.color;
    }

    // Chamado quando o mouse entra na área do botão
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Altere a cor do TextMeshPro para a corHover quando o mouse passa por cima
        texto.color = corHover;
    }

    // Chamado quando o mouse sai da área do botão
    public void OnPointerExit(PointerEventData eventData)
    {
        // Restaure a cor original do TextMeshPro quando o mouse sai
        texto.color = corOriginal;
    }
}
