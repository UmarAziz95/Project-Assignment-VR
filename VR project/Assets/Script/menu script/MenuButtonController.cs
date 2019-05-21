using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;

    [SerializeField]
    GameObject InitialCanvas;

    [SerializeField]
    GameObject NavigateCanvas;


    void Start () {
        DisableVR();
        audioSource = GetComponent<AudioSource>();

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }

       
            if (Input.GetAxis("Fire2") == 1)
            {

            InitialCanvas.SetActive(!InitialCanvas.activeSelf);
            NavigateCanvas.SetActive(!NavigateCanvas.activeSelf);
        }

        
    }

    IEnumerator LoadDevice(string newDevice, bool enable)
    {
       // XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = enable;
    }

    void EnableVR()
    {
        StartCoroutine(LoadDevice("daydream", true));
    }

    void DisableVR()
    {
        StartCoroutine(LoadDevice("", false));
    }


}
