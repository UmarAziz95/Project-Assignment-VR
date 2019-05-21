using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    [SerializeField] InputField inputField;
    public EventSystem eventSystem;
    private TouchScreenKeyboard keyboard;
    // Update is called once per frame
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetButtonDown("Submit"))
            {
                animator.SetBool("pressed", true);
       /*
                if (eventSystem.currentSelectedGameObject != null)
                {
                    var previous = eventSystem.currentSelectedGameObject.GetComponent<Selectable>();
                    if (previous != null)
                    {
                        previous.OnDeselect(null);
                        eventSystem.SetSelectedGameObject(null);
                    }
                }
                */
                inputField.ActivateInputField();
                inputField.Select();
                keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
                //eventSystem.SetSelectedGameObject(inputField.gameObject);
                ///   inputField.OnSelect(null);
                //EventSystem.current.SetSelectedGameObject(inputField.gameObject);
                //  inputField.OnPointerClick(new PointerEventData(EventSystem.current));

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
