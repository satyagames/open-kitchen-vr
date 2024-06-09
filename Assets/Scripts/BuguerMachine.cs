using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class BuguerMachine : MonoBehaviour
{

    public int bread1Check;
    public int cheeseCheck;
    public int hambuguerCheck;
    public int bread2Check;
    public int otherCheck;
    public GameObject panelLights;
    public GameObject bread1Light;
    public GameObject CheeseLight;
    public GameObject hamburguerLight;
    public GameObject bread2Light;
    public GameObject botaoAtivar;
    public GameObject alertLight;
    public bool pronto;
    public int lanchePrefabIndex;
    public BoxCollider box;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        checkItems();
        buttonAtivo();


    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TopBread"))
        {
            bread1Check += 1;
            

        }

        else if (other.CompareTag("Cheese"))
        {
            cheeseCheck += 1;
            

        }

        else if (other.CompareTag("Burger"))
        {
            hambuguerCheck += 1;
            

        }

        else if (other.CompareTag("LowBread"))
        {
            bread2Check += 1;
            

        }

        else
        {
            otherCheck += 1;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("TopBread"))
        {
            bread1Check -= 1;
            

        }

        else if (other.CompareTag("Cheese"))
        {
            cheeseCheck -= 1;
            

        }

        else if (other.CompareTag("Burger"))
        {
            hambuguerCheck -= 1;
            

        }

        else if (other.CompareTag("LowBread"))
        {
            bread2Check -= 1;
            

        }

        else
        {
            otherCheck -= 1;
        }

    }

    public void checkItems()
    {

        if (otherCheck > 0 || GetComponent<BurguerMachineButton>().doneProduction == false)
        {
            Debug.Log("Passou na checagem de quantidade");
            panelLights.SetActive(false);
            alertLight.SetActive(true);

        }

        else
        {
            Debug.Log("Não tem itens diferentes");
            panelLights.SetActive(true);
            alertLight.SetActive(false);
        }


        if (bread1Check > 0)
        {
            bread1Light.GetComponent<ChangeMaterial>().SetOtherMaterial();
        }

        else
        {
            bread1Light.GetComponent<ChangeMaterial>().SetOriginalMaterial();
        }

        if (cheeseCheck > 0)
        {
            CheeseLight.GetComponent<ChangeMaterial>().SetOtherMaterial();
        }

        else
        {
            CheeseLight.GetComponent<ChangeMaterial>().SetOriginalMaterial();
        }

        if (hambuguerCheck > 0)
        {
            hamburguerLight.GetComponent<ChangeMaterial>().SetOtherMaterial();
        }

        else
        {
            hamburguerLight.GetComponent<ChangeMaterial>().SetOriginalMaterial();
        }

        if (bread2Check > 0)
        {
            bread2Light.GetComponent<ChangeMaterial>().SetOtherMaterial();
        }

        else
        {
            bread2Light.GetComponent<ChangeMaterial>().SetOriginalMaterial();
        }

        
    }

    public void buttonAtivo()
    {
        if (bread1Check > 0 && cheeseCheck > 0 && hambuguerCheck > 0 && bread2Check > 0 && otherCheck == 0)
        {
            botaoAtivar.GetComponent<ChangeMaterial>().SetOtherMaterial();
            pronto = true;
            lanchePrefabIndex = 0;
        }

        else if (bread1Check > 0  && hambuguerCheck > 0 && bread2Check > 0 && otherCheck == 0)
        {
            botaoAtivar.GetComponent<ChangeMaterial>().SetOtherMaterial();
            pronto = true;
            lanchePrefabIndex = 1;
        }

        else
        {
            botaoAtivar.GetComponent<ChangeMaterial>().SetOriginalMaterial();
            pronto = false;
            lanchePrefabIndex = -1;

        }
    }

    public void destruirConteudo()
    {
        Collider[] colliders = Physics.OverlapBox(box.bounds.center, box.bounds.extents, box.transform.rotation);
        foreach (Collider collider in colliders)
        {

            if (collider.CompareTag("Burger") || collider.CompareTag("TopBread") || 
                collider.CompareTag("LowBread") || collider.CompareTag("Cheese"))
            {
                Destroy(collider.gameObject);
                bread1Check = 0;
                bread2Check = 0;
                hambuguerCheck = 0;
                cheeseCheck = 0;

            }

        }

        
    }
}
