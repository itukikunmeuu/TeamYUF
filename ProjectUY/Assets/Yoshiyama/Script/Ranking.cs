using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    //�X�R�A�̒l
    public int score;

    //�����N�ɑΉ�����摜���i�[����z��
    public Sprite[] rankSprites;

    //�����L���O�ɑΉ�����摜�̈ʒu
    public Image rankImage;

    string GetRank(int score)
    {
        //�����L���O�ɉ����ăX�R�A�\�L��ύX����
        if (score >= 50)
        {
            return "SSS";
        }
        if (score >= 40)
        {
            return "SS";
        }
        if (score >= 30)
        {
            return "S";
        }
        if (score >= 20)
        {
            return "A";
        }
        else
        {
            return "B";
        }

    }

    void SetRankImage(string rank)
    {
        int rankIndex = -1;

        switch (rank)
        {
            case "SSS":
                rankIndex = 0;
                break;

            case "SS":
                rankIndex = 1;
                break;
            case "S":
                rankIndex = 2;
                break;
            case "A":
                rankIndex = 3;
                break;
            case "B":
                rankIndex = 4;
                break;
        }

        //rankIndex���͈͓��Ȃ�Ή�����摜��ݒ肷��
        if(rankIndex >= 0&& rankIndex < rankSprites.Length)
        {
            rankImage.sprite= rankSprites[rankIndex];
        }
        else
        {
            Debug.Log("�����Ă܂���");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //�X�R�A�Ɋ�Â��ă����N�����肳����
        string rank = GetRank(score);
        //�����N�ɉ������摜��\��

        Debug.Log(rank);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
