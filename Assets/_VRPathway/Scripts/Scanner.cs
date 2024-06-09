using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; //add this line
using TMPro;

public class Scanner : XRGrabInteractable
{

    [Header("Scanner Data")]
    public Animator animator;
    public LineRenderer scannerLaser;
    public TextMeshProUGUI objectName;
    public TextMeshProUGUI objectPosition;
    public Renderer malha;

    // Refer�ncia ao material "red"
    public Material redMaterial;

    // Refer�ncia ao material original
    public Material originalMaterial;

    // Armazena o objeto atualmente colidido com o raio
    public GameObject currentCollidedObject;
    public GameObject lastCollidedObject;





    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake(); // add this line to call the base method
        ScannerActivated(false);
       

    }

    void Start()
    {
        {
            //animator.SetBool("Opened", true); // add this line of code
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        animator.SetBool("Opened", true); //cut and paste this line from Start()

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        animator.SetBool("Opened", false);
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        ScannerActivated(true);
        //ScanForObjects();
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
        ScannerActivated(false);
       
    }

    private void ScannerActivated(bool isActivated)
    {
        scannerLaser.gameObject.SetActive(isActivated);
        //objectName.gameObject.SetActive(isActivated);
        //objectPosition.gameObject.SetActive(isActivated);
    }


    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (scannerLaser.gameObject.activeSelf) // new if-statement
        {
            ScanForObjects(); // new line
        }

        else
        {
            objectName.text = "Ready to scan";
            objectPosition.text = "Ready to scan";
            Debug.Log("Passou no else");

            if (currentCollidedObject != null)
            {
                Debug.Log("Passou no if");
                malha = currentCollidedObject.GetComponent<Renderer>();
                malha.material = originalMaterial;
            }
            
        }


    }

    public void ScanForObjects()
    {
        RaycastHit hit;
        

        Vector3 worldHit = scannerLaser.transform.position + scannerLaser.transform.forward * 1000.0f; // new line

        if (Physics.Raycast(scannerLaser.transform.position, scannerLaser.transform.forward, out hit))
        {


            worldHit = hit.point;

            objectName.text = "Name: " + "\n" + (hit.collider.name) + "\n" + "\n" + "Tag:" + "\n" + hit.collider.tag;
            objectPosition.text = "Position: " + (hit.collider.transform.position.ToString());
            // malha = hit.collider.GetComponent<Renderer>();
            //originalMaterial = malha.material;

            

                if (hit.collider.gameObject != currentCollidedObject && hit.collider.gameObject.GetComponent<Renderer>() != null)
                {
                    // Se for um novo objeto, troca o material do objeto anterior para o original
                    if (currentCollidedObject != null || currentCollidedObject != lastCollidedObject)
                    {

                    if (currentCollidedObject != null)
                        { 
                            malha = currentCollidedObject.GetComponent<Renderer>();
                            malha.material = originalMaterial;
                        }
                    }

                    // Armazena o objeto atual
                    currentCollidedObject = hit.collider.gameObject;
                    malha = currentCollidedObject.GetComponent<Renderer>();
                    originalMaterial = malha.material;
                    lastCollidedObject = currentCollidedObject;


                    // Troca o material do objeto atual para o material "red"
                    Renderer currentRenderer = currentCollidedObject.GetComponent<Renderer>();
                    currentRenderer.material = redMaterial;

                }

                else if (hit.collider.gameObject == currentCollidedObject)
                {

                    if (currentCollidedObject.GetComponent<Renderer>() != null)
                    {
                        Renderer currentRenderer = currentCollidedObject.GetComponent<Renderer>();
                        currentRenderer.material = redMaterial;
                    }
                }
            }
        
        else
        {
            // Se o raio n�o colidir com nenhum objeto, verifica se o objeto anterior ainda est� sendo colidido
            if (currentCollidedObject != null && currentCollidedObject.GetComponent<Renderer>() != null)
            {
                // Se n�o estiver mais colidindo, troca o material para o original
                malha = currentCollidedObject.GetComponent<Renderer>();
                originalMaterial = malha.material;
                currentCollidedObject = null;
            }
        }

        
        
        scannerLaser.SetPosition(1, scannerLaser.transform.InverseTransformPoint(worldHit)); // new line
    }
}
