using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public bool enter = false;
    public Transform gateLeftfront;
    public Transform gateRightfront;
    public Transform gateLeftBack;
    public Transform gateRightBack;
    public Vector3 targetL;
    public Vector3 targetR;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            gateLeftfront.position = Vector3.MoveTowards(gateLeftfront.position, targetL, speed * Time.deltaTime);
            gateLeftBack.position = Vector3.MoveTowards(gateLeftBack.position, targetL, speed * Time.deltaTime);
            gateRightfront.position = Vector3.MoveTowards(gateRightfront.position, targetR, speed * Time.deltaTime);
            gateRightBack.position = Vector3.MoveTowards(gateRightBack.position, targetR, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enter = true;
    }
}
