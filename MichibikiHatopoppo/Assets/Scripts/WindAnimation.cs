using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnimation : MonoBehaviour {
    //アニメーションスタート位置
    //進行方向
    [SerializeField]
    private float animationPower;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //泡を進ませる
        transform.Translate(1, 0, 0);

	}

    //終了地点に来たら開始位置に戻る
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "WindEnd")
        {
            transform.position = transform.parent.position;
            transform.rotation = transform.parent.transform.rotation;
        }
    }
}
