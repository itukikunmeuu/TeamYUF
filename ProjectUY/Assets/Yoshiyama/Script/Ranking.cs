using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    //スコアの値
    public int score;

    //ランクに対応する画像を格納する配列
    public Sprite[] rankSprites;

    //ランキングに対応する画像の位置
    public Image rankImage;

    string GetRank(int score)
    {
        //ランキングに応じてスコア表記を変更する
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

        //rankIndexが範囲内なら対応する画像を設定する
        if(rankIndex >= 0&& rankIndex < rankSprites.Length)
        {
            rankImage.sprite= rankSprites[rankIndex];
        }
        else
        {
            Debug.Log("入ってません");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //スコアに基づいてランクを決定させる
        string rank = GetRank(score);
        //ランクに応じた画像を表示

        Debug.Log(rank);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
