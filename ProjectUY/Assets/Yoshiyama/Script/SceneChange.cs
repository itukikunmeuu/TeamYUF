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

    // PlayerScript�̃C���X�^���X
    private PlayerScript playerScript;

    // Camera�X�N���v�g�̃C���X�^���X
    private Camera cameraScript;

    // ObstacleSpawner�̃C���X�^���X
    private ObstacleSpawner obstacleSpawner;

    // Player�I�u�W�F�N�g�̖��O
    public string playerObjectName = "Player";

    // Start is called before the first frame update
    void Start()
    {
        //������Ԃ̐ݒ�
        UpdateState();

     
    }

    // Update is called once per frame
    void Update()
    {

        // Ranking�X�N���v�g�̃C���X�^���X���擾
        ranking = FindObjectOfType<Ranking>();

        // Player�I�u�W�F�N�g����������PlayerScript�̃C���X�^���X���擾
        GameObject playerObject = GameObject.Find(playerObjectName);
        if (playerObject != null)
        {
            playerScript = playerObject.GetComponent<PlayerScript>();
        }

        // ObstacleSpawner�̃C���X�^���X���擾
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();

        // Camera�X�N���v�g�̃C���X�^���X���擾
        cameraScript = FindObjectOfType<Camera>();

        // �v���C���[��Z���W��150�𒴂��邩�AplayerCount��0�ȉ��̏ꍇ��currentState��2�ɕύX
        if (playerScript != null && (playerScript.transform.position.z > 150 || playerScript.playerCount <= 0))
        {
            currentState = 2;
            UpdateState();
        }

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
        //��Ԃ���]�����Ă���(0��1��2��0)
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

                // PlayerScript��ObstacleSpawner��Camera�̏������������Ăяo��
                if (playerScript != null)
                {
                    playerScript.InitializePlayer();
                }
                if (obstacleSpawner != null)
                {
                    obstacleSpawner.InitializeObstacles();
                }
                if (cameraScript != null)
                {
                    cameraScript.MoveToInitialPosition();
                }
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
