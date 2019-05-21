using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.Networking;

public class LockController : NetworkBehaviour
{
    public GameObject[] lockTrigger;
    List<int> triggerIndex = new List<int>();
//  private NetworkManager networkManager;

    void Start()
    {

        setuplock();


    }

    [Client]
    void setuplock()
    {

        TriggerProperties.numOfTrigger = lockTrigger.Length;
        for (int i = 0; i < lockTrigger.Length; i++)
        {
            int index = i + 1;
            triggerIndex.Add(index);
        }

        triggerIndex = RandomizeIndex(triggerIndex);
        CmdTriggerIndex();
    }

    [Command]
    void CmdTriggerIndex()
    {
        Debug.Log("Update Lock: update");
        for (int i = 0; i < lockTrigger.Length; i++)
        {
            UpdateTrigger trigger = lockTrigger[i].GetComponent<UpdateTrigger>();
            trigger.OnActiveChange(triggerIndex[i]);
        }
    }

   
    public List<int> RandomizeIndex (List<int> items)
    {
        Random rand = new Random();

        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < items.Count - 1; i++)
        {
            int j = rand.Next(i, items.Count);
            int temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        
        return items;
    }

    private void Update()
    {
        if(TriggerProperties.reset)
        {
            for(int i = 0; i < lockTrigger.Length; i++)
            {
                UpdateTrigger trigger = lockTrigger[i].GetComponent<UpdateTrigger>();
                trigger.ResetMaterial();
            }
            TriggerProperties.reset = false;
        }

        /*if (Input.GetAxis("Fire3") == 1)
        {

            TriggerProperties.numOfTrigger = lockTrigger.Length;
            for (int i = 0; i < lockTrigger.Length; i++)
            {
                int index = i + 1;
                triggerIndex.Add(index);
            }

            triggerIndex = RandomizeIndex(triggerIndex);
            SetTriggerIndex();
        }
        */
    }
}
