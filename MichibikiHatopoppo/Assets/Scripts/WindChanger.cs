using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindChanger : MonoBehaviour {
    [SerializeField]
    private GameObject[] windZone;
    //初期の風向き設定（上が0,時計回りに1,2,3の四方向）
    [SerializeField]
    private int initialWindDirection;
    //変える風向き設定(上と同様）
    [SerializeField]
    private int changeWindDirection;
    //風向きが変化中かどうか
    private bool isChange = false;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        float zRotation;
        if (other.gameObject.tag == "Bird")
        {
            if (!isChange)
            {
                zRotation = DecidWindDirection(changeWindDirection);
                isChange = true;
            }
            else
            {
                zRotation = DecidWindDirection(initialWindDirection);
                isChange = false;
            }

            ChangeWindZone(zRotation);
        }
    }

    //変更するzRotationの設定
    float DecidWindDirection(int windDirection)
    {
        float z = 0;
        switch (windDirection)
        {
            case 0:
                z = 90;
                break;
            case 1:
                z = 0;
                break;
            case 2:
                z = -90;
                break;
            case 3:
                z = 180;
                break;
        }
        return z;
    }

    private void ChangeWindZone(float zRotation)
    {
        //風向きの変更
        for (int i = 0; i < windZone.Length; i++)
        {
            Vector3 rotation = windZone[i].transform.rotation.eulerAngles;
            rotation.z = zRotation;
            windZone[i].transform.rotation = Quaternion.Euler(rotation);
        }
        //矢印の向きの変更
        transform.rotation = Quaternion.Euler(new Vector3 (0,0,zRotation));
    }

}
