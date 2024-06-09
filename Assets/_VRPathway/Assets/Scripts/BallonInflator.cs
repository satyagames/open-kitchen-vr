using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallonInflator : XRGrabInteractable
{
    [Header("Balloon Data")]
    public Transform attachPoint;
    public Balloon ballonPrefab;
    
    
    private Balloon m_BallonInstance;
    private XRBaseController m_Controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        m_BallonInstance = Instantiate(ballonPrefab, attachPoint);
        var controllerInteractor = args.interactorObject as XRBaseControllerInteractor;
        m_Controller = controllerInteractor.xrController;


        m_Controller.SendHapticImpulse(1, 0.5f); // add this line
        Debug.Log(m_Controller); // or add this line


    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        Destroy(m_BallonInstance.gameObject);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected && m_Controller != null) // add this if-statement
        {
            m_BallonInstance.transform.localScale = Vector3.one * Mathf.Lerp(1.0f, 4.0f,
            m_Controller.activateInteractionState.value); // add this line
        }
    }
    
}
