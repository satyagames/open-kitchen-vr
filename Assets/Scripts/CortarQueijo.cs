using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CortarQueijo : MonoBehaviour
{
    public Vector3 pontoEntrada;
    public Vector3 pontoSaida;
    public float comprimentoCorte;
    public GameObject queijoPrefab;
    public int contador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Faca"))
        {
            pontoEntrada = other.transform.position;
            pontoSaida = other.transform.position;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Faca"))
        {
            pontoSaida = other.transform.position;

            if((pontoEntrada.y - pontoSaida.y) >= comprimentoCorte )
            {
                Instantiate(queijoPrefab, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), transform.rotation);
                //transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y , transform.localScale.z - (transform.localScale.z/3));
                contador += 1;
                pontoEntrada = new Vector3(0, 0, 0);
                pontoSaida = new Vector3(0, 0, 0);

                
            }

        }

        if (contador > 2)
        {
            OnDestroy();
        }
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
