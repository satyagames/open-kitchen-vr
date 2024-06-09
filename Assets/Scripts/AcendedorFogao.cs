using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Unity.XRContent.Interaction
{
    public class AcendedorFogao : XRKnob
    {
        public GameObject bocaFogaoCollider;
        public GameObject bocaFogao;
        public float knobCurrentValue;
        public float lastState;

        // Start is called before the first frame update
        void Start()
        {
            bocaFogaoCollider.GetComponent<BoxCollider>().enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

            knobCurrentValue = this.Value;

            if (knobCurrentValue != lastState)
            {
                changingStatus();
            }

        }

        public void changingStatus()
        {


            if (knobCurrentValue == 1)
            {
                bocaFogao.SetActive(false);
                lastState = knobCurrentValue;
                bocaFogaoCollider.GetComponent<BoxCollider>().enabled = false;
            }

            else if (knobCurrentValue == 0)
            {
                bocaFogao.SetActive(true);
                lastState = knobCurrentValue;
                bocaFogaoCollider.GetComponent<BoxCollider>().enabled = true;
            }
        }

    }
}
