using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Random = System.Random;

public class TestScript : NetworkBehaviour
{
    public Text text;

    [SyncVar]
    int num;
    // Start is called before the first frame update
    void Start()
    {
        Random rand = new Random();
        num = rand.Next(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = num.ToString();
    }
}
