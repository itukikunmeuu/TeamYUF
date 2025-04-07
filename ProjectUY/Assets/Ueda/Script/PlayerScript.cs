using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float kMoveSpeed = 1.0f;     // �ړ����x
    public float kPushMoveSpeed = 5.0f; // ���E�̈ړ����x
    public GameObject playerPrefab; // �v���C���[��Prefab
    private int playerCount = 1;    // �v���C���[��

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(); // �ړ�����

        // TODO:�Ƃ肠�����v���C���[���B
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 newPos = transform.position + new Vector3(0, 0, -0.5f * playerCount);
            Instantiate(playerPrefab, newPos, transform.rotation);
            playerCount++;
        }
    }
}
