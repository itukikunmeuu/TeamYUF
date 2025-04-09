using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float kMoveSpeed = 1.0f;     // 移動速度
    public float kPushMoveSpeed = 4.0f; // 左右の移動速度
    public int playerCount { get; private set; } = 1;  // プレイヤーの数
    public GameObject playerPrefab;     // プレイヤーのPrefab
    private ObstacleSpawner obsScript;  // スコアのスクリプト

    // 初期位置
    private Vector3 initialPosition;

    private void Awake()
    {
        // 初期位置を保存
        initialPosition = transform.position;
    }

    // 移動処理
    private void Move()
    {
        transform.position += kMoveSpeed * transform.forward * Time.deltaTime;

        // Aキーが押されたとき
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= kPushMoveSpeed * transform.right * Time.deltaTime;
        }
        // Dキーが押されたとき
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += kPushMoveSpeed * transform.right * Time.deltaTime;
        }
    }

    public void AddCount(int amount)
    {
        playerCount += amount;

        // プレイヤーを増やす
        if (amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                // 出現位置をランダムに決定
                float xOffset = Random.Range(-1.0f, 1.0f);
                float zOffset = Random.Range(-0.5f, -0.1f);
                zOffset += -0.5f * (transform.childCount + 1);
                Vector3 newPos = transform.position + new Vector3(xOffset, 0, zOffset);

                // プレイヤーのPrefabを生成
                GameObject clone = Instantiate(playerPrefab, newPos, Quaternion.identity);
                clone.transform.SetParent(this.transform);
            }
        }
        // プレイヤー削除
        else if (amount < 0)
        {
            int deleteCount = Mathf.Min(Mathf.Abs(amount), transform.childCount);
            for (int i = 0; i < deleteCount; i++)
            {
                Transform lastChild = transform.GetChild(transform.childCount - 1);
                Destroy(lastChild.gameObject);
            }

            if (transform.childCount <= 0)
            {
                playerCount = 0;
            }
        }

        Debug.Log("人数:" + (transform.childCount + 1));
    }

    public void InitializePlayer()
    {
        // プレイヤーの位置を初期位置にリセット
        transform.position = initialPosition;

        // プレイヤーの数を初期化
        playerCount = 1;

        // 子オブジェクトを全て削除
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Debug.Log("プレイヤーが初期化されました。");
    }

    void FixedUpdate()
    {
        if (playerCount <= 0)
        {
            // ゲームオーバー
            Debug.Log("ゲームオーバー");
            return;
        }

        Move(); // 移動処理
    }
}
