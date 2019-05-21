using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    [SerializeField]
    GameObject OnclickButton;


    [SerializeField]
    GameObject MainCanvas;
    // [SerializeField]
    // GameObject gamelevel;


    private void Start()
    {
     //  MainCanvas = GameObject.Find("Canvas");

    }

    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetButtonDown("Submit"))
            {
                animator.SetBool("pressed", true);
                //  yield return new WaitForSeconds(2);
                OnclickButton.GetComponent<Button>().onClick.Invoke();
                //   GameObject.Find("Canvas").SetActive(true);
                MainCanvas.SetActive(!MainCanvas.activeSelf);

                XRSettings.enabled = false;
                //  gamelevel.SetActive(!gamelevel.activeSelf);
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
