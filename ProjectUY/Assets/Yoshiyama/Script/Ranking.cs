using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    // スコアの値
    public int score;

    // ランクに対応する画像を格納する配列（SSS, SS, S, A, B）
    public Sprite[] rankSprites;

    // ランク画像
    public Image rankImage;

    // 事前に出すNaito画像（フェードイン対象）
    public Image preRankImage;

    // ランク文字表示用テキスト（SSSなど）
    public Text rankText;

    // 最後に出すテキスト（"次へ"など）
    public Text nextText;

    // 表示時間（共通）
    public float displayTime = 5.0f;

    // フェードイン時間（Naito用）
    public float fadeInDuration = 1.0f;

    // Clearフラグ
    public bool Clear;

    private Coroutine rankingCoroutine;

    // PlayerScriptのインスタンス
    private PlayerScript playerScript;

    void Start()
    {
        // 初期化
        ResetRankingDisplay();

        // PlayerScriptのインスタンスを取得
        playerScript = FindObjectOfType<PlayerScript>();

        // PlayerScriptのplayerCountをscoreに設定
        if (playerScript != null)
        {
            score = playerScript.playerCount;
        }
    }

    void Update()
    {
        if (Clear)
        {
            if (rankingCoroutine == null)
            {
                rankingCoroutine = StartCoroutine(ShowRankingFlow());
            }
        }
        else
        {
            if (rankingCoroutine != null)
            {
                StopCoroutine(rankingCoroutine);
                rankingCoroutine = null;
                ResetRankingDisplay();
            }
        }
    }

    IEnumerator ShowRankingFlow()
    {
        // --- Step 1: RankingNaito（フェードイン） ---
        preRankImage.gameObject.SetActive(true);
        rankText.gameObject.SetActive(false);
        rankImage.gameObject.SetActive(false);
        nextText.gameObject.SetActive(false);

        Color color = preRankImage.color;
        color.a = 0f;
        preRankImage.color = color;

        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeInDuration);
            preRankImage.color = color;
            yield return null;
        }

        // ★ 最後にαを強制的に1にして、フェードを完了させる
        color.a = 1f;
        preRankImage.color = color;

        yield return new WaitForSeconds(displayTime);

        // --- Step 2: RankingText ---
        preRankImage.gameObject.SetActive(false);
        rankText.gameObject.SetActive(true);
        rankImage.gameObject.SetActive(false);
        nextText.gameObject.SetActive(false);

        string rank = GetRank(score);
        rankText.text = rank;

        yield return new WaitForSeconds(displayTime);

        // --- Step 3: RankingImage ---
        rankText.gameObject.SetActive(false);
        rankImage.gameObject.SetActive(true);
        nextText.gameObject.SetActive(false);

        SetRankImage(rank);

        yield return new WaitForSeconds(displayTime);

        // --- Step 4: NextText ---
        rankText.gameObject.SetActive(false);
        rankImage.gameObject.SetActive(false);
        nextText.gameObject.SetActive(true);
    }

    string GetRank(int score)
    {
        if (score >= 50) return "SSS";
        if (score >= 40) return "SS";
        if (score >= 30) return "S";
        if (score >= 20) return "A";
        return "B";
    }

    void SetRankImage(string rank)
    {
        int rankIndex = -1;
        switch (rank)
        {
            case "SSS": rankIndex = 0; break;
            case "SS": rankIndex = 1; break;
            case "S": rankIndex = 2; break;
            case "A": rankIndex = 3; break;
            case "B": rankIndex = 4; break;
        }

        if (rankIndex >= 0 && rankIndex < rankSprites.Length)
        {
            rankImage.sprite = rankSprites[rankIndex];
        }
        else
        {
            Debug.LogWarning("対応するランク画像がありません");
        }
    }

    void ResetRankingDisplay()
    {
        preRankImage.gameObject.SetActive(false);
        rankText.gameObject.SetActive(false);
        rankImage.gameObject.SetActive(false);
        nextText.gameObject.SetActive(false);
    }
}
