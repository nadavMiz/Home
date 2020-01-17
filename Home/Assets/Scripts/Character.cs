using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform Transform = GetComponent<Transform>();
        if (Input.GetKey("d"))
        {
            Transform.position = Transform.position + new Vector3(1, 0, 0);
            Debug.Log("trying to go right");
        }
        else if (Input.GetKey("a"))
        {
            Debug.Log("trying to go left");
        }
    }
}
