using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{


    public GameObject buttonFlipperL;
    public GameObject buttonFlipperR;
    public GameObject buttonPlunger;



    // Start is called before the first frame update
    void Start()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer: // Windows
            case RuntimePlatform.LinuxPlayer:   // Linux
            case RuntimePlatform.OSXPlayer:     // Mac

                Computer();
                break;


            case RuntimePlatform.WindowsEditor: // Test
            case RuntimePlatform.Android:       // Android
            case RuntimePlatform.IPhonePlayer:  // IOS
                Mobile();
                break;
        }
    }

    private void Computer()
    {
        // Show touchable buttons
        buttonFlipperL.SetActive(false);
        buttonFlipperR.SetActive(false);
        buttonPlunger.SetActive(false);

        Debug.Log("[!] Screen: Computer (default)");
    }

    private void Mobile() {

        // Camera ajdustment
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -13.6f);
    
        // Show touchable buttons
        buttonFlipperL.SetActive(true);
        buttonFlipperR.SetActive(true);
        buttonPlunger.SetActive(true);

        // UI text adjustments



        Debug.Log("[!] Screen: Mobile");
    }

}
