using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNatureSound : MonoBehaviour
{
    public AudioSource natureSounds;
    public GameObject janela1;
    public GameObject janela2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        natureSounds.volume = 0.2f + janela1.GetComponent<DoorHandler>().halfSound + janela2.GetComponent<DoorHandler>().halfSound;
    }
}
