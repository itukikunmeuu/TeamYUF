using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 initialPosition = new Vector3(0.0f, 8.44f, -22.04f); // 初期座標を指定された座標に設定
    public Transform target; // 追従するオブジェクト
    private Vector3 offset; // ターゲットとのオフセット

    // Start is called before the first frame update
    void Start()
    {
        // 初期座標を取得して保存
        initialPosition = new Vector3(0.0f, 8.44f, -22.04f);
        Debug.Log("初期座標: " + initialPosition);

        // ターゲットとのオフセットを計算
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 追従するオブジェクトが指定されている場合、そのオブジェクトに追従する
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }

    // 初期座標に移動する関数
    public void MoveToInitialPosition()
    {
        transform.position = initialPosition;
        Debug.Log("カメラが初期座標に移動しました: " + initialPosition);
    }
}
