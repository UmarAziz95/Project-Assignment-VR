using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListerner : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

}
