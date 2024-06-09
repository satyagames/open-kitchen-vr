using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandler : XRBaseInteractable
{

    public bool openToRight;
    public GameObject door;
    public Vector3 doorStartPosition;
    public Vector3 doorCurrentPosition;
    public float doorRunninLeght;
    public float doorPathLenght; //Se a porta abrir para a direita, usar negativo. Se abrir pra esquerda positivo
    public bool doorOpened;
    public float multiplicador;
    public Transform DraggedTransform; // set to parent door object
    public float halfSound;
    

    
    // Start is called before the first frame update
    protected void Start()
    {
        
        doorStartPosition = door.transform.position;
        
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        doorCurrentPosition = door.transform.position;
        halfSound = 0.4f * (doorRunninLeght / doorPathLenght);
        if(halfSound > 0.4f)
        {
            halfSound = 0.4f;
        }

        if (isSelected && doorOpened == true)
        {
            var interactorTransform = firstInteractorSelecting.GetAttachTransform(this);
            if (openToRight == true)
            {
                multiplicador = -1;
            }
            else
            {
                multiplicador = 1;
            }

            DraggedTransform.transform.position = new Vector3(interactorTransform.position.x, DraggedTransform.transform.position.y, DraggedTransform.transform.position.z);
            doorCurrentPosition = DraggedTransform.transform.position;
            doorRunninLeght = multiplicador * (doorStartPosition.x - doorCurrentPosition.x);

            if (doorRunninLeght < 0f)
            {
                DraggedTransform.transform.position = new Vector3(doorStartPosition.x, doorStartPosition.y, doorStartPosition.z);
                
            }

            else if (doorRunninLeght >= doorPathLenght)
            {
                DraggedTransform.transform.position = new Vector3(doorStartPosition.x  - (doorPathLenght * multiplicador), doorStartPosition.y, doorStartPosition.z);
            }
            // calculate dot product of selfToInteractor onto drag directiony
            // calculate speed based the dot product
            // move door based on speed using MoveTowards
        }

        else
        {
            doorRunninLeght = multiplicador * (doorStartPosition.x - doorCurrentPosition.x);
        }

        
    }
}
