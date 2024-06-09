using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BurguerMachineButton : MonoBehaviour
{
    public GameObject machine;
    public Animator tampaAnimator;
    public float tempoPreparo;
    public bool doneProduction;
    public GameObject fumaca;
    public GameObject posicaoLanche;
    public GameObject[] lanchePrefabs;
    public AudioSource startingPrepair;
    public AudioSource stopPrepair;
    public float finalAudioDelay; 
    public bool finalAudioPlay;


    // Start is called before the first frame update
    void Start()
    {
        doneProduction = true;
        finalAudioPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tempoPreparo > 0 && doneProduction == false)
        {
            tempoPreparo -= 1 * (Time.deltaTime);

        }

        else if (tempoPreparo <= 0 && doneProduction == false)
        {
            tampaAnimator.SetBool("Preparar", false);
            doneProduction = true;
            fumaca.SetActive(true);
            
            machine.GetComponent<BuguerMachine>().destruirConteudo();
            finalAudioPlay = true;
            Instantiate(lanchePrefabs[GetComponent<BuguerMachine>().lanchePrefabIndex], posicaoLanche.transform.position, posicaoLanche.transform.rotation);
            

        }

        if(finalAudioPlay == true)
        {
            finalAudioDelay += 1 * Time.deltaTime;

            if(finalAudioDelay >= 1.0f)
            {
                startingPrepair.Stop();
                stopPrepair.Play();
                finalAudioDelay = 0;
                finalAudioPlay = false;
            }
        }

        
    }

    public void ativaPreparo()
    {
        if (machine.GetComponent<BuguerMachine>().pronto == true)
        {
            tempoPreparo = 9;
            doneProduction = false;
            tampaAnimator.SetBool("Preparar", true);
            fumaca.SetActive(false);
            startingPrepair.Play();
        }

    }

    

    

}
