using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTrigger : MonoBehaviour
{
    public int index;
    public Material[]materialColor;
    private Renderer rendererColor;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (index == TriggerProperties.currentTriggerIndex)
            { 
                rendererColor.sharedMaterial = materialColor[1];          
                TriggerProperties.currentTriggerIndex++;
                isTriggered = true;
            }

            else if(index != TriggerProperties.currentTriggerIndex && !isTriggered)
            {
                TriggerProperties.reset = true;
                TriggerProperties.currentTriggerIndex = 1;
            }
        }
    }

    public void ResetMaterial()
    {
        rendererColor.sharedMaterial = materialColor[0];
        isTriggered = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rendererColor = transform.parent.GetComponent<Renderer>();
        rendererColor.sharedMaterial = materialColor[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
