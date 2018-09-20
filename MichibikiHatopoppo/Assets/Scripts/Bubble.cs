using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble: MonoBehaviour {
    //消えるまでの時間
    [SerializeField]
    private float disappearTime;
    //風から受ける力
    [SerializeField]
    private float forceReceiveFromWind;
    //Birdスクリプト
    private Bird birdScript;
    Rigidbody2D rb2d;
    void Start () {
        birdScript = GameObject.Find("Bird").GetComponent<Bird>();
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("BrokenBubble", disappearTime);
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BrokenBubble();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "WindZone")
        {
            rb2d.AddForce(transform.right * forceReceiveFromWind, ForceMode2D.Impulse);
        }
    }

    private void BrokenBubble()
    {
        birdScript.DestinationUpdate(transform.position);
        Destroy(gameObject);
    }
}
