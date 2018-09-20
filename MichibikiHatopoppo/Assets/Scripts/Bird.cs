using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    //移動速度
    [SerializeField]
    private float moveSpeed;
    //移動フラグ
    private bool isMoving = false;
    //目的地
    private Vector3 targetPosition;
    //鳩のRigidbody2D
    private Rigidbody2D rb2d;
    //移動開始時間
    private float startTime;
    //移動にかかる時間
    private float moveTime;
    //進行率
    private float rate;
    private SpriteRenderer sprite;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
    }

    void Update()
    {

        if (isMoving)
        {
            movingToDestination();
        }

        if(transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    //目的地の更新
    public void DestinationUpdate(Vector3 brokenLocation)
    {
        targetPosition = brokenLocation;
        //向きの更新
        if(targetPosition.x < transform.position.x)
        {
            sprite.flipX = true;
        }else if(targetPosition.x > transform.position.x)
        {
            sprite.flipX = false;
        }
        isMoving = true;
    }

    //目的地への移動
    private void movingToDestination()
    {
        //print("移動中");
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.01f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            print("OK!!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bubble")
        {
            isMoving = false;
            rb2d.velocity = new Vector2(0, 0);
        }
    }

}
