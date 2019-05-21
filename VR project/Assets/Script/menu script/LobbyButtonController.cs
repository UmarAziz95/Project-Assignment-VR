using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LobbyButtonController : MonoBehaviour
{
    // Use this for initialization
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] JoinGame joingame;
    public AudioSource audioSource;
    [SerializeField]
    GameObject InitialCanvas;
    [SerializeField]
    GameObject NavigateCanvas;
    //[SerializeField]
    //GameObject OnclickButton;

    void Start()
    {
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
                    if (index < joingame.lobbyCount)
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
                        index = joingame.lobbyCount;
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
}
