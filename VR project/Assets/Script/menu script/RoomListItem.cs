using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;
using UnityEngine.XR;
public class RoomListItem : MonoBehaviour
{
    
    [SerializeField] LobbyButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    public int thisIndex = 0;
    [SerializeField]
    GameObject InitialCanvas;
    [SerializeField]
    GameObject OnclickButton;
  //  [SerializeField]
   // GameObject gvr;


    public delegate void JoinRoomDelegate(MatchInfoSnapshot _match);
    private JoinRoomDelegate joinRoomCallback;

    [SerializeField]
    private Text roomNameText;

    private MatchInfoSnapshot match;

    public void Setup(MatchInfoSnapshot _match, JoinRoomDelegate _joinRoomCallback, int count)
    {
        match = _match;
        joinRoomCallback = _joinRoomCallback;
        thisIndex = count;
        roomNameText.text = match.name + "  (" + match.currentSize + "/" + match.maxSize + ")";
    }

    public void JoinRoom()
    {
        joinRoomCallback.Invoke(match);
    }

    private void Start()
    {
       
        menuButtonController = transform.parent.parent.parent.parent.gameObject.GetComponent<LobbyButtonController>();
        InitialCanvas = transform.parent.parent.parent.parent.parent.gameObject;
    }

    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetButtonDown("Submit"))
            {
                animator.SetBool("pressed", true);
                OnclickButton.GetComponent<Button>().onClick.Invoke();
                InitialCanvas.SetActive(!InitialCanvas.activeSelf);
                XRSettings.enabled = true;
               // gvr.SetActive(!gvr.activeSelf);

            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }


        
    }
}
