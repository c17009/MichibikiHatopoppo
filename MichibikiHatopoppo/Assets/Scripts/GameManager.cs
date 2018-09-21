using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //現在のステージ
    private static int currentStage;
    //ステージ数を表示するテキスト
    private Text stageText;
    //クリア時の表示テキスト
    private GameObject clearText;
	// Use this for initialization
	void Start () {
        //現在のステージ取得
        currentStage = SceneManager.GetActiveScene().buildIndex;
        //タイトル画面のときはUIを取得しない
        if(currentStage == 0) { return; }
        //UIの取得・更新
        stageText = GameObject.Find("StageText").GetComponent<Text>();
        clearText = GameObject.Find("ClearText");
        clearText.SetActive(false);
        stageText.text = "ステージ" + currentStage;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void StageClear()
    {
        clearText.SetActive(true);
        Invoke("GoToNextScene", 3);
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(currentStage + 1);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void GameClear()
    {
        SceneManager.LoadScene(6);
    }

}
