using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CapsuleMovement : NetworkBehaviour {
    
    public float speed = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // do basic player movement
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        

    }
}
