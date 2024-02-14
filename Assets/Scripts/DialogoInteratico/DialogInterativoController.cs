using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogInterativoController : MonoBehaviour
{
    
    [SerializeField] private TalkSystem Ts;
    [SerializeField] private Canvas canvas_respostas, canvas_conversa;
    [SerializeField] private TextMeshProUGUI btn_1, btn_2;
    [SerializeField] private CarMovemente CarStart;
    [SerializeField] private GameObject Jocemar;
    public GameObject cameraPrincipal;
    public Camera segundaCamera;
    private int resposta;
    

    public void StartTalk(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canvas_conversa.gameObject.SetActive(true);
        canvas_respostas.gameObject.SetActive(false);
        StartCoroutine(Talk_01());
    }

    
    IEnumerator Talk_01()
    {
        yield return new WaitForSeconds(1f);
        yield return Ts.ShowMsg("???: QUEM É VOCÊ?");
        yield return Ts.ShowMsg("???: O QUE VOCÊ ESTÁ FAZENDO AQUI??");
        btn_1.text = "Me chamo Elleonora.";
        btn_2.text = "Polícia Federal. *Mostra o distintivo*";
        yield return EsperaPergunta();
        if (resposta == 1)
        {
            yield return Talk_NameDirect();
        }
        else
        {
            yield return Talk_ShowDistintive();
        }
    }

    IEnumerator Talk_NameDirect()
    {
        yield return Ts.ShowMsg("???: Não conheço nenhuma Elleonora.");
        yield return Ts.ShowMsg("???: O que está fazendo aqui? Isso é uma cena de crime.");
        btn_1.text = "*Mostrar o distintivo*";
        btn_2.text = "Sou do Jornal da Cidade. E vim tirar algumas fotos";
        yield return EsperaPergunta();
        if (resposta == 1)
        {
            yield return Talk_ShowDistintive();
        }
        else
        {
            yield return Talk_Jornal();
        }
    }

    IEnumerator Talk_Jornal()
    {
        yield return Ts.ShowMsg("???: Como você soube desse caso?");
        yield return Ts.ShowMsg("???: Não divulgamos nada.");
        btn_1.text = "Estávamos passando por aqui e vimos o carro. Então, pedi para descer e ver se tem alguma matéria aqui!";
        btn_2.text = "Temos nossos contatos.";
        yield return EsperaPergunta();
        if (resposta == 1)
        {
            yield return Talk_aboutPhotos();
        }
        else
        {
            yield return Talk_aboutPhotos();
        }
    }

    IEnumerator Talk_aboutPhotos()
    {
        yield return Ts.ShowMsg("???: Bom. Eu sou o oficial Jocemar");
        yield return Ts.ShowMsg("Jocemar: Bom. Até agora não temos informações sobre o que aconteceu.");
        yield return Ts.ShowMsg("Jocemar: Você me faz um favor? Meu telefone está sem bateria.");
        yield return Ts.ShowMsg("Jocemar: Você pode ficar aqui enquanto eu busco algumas coisas na delegacia?");
        yield return Ts.ShowMsg("Jocemar: É rapidinho. A delegacia fica perto, mas tem que ficar alguém aqui.");
        yield return Ts.ShowMsg("Jocemar: E quem melhor do que uma bela moça como você?");
        yield return Ts.ShowMsg("Jocemar: Pode tirar as fotos que quiser.");
        btn_1.text = "Ok.";
        btn_2.text = "Claro. Obrigada.";
        yield return EsperaPergunta();
        if (resposta == 1)
        {
            yield return Talk_AssumirOCaso();
        }
        else
        {
            yield return Talk_AssumirOCaso();
        }
    }

    IEnumerator Talk_ShowDistintive()
    {
        yield return Ts.ShowMsg("???: Ah! Me desculpe.");
        yield return Ts.ShowMsg("???: Não achei que mandariam a PF para esse caso.");
        yield return Ts.ShowMsg("???: Me chamo Jocemar");
        yield return Ts.ShowMsg("Jocemar: Me desculpe. Não dormi direito hoje.");
        btn_1.text = "Tudo bem. O que sabemos até agora?";
        btn_2.text = "Pode ir descansar. Eu assumo daqui.";
        yield return EsperaPergunta();
        if (resposta == 1)
        {
            yield return Talk_AboutCase();
        }
        else
        {
            yield return Talk_AssumirOCaso();
        }
    }

    IEnumerator Talk_AboutCase()
    {
        yield return Ts.ShowMsg("Jocemar: Não consegui encontrar nada importante até o momento.");
        yield return Ts.ShowMsg("Jocemar: Mas acho que não tenho mais condições de averiguar algo estranho como esse caso.");
        yield return Ts.ShowMsg("Jocemar: Preciso mesmo descansar.");
        btn_1.text = "Obrigado. Pode ir descansar.";
        btn_2.text = "Pode ir descansar. Eu assumo daqui.";
        yield return EsperaPergunta();
        if (resposta == 1)
        {
            yield return Talk_AssumirOCaso();
        }
        else
        {
            yield return Talk_AssumirOCaso();
        }
    }

    IEnumerator Talk_AssumirOCaso()
    {
        yield return Ts.ShowMsg("Jocemar: Obrigado! Se precisar de algo, pode ligar para a delegacia.");
        yield return new WaitForSeconds(1f);
        segundaCamera.gameObject.SetActive(false);
        cameraPrincipal.SetActive(true);
        CarStart.Inicia = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(Jocemar);
    }




    IEnumerator EsperaPergunta(){
        canvas_conversa.gameObject.SetActive(false);
        canvas_respostas.gameObject.SetActive(true);
        resposta = 0;
        yield return new WaitUntil(() => resposta != 0);
        canvas_conversa.gameObject.SetActive(true);
        canvas_respostas.gameObject.SetActive(false);
        yield return null;
        
        
    }

    public void OnclickBtn_01(){
        resposta = 1;
    }
    public void OnclickBtn_02(){
        resposta = 2;
    }

}
