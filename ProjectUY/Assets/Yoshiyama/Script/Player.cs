using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 playerPos;
    public int count = 10;
    [SerializeField] float moveSpeed = 5f;

    public void AddCount(int amount)
    {
        count += amount;
        Debug.Log("�l��: " + count);

        if (count <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

    void Update()
    {
        // Z�����ɏ�ɑO�i����
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
