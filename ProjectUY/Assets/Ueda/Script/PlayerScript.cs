using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float kMoveSpeed = 1.0f;     // 移動速度
    public float kPushMoveSpeed = 5.0f; // 左右の移動速度
    public GameObject playerPrefab; // プレイヤーのPrefab
    private int playerCount = 1;    // プレイヤー数

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(); // 移動処理

        // TODO:とりあえずプレイヤー増殖
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 newPos = transform.position + new Vector3(0, 0, -0.5f * playerCount);
            Instantiate(playerPrefab, newPos, transform.rotation);
            playerCount++;
        }
    }
}
