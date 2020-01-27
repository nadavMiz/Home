﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    Animator myAnimator;
    Vector2 mySpeed;
    [SerializeField] inventory inventory; 
    public bool canJump = true;
    void Awake()
    {
       if(FindObjectsOfType<Character>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        myAnimator.SetBool("jumping", false);

        speed = 0.1F;
    }

    // Update is called once per frame
    void Update()
    {

        Transform Transform = GetComponent<Transform>();
        if (Input.GetKey("d"))
        {
            Transform.position = Transform.position + new Vector3(1*speed, 0, 0);
            Debug.Log("trying to go right");
        }
        else if (Input.GetKey("a"))
        {
            Transform.position = Transform.position + new Vector3(-1 * speed, 0, 0);
            Debug.Log("trying to go left");
        }
        if(Input.GetKeyDown("space"))
        {
            if (canJump)
            {
                myAnimator.SetBool("jumping", true);

                canJump = false;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
                Debug.Log("jump jump");
               

            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        myAnimator.SetBool("jumping", false);

    }
}
