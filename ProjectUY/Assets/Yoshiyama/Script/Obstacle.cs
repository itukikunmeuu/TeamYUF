using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int leftValue = 0;
    public int rightValue = 0;
    private int value = 0;
    Collider other;

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーのスクリプトを取得
        PlayerScript player = other.GetComponent<PlayerScript>();
        if (player == null) return;

        // プレイヤーが当たった時
        if (other.CompareTag("Player"))
        {
            // プレイヤー左側
            if(other.transform.position.x < 0.0f)
            {
                value = leftValue;
            }
            // 右側
            else
            {
                value = rightValue;
            }
            
            Debug.Log("value : " + value);
            player.AddCount(value);
        }
    }
}
