using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    public Transform m_KeycardTransform;
    public Vector3 m_HoverEntry;
    public bool m_SwipIsValid;
    public GameObject VisualLockToHide;
    public Vector3 entryToExit;
    public float dot;
    public float AllowedUprightErrorRange;
    public GameObject redLight;
    public GameObject greenLight;
    public AudioSource openKey;
    public GameObject HandleToEnable;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AllowedUprightErrorRange = 0.01f;
        //HandleToEnable.GetComponent<DoorHandler>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_KeycardTransform != null)
        {
            Vector3 keycardUp = m_KeycardTransform.forward;
            dot = Vector3.Dot(keycardUp, Vector3.up);

            if (dot < 1 - AllowedUprightErrorRange)
            {
                m_SwipIsValid = false;
            }
        }
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        m_KeycardTransform = args.interactableObject.transform;
        m_HoverEntry = m_KeycardTransform.position;
        m_SwipIsValid = true;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        entryToExit = m_KeycardTransform.position - m_HoverEntry;

        if (m_SwipIsValid && entryToExit.y < -0.15f)
        {
            VisualLockToHide.gameObject.SetActive(false);
            redLight.GetComponent<ChangeMaterial>().SetOtherMaterial();
            greenLight.GetComponent<ChangeMaterial>().SetOtherMaterial();
            HandleToEnable.GetComponent<DoorHandler>().doorOpened = true;
            openKey.Play();
        }

        m_KeycardTransform = null;
    }

}
