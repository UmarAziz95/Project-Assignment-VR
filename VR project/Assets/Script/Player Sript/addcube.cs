using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class addcube : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public UnityEvent compeleteevent;
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    public void Addcube()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        
        Instantiate(myPrefab, new Vector3(0, 3 , 6), Quaternion.identity);
    }

    private void OnPointerEnter(PointerEventData BaseEventData)
    {
        compeleteevent.Invoke();
        Instantiate(myPrefab, new Vector3(0, 3, 6), Quaternion.identity);
       // compeleteevent.Invoke();
    }

    
}
