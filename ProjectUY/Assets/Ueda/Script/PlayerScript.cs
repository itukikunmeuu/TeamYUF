using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float kMoveSpeed = 1.0f;     // �ړ����x
    public float kPushMoveSpeed = 4.0f; // ���E�̈ړ����x
    public int playerCount { get; private set; } = 1;  // �v���C���[�̐�
    public GameObject playerPrefab;     // �v���C���[��Prefab
    private ObstacleSpawner obsScript;  // �X�R�A�̃X�N���v�g

    // �ړ�����
    private void Move()
    {
        transform.position += kMoveSpeed * transform.forward * Time.deltaTime;

        // A�L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= kPushMoveSpeed * transform.right * Time.deltaTime;
        }
        // D�L�[�������ꂽ�Ƃ�
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += kPushMoveSpeed * transform.right * Time.deltaTime;
        }
    }

    public void AddCount(int amount)
    {
        playerCount += amount;

        // �v���C���[�𑝂₷
        if (amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                Vector3 newPos = transform.position + new Vector3(0, 0, -0.5f * (transform.childCount + 1));
                GameObject clone = Instantiate(playerPrefab, newPos, Quaternion.identity);
                clone.transform.SetParent(this.transform);
            }
        }
        // �v���C���[�폜
        else if (amount < 0)
        {
            int deleteCount = Mathf.Min(Mathf.Abs(amount), transform.childCount);
            for (int i = 0; i < deleteCount; i++)
            {
                Transform lastChild = transform.GetChild(transform.childCount - 1);
                Destroy(lastChild.gameObject);
            }

            if(transform.childCount <= 0)
            {
                playerCount = 0;
            }
        }

        Debug.Log("�l��:" + (transform.childCount + 1));
    }

    void FixedUpdate()
    {
        if (playerCount <= 0)
        {
            // �Q�[���I�[�o�[
            Debug.Log("�Q�[���I�[�o�[");
            return;
        }

        Move(); // �ړ�����

        // ObstacleSpawner.cs����X�R�A���Q��
        //int amount = obsScript.leftValue;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            AddCount(1);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            AddCount(-1);
        }
    }
}
