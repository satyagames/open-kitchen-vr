using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneToHamburguer : MonoBehaviour
{

    public int contador;
    public GameObject hamburguer;
    public bool pausaCollisor;
    public float waitNextContact;
    public Vector3 posicaoOriginal;
    public AudioSource somMartelo;

    // Start is called before the first frame update
    void Start()
    {
        pausaCollisor = false;
        waitNextContact = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(pausaCollisor == true)
        {
            transform.position = new Vector3(posicaoOriginal.x, posicaoOriginal.y, posicaoOriginal.z);
            waitNextContact -= 1 * Time.deltaTime;

            if(waitNextContact <= 0f)
            {
                pausaCollisor = false;
                waitNextContact = 0.5f;
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        
        

        if(other.CompareTag("Martelo") & pausaCollisor == false)
        {
            posicaoOriginal = transform.position;
            contador += 1;
            transform.localScale = new Vector3(transform.localScale.x - 0.03f, transform.localScale.y - 0.02f, transform.localScale.z - 0.03f);
            pausaCollisor = true;
            somMartelo.Play();
        
            if(contador == 6)
                {
                somMartelo.Play();
                Instantiate(hamburguer, transform.position, transform.rotation);
                OnDestroy();
                }

        }
    }

    public void OnDestroy()
    {

        Destroy(gameObject);
    }
}
