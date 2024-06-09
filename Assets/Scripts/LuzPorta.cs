using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzPorta : MonoBehaviour
{
    public Light luzInterna;
    public GameObject ancoraDaPorta;
    public GameObject luzGameObject;
    public Vector3 posicaoInicial;
    public Vector3 posicaoAtual;


    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = ancoraDaPorta.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        posicaoAtual = ancoraDaPorta.transform.position;

        if (posicaoAtual.x >= posicaoInicial.x - 0.001f)
        {
            luzGameObject.GetComponent<ChangeMaterial>().SetOtherMaterial();
            luzInterna.enabled = false;

        }

        else
        {

            luzGameObject.GetComponent<ChangeMaterial>().SetOriginalMaterial();
            luzInterna.enabled = true;

        }



    }
}
