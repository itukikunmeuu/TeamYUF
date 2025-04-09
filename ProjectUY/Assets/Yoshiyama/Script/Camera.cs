using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 initialPosition = new Vector3(0.0f, 8.44f, -22.04f); // 初期座標を指定された座標に設定

    // Start is called before the first frame update
    void Start()
    {
        // 初期座標を取得して保存
        initialPosition = new Vector3(0.0f, 8.44f, -22.04f);
        Debug.Log("初期座標: " + initialPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 初期座標に移動する関数
    public void MoveToInitialPosition()
    {
        transform.position = initialPosition;
        Debug.Log("カメラが初期座標に移動しました: " + initialPosition);
    }
}
