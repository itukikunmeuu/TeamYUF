using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // �V�[���J�ڐ�̃V�[�������w��
    public string sceneName;

    void Update()
    {
        // �C�ӂ̃{�^���������ꂽ�ꍇ�ɃV�[���J�ڂ��s��
        if (Input.GetKeyDown(KeyCode.Space))  // �C�ӂ̃L�[�������ꂽ�Ƃ�
        {
            // �V�[���J��
            SceneManager.LoadScene(sceneName);
        }
    }
}
