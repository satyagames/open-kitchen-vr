using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumPadScan : MonoBehaviour
{
    public bool waitingCorret;
    public float tempo;
    public GameObject fundoPainel;
    public GameObject cartao;
    public GameObject pontoSaida;
    public TextMeshProUGUI screenText;
    public TextMeshProUGUI cartaoPassword;
    public AudioSource printingCard;
    public string recordedPassword;
    public string typedPassword;

    // Start is called before the first frame update
    void Start()
    {
        waitingCorret = true;
        screenText.text = "Insert password\n\n";
        cartaoPassword.text = "Password\n\n";

        var contador = 1;
        while(contador <= 4)
        {
            var texto = Random.Range(0, 10);
            cartaoPassword.text += texto.ToString();
            recordedPassword += texto.ToString();
            contador += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (typedPassword.Length == 4 && waitingCorret == true)
        {
            tempo = 2.2f;
            if (typedPassword == recordedPassword)
            {
                screenText.text = "Access Granted";
                fundoPainel.GetComponent<CanvasRenderer>().SetColor(Color.green);
                waitingCorret = false;
                printingCard.Play();
                
                
            
            }
            else
            {
                typedPassword = "";
                screenText.text = "Incorret password\n" + "try again\n\n";
                fundoPainel.GetComponent<CanvasRenderer>().SetColor(Color.yellow);
            }

            
        }
        
        else if (typedPassword.Length > 4)

        {
            typedPassword = "";
            screenText.text = "Incorret password\n" + "try again\n\n";
            fundoPainel.GetComponent<CanvasRenderer>().SetColor(Color.yellow);

        }

        else if(waitingCorret == false && tempo >= 0)
        {
            tempo -= Time.deltaTime;
            if (tempo < 0)
            {
                cartao.transform.position = pontoSaida.transform.position;
                cartao.SetActive(true);
            }
        }

    }

   

    
}
