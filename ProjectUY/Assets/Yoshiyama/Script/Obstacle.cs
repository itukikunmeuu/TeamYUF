using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int value = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //�������񉼒u���A�^�O�����Ĕ��肵�܂�
            //PlayerCounter counter = other.GetComponent<PlayerCounter>();
            //if (counter != null)
            //{
            //    counter.AddCount(value);
            //    Destroy(gameObject);
            //}
        }
    }
}
