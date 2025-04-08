using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefab : MonoBehaviour
{
    public float kMoveSpeed = 1.0f;     // �ړ����x
    public float kPushMoveSpeed = 5.0f; // ���E�̈ړ����x

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

    void FixedUpdate()
    {
        Move(); // �ړ�����
    }
}