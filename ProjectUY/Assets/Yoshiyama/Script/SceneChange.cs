using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    //�ϐ�
    public GameObject TitleScene;
    public GameObject GameScene;
    public GameObject EndScene;

    //���݂̏�ԑJ�ڂ�\������(0,1,2)
    private int currentState = 0;

    // Ranking�X�N���v�g�̃C���X�^���X
    private Ranking ranking;

    // Start is called before the first frame update
    void Start()
    {
        //������Ԃ̐ݒ�
        UpdateState();

        // Ranking�X�N���v�g�̃C���X�^���X���擾
        ranking = FindObjectOfType<Ranking>();
    }

    // Update is called once per frame
    void Update()
    {
        //Space�����ꂽ���Ԃ�J�ڂ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //State�J��
            ChangeState();
            UpdateState();
        }
    }

    private void ChangeState()
    {
        //��Ԃ���]�����Ă���(0��1��2��3��0)
        currentState = (currentState + 1) % 3;
    }

    private void UpdateState()
    {
        switch (currentState)
        {
            case 0:
                //State��0�̏ꍇ�́A�Q�[���V�[���ƃN���A�V�[�����\���ɂ�����
                TitleScene.SetActive(true);
                GameScene.SetActive(false);
                EndScene.SetActive(false);
                if (ranking != null) ranking.Clear = false;
                break;
            case 1:
                TitleScene.SetActive(false);
                GameScene.SetActive(true);
                EndScene.SetActive(false);
                if (ranking != null) ranking.Clear = false;
                break;
            case 2:
                TitleScene.SetActive(false);
                GameScene.SetActive(false);
                EndScene.SetActive(true);
                if (ranking != null) ranking.Clear = true;
                break;
        }
    }
}
