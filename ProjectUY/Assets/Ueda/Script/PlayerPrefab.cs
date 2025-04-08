using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefab : MonoBehaviour
{
    public float kMoveSpeed = 1.0f;     // 移動速度
    public float kPushMoveSpeed = 5.0f; // 左右の移動速度

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

    void FixedUpdate()
    {
        Move(); // 移動処理
    }
}