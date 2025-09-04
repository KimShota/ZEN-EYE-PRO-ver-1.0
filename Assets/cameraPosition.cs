using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour
{ public GameObject player;
    public Vector3 positionPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = positionPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
