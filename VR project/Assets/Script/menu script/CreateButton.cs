using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CreateButton : MonoBehaviour
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
   // GameObject PlayerUi;

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
                MainCanvas.SetActive(!MainCanvas.activeSelf);
                XRSettings.enabled = true;
             //   PlayerUi.SetActive(!PlayerUi.activeSelf);
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
