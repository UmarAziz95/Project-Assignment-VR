using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField] AudioListerner audiolistener;
	public bool disableOnce;

	void PlaySound(AudioClip whichSound){
		if(!disableOnce){
            audiolistener.audioSource.PlayOneShot (whichSound);
		}else{
			disableOnce = false;
		}
	}
}	
