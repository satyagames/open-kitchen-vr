using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumPadButton : MonoBehaviour
{
    public GameObject thisButton;
    public GameObject terminalScreen;
    public Transform numCanvas;
    public Transform numText;
    public string numString;

    // Start is called before the first frame update
    void Start()
    {
        thisButton = this.gameObject;
        numCanvas = thisButton.transform.Find("Canvas");
        numText = numCanvas.transform.Find("Text (TMP)");
        numString = numText.GetComponent<TextMeshProUGUI>().text;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void digitar()
    {
        if (terminalScreen.GetComponent<NumPadScan>().waitingCorret == true)
        {
            terminalScreen.GetComponent<NumPadScan>().screenText.text += numString;
            terminalScreen.GetComponent<NumPadScan>().typedPassword += numString;
        }
    }

}
