using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    //変数
    public GameObject TitleScene;
    public GameObject GameScene;
    public GameObject EndScene;

    //現在の状態遷移を表す整数(0,1,2)
    private int currentState = 0;

    // Rankingスクリプトのインスタンス
    private Ranking ranking;

    // Start is called before the first frame update
    void Start()
    {
        //初期状態の設定
        UpdateState();

        // Rankingスクリプトのインスタンスを取得
        ranking = FindObjectOfType<Ranking>();
    }

    // Update is called once per frame
    void Update()
    {
        //Space押されたら状態を遷移する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //State遷移
            ChangeState();
            UpdateState();
        }
    }

    private void ChangeState()
    {
        //状態を回転させていく(0→1→2→3→0)
        currentState = (currentState + 1) % 3;
    }

    private void UpdateState()
    {
        switch (currentState)
        {
            case 0:
                //Stateが0の場合は、ゲームシーンとクリアシーンを非表示にさせる
                TitleScene.SetActive(true);
                GameScene.SetActive(false);
                EndScene.SetActive(false);
                if (ranking != null) ranking.Clear = false;
                break;
            case 1:
                TitleScene.SetActive(false);
                GameScene.SetActive(true);
                EndScene.SetActive(false);
                if (ranking != null) ranking.Clear = false;
                break;
            case 2:
                TitleScene.SetActive(false);
                GameScene.SetActive(false);
                EndScene.SetActive(true);
                if (ranking != null) ranking.Clear = true;
                break;
        }
    }
}
