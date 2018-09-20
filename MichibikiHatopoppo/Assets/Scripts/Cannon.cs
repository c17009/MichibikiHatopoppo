using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    // 発射口
    private Transform cannonHead;
    // 発射台の位置
    private Vector3 cannonPos;
    // 発射台からマウスポインタまでの距離
    private Vector3 direction;
    //泡を発射するパワー
    [SerializeField]
    private float forceShootBubble;
    //泡の配列番号
    private int index;
    //マウスホイールの値
    private int mouseWheel;
    // 発射する泡
    [SerializeField]
    private GameObject[] bubbles;
    //UI表示する泡
    [SerializeField]
    private GameObject[] bubblesUi;
    
	void Start () {
        // 子の発射口を取得
        cannonHead = transform.Find("Cannon_head").transform;
        // 発射台の位置をスクリーンポイントに変換
        cannonPos = Camera.main.WorldToScreenPoint(transform.position);
	}
	
	void Update () {

        // 発射台からマウスポインタの距離を計算
        direction = Input.mousePosition - cannonPos;

        //マウスホイールの値取得
        mouseWheel = (int)Input.GetAxis("MouseScrollWheel");
        //0～2までの範囲を取るようにする
        if(mouseWheel > 0)
        {
            index += 1;

            if(index >= 3)
            {
                index = 0;
            }
        }
        if(mouseWheel < 0)
        {
            index -= 1;

            if(index <= -1)
            {
                index = 2;
            }
        }

        // 左クリックしたとき
        if (Input.GetButtonDown("Fire1"))
        {
            ShotBubble();
        }

        CannonRotation(direction);
        ShowBubbleTypes();
	}

    // 泡の発射
    private void ShotBubble()
    {
        GameObject Generated_bubble = Instantiate(bubbles[index], cannonHead.position, Quaternion.identity);
        Rigidbody2D rb2d = Generated_bubble.GetComponent<Rigidbody2D>();
        rb2d.AddForce(cannonHead.transform.right * forceShootBubble, ForceMode2D.Impulse);
    }

    // 発射台の回転
    private void CannonRotation(Vector3 vec)
    {
        vec.z = 1;
        transform.rotation = Quaternion.FromToRotation(new Vector3(1, 2, 0), vec);
    }

    //泡の種類を表示する
    private void ShowBubbleTypes()
    {
        switch (index)
        {
            case 0:
                bubblesUi[0].SetActive(true);
                bubblesUi[1].SetActive(false);
                bubblesUi[2].SetActive(false);
                break;
            case 1:
                bubblesUi[0].SetActive(false);
                bubblesUi[1].SetActive(true);
                bubblesUi[2].SetActive(false);
                break;
            case 2:
                bubblesUi[0].SetActive(false);
                bubblesUi[1].SetActive(false);
                bubblesUi[2].SetActive(true);
                break;
        }
    }
}
