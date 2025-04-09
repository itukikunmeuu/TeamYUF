using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int leftValue = 0;
    public int rightValue = 0;
    private int value = 0;
    Collider other;

    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[�̃X�N���v�g���擾
        PlayerScript player = other.GetComponent<PlayerScript>();
        if (player == null) return;

        // �v���C���[������������
        if (other.CompareTag("Player"))
        {
            // �v���C���[����
            if(other.transform.position.x < 0.0f)
            {
                value = leftValue;
            }
            // �E��
            else
            {
                value = rightValue;
            }
            
            Debug.Log("value : " + value);
            player.AddCount(value);
        }
    }
}
