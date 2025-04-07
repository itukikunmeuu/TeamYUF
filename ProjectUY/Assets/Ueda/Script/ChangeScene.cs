using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeButton()
    {
        Debug.Log("ボタン押した");
        SceneManager.LoadScene("Ueda/ClearScene"); // 次シーンに移行
    }
}
