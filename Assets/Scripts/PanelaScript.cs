using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PanelaScript : XRGrabInteractable
{

    public XRSocketInteractor foodSocket;
    public Transform panelaTransform;
    public float dot;
    public float AllowedUprightErrorRange;

    // Start is called before the first frame update
    protected void Start()
    {
        
        AllowedUprightErrorRange = 0.80f;
    }

    private void Update()
    {
        if (panelaTransform != null)
        {
            Vector3 keycardUp = panelaTransform.up;
            dot = Vector3.Dot(keycardUp, Vector3.up);

            if (dot < 1 - AllowedUprightErrorRange)
            {
                foodSocket.socketActive = false;
            }

            else
            {
                foodSocket.socketActive = true;
            }
        }
    }


   
}
