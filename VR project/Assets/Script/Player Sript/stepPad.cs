using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class stepPad : MonoBehaviour {

    // Use this for initialization

    public UnityEvent compeleteevent;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        compeleteevent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {

    }

}
