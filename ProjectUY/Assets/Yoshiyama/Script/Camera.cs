using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 initialPosition = new Vector3(0.0f, 8.44f, -22.04f); // �������W���w�肳�ꂽ���W�ɐݒ�

    // Start is called before the first frame update
    void Start()
    {
        // �������W���擾���ĕۑ�
        initialPosition = new Vector3(0.0f, 8.44f, -22.04f);
        Debug.Log("�������W: " + initialPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �������W�Ɉړ�����֐�
    public void MoveToInitialPosition()
    {
        transform.position = initialPosition;
        Debug.Log("�J�������������W�Ɉړ����܂���: " + initialPosition);
    }
}
