using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TerrainSpawner : NetworkBehaviour
{
    //[SerializeField]
    public GameObject terrainPrefab;
    // Start is called before the first frame update
    public override void OnStartServer()
    {
        GameObject terrain = (GameObject)Instantiate(terrainPrefab, new Vector3(0 , 0, 0), Quaternion.identity);
        NetworkServer.Spawn(terrain);
    }
    }
