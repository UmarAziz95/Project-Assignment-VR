using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
    [SerializeField]
    GameObject InitialCanvas;

    [SerializeField]
    GameObject NavigateCanvas;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
                //  yield return new WaitForSeconds(2);

            }
            else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}


        if (menuButtonController.index == thisIndex)
        {

            if (Input.GetButtonDown("Submit"))
            {

                InitialCanvas.SetActive(!InitialCanvas.activeSelf);
                NavigateCanvas.SetActive(!NavigateCanvas.activeSelf);

            }
            
        }
    }
}
