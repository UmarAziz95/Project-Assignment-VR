using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject endgamepanel;
    // Start is called before the first frame update
    void Start()
    {
        PausePanel.IsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown)
        if (Input.GetButtonDown("start"))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PausePanel.IsOn = pauseMenu.activeSelf;
        XRSettings.enabled = !XRSettings.isDeviceActive;
    }

    public void endgame()
    {
        endgamepanel.SetActive(true);
        PausePanel.IsOn = pauseMenu.activeSelf;
        XRSettings.enabled = !XRSettings.isDeviceActive;
    }

}
