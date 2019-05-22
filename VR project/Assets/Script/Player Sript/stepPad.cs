using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class stepPad : MonoBehaviour {

    // Use this for initialization

    public bool enter = false;
    [SerializeField]
    GameObject endgamepanel;

    void Start()
    {
        Debug.Log("endgame");
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            endgame();        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enter = true;
    }

    public void endgame()
    {
        endgamepanel.SetActive(true);
        PausePanel.IsOn = endgamepanel.activeSelf;
        XRSettings.enabled = !XRSettings.isDeviceActive;
    }


}
