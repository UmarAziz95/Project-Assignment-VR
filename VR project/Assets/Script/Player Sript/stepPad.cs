using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class stepPad : MonoBehaviour {

    // Use this for initialization
    float timer;

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
        if (!enter)
        {
            timer += Time.deltaTime;
        }

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
        endgamepanel.transform.Find("Timer").GetComponent<Text>().text = "Time Complete: " + timer.ToString("F");
        PausePanel.IsOn = endgamepanel.activeSelf;
        XRSettings.enabled = !XRSettings.isDeviceActive;
    }


}
