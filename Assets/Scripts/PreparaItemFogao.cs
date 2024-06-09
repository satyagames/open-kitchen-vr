using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparaItemFogao : MonoBehaviour
{
    public float tempoPreparo;
    public float tempoCorrido;
    public bool countDownIsRunning;
    public GameObject particulasPreparacao;
    public BoxCollider componenteBoxCollider;
    public AudioSource audioPreparo;


    // Start is called before the first frame update
    void Start()
    {
        countDownIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDownIsRunning == true)
        {
            tempoCorrido += 1 * Time.deltaTime;

            if (tempoCorrido >= tempoPreparo)
            {
                this.GetComponent<ChangeMaterial>().SetOtherMaterial();
                tag = "Burger";
                countDownIsRunning = false;
                
            }
        }

        if (particulasPreparacao != null && componenteBoxCollider != null)

        {
            if (!componenteBoxCollider.enabled)

            {
                countDownIsRunning = false;
                componenteBoxCollider = null;
                particulasPreparacao.SetActive(false);
                audioPreparo.Stop();

            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Fogo") && gameObject.GetComponent<Rigidbody>().isKinematic == true)
        { 
            countDownIsRunning = true;
            particulasPreparacao.SetActive(true);
            componenteBoxCollider = other.GetComponent<BoxCollider>();
            audioPreparo.Play();
        }

        if (other == null)
        {
            countDownIsRunning = false;
            particulasPreparacao.SetActive(false);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fogo"))
        {
            countDownIsRunning = false;
            particulasPreparacao.SetActive(false);
            audioPreparo.Stop();
        }
    }

    
}
