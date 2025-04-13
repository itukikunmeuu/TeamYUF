using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 initialPosition = new Vector3(0.0f, 8.44f, -22.04f); // �������W���w�肳�ꂽ���W�ɐݒ�
    public Transform target; // �Ǐ]����I�u�W�F�N�g
    private Vector3 offset; // �^�[�Q�b�g�Ƃ̃I�t�Z�b�g

    // Start is called before the first frame update
    void Start()
    {
        // �������W���擾���ĕۑ�
        initialPosition = new Vector3(0.0f, 8.44f, -22.04f);
        Debug.Log("�������W: " + initialPosition);

        // �^�[�Q�b�g�Ƃ̃I�t�Z�b�g���v�Z
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // �Ǐ]����I�u�W�F�N�g���w�肳��Ă���ꍇ�A���̃I�u�W�F�N�g�ɒǏ]����
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }

    // �������W�Ɉړ�����֐�
    public void MoveToInitialPosition()
    {
        transform.position = initialPosition;
        Debug.Log("�J�������������W�Ɉړ����܂���: " + initialPosition);
    }
}
