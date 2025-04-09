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

    // PlayerScriptのインスタンス
    private PlayerScript playerScript;

    // cameraのインスタンス
    private Camera cameraScript;

    // ObstacleSpawnerのインスタンス
    private ObstacleSpawner obstacleSpawner;

    // Playerオブジェクトの名前
    public string playerObjectName = "Player";

    // Start is called before the first frame update
    void Start()
    {
        //初期状態の設定
        UpdateState();

        // Rankingスクリプトのインスタンスを取得
        ranking = FindObjectOfType<Ranking>();

        // Playerオブジェクトを検索してPlayerScriptのインスタンスを取得
     

      
        

        // デバッグログを追加してインスタンスが取得されているか確認
        if (ranking != null)
        {
            Debug.Log("Rankingスクリプトのインスタンスが取得されました。");
        }
        else
        {
            Debug.LogWarning("Rankingスクリプトのインスタンスが取得されませんでした。");
        }

        if (playerScript != null)
        {
            Debug.Log("PlayerScriptのインスタンスが取得されました。");
        }
        else
        {
            Debug.LogWarning("PlayerScriptのインスタンスが取得されませんでした。");
        }

        if (obstacleSpawner != null)
        {
            Debug.Log("ObstacleSpawnerのインスタンスが取得されました。");
        }
        else
        {
            Debug.LogWarning("ObstacleSpawnerのインスタンスが取得されませんでした。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.Find(playerObjectName);
        if (playerObject != null)
        {
            playerScript = playerObject.GetComponent<PlayerScript>();
        }
        // プレイヤーのZ座標が150を超えるか、playerCountが0以下の場合にcurrentStateを2に変更
        if (playerScript != null && (playerScript.transform.position.z > 150 || playerScript.playerCount <= 0))
        {
            currentState = 2;
            UpdateState();
        }
        // ObstacleSpawnerのインスタンスを取得
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();

        // cameraのインスタンスを取得
        cameraScript = FindObjectOfType<Camera>();

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
        //状態を回転させていく(0→1→2→0)
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

                // PlayerScriptとObstacleSpawnerの初期化処理を呼び出す
                if (playerScript != null)
                {
                    playerScript.InitializePlayer();
                }
                if (obstacleSpawner != null)
                {
                    obstacleSpawner.InitializeObstacles();
                }
                if(cameraScript != null)
                {
                    cameraScript.MoveToInitialPosition();
                }
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
