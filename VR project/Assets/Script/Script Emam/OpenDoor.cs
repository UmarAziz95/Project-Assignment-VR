using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform door;

    public Vector3 closePosition;
    public Vector3 openPosition;
    public Vector3 openOffset = new Vector3(0, 4, 0);


    public float openSpeed = 5;

    private bool open = false;

    private void Start()
    {
        closePosition = door.position;
        openPosition = door.position + openOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerProperties.currentTriggerIndex > TriggerProperties.numOfTrigger)
        {
            door.position = Vector3.Slerp(door.position, openPosition, Time.deltaTime * openSpeed);
        }
        else
        {
            door.position = Vector3.Slerp(door.position, closePosition, Time.deltaTime * openSpeed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.tag == "Player")
        {
            OpenedDoor();
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseDoor();
            
        }
    }

    public void CloseDoor()
    {
        open = false;
    }

    public void OpenedDoor()
    {
        open = true;
    }
}
