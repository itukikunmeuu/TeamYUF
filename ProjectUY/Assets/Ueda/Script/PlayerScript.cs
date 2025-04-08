using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float kMoveSpeed = 1.0f;     // 移動速度
    public float kPushMoveSpeed = 4.0f; // 左右の移動速度
    public int playerCount { get; private set; } = 1;  // プレイヤーの数
    public GameObject playerPrefab;     // プレイヤーのPrefab
    private ObstacleSpawner obsScript;  // スコアのスクリプト

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
                Vector3 newPos = transform.position + new Vector3(0, 0, -0.5f * (transform.childCount + 1));
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

            if(transform.childCount <= 0)
            {
                playerCount = 0;
            }
        }

        Debug.Log("人数:" + (transform.childCount + 1));
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

        // ObstacleSpawner.csからスコアを参照
        //int amount = obsScript.leftValue;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            AddCount(1);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            AddCount(-1);
        }
    }
}
