using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // シーン遷移先のシーン名を指定
    public string sceneName;

    void Update()
    {
        // 任意のボタンが押された場合にシーン遷移を行う
        if (Input.GetKeyDown(KeyCode.Space))  // 任意のキーが押されたとき
        {
            // シーン遷移
            SceneManager.LoadScene(sceneName);
        }
    }
}
