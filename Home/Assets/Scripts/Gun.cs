using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector3 barrelEndPosition;
    float barrelEndX= 0.25f;
    float barrelEndY= 0.065f;
    float bulletFlyingSpeed = 2f;
    [SerializeField] GameObject bullet;
    AudioClip myAudio;

    public void shoot()
    {
        {
            Debug.Log("bang");
            barrelEndPosition = new Vector3(barrelEndX, barrelEndY, transform.position.z);
            GameObject myBullet = Instantiate(bullet, transform.position+ barrelEndPosition, transform.rotation);
            myBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(10f* bulletFlyingSpeed, 0f, 0f);
            myAudio = gameObject.GetComponent<AudioSource>().clip;
            gameObject.gameObject.GetComponent<AudioSource>().PlayOneShot(myAudio);
        }
     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            shoot();
        }
            
    }
}
