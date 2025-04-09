using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    // �X�R�A�̒l
    public int score;

    // �����N�ɑΉ�����摜���i�[����z��iSSS, SS, S, A, B�j
    public Sprite[] rankSprites;

    // �����N�摜
    public Image rankImage;

    // ���O�ɏo��Naito�摜�i�t�F�[�h�C���Ώہj
    public Image preRankImage;

    // �����N�����\���p�e�L�X�g�iSSS�Ȃǁj
    public Text rankText;

    // �Ō�ɏo���e�L�X�g�i"����"�Ȃǁj
    public Text nextText;

    // �\�����ԁi���ʁj
    public float displayTime = 5.0f;

    // �t�F�[�h�C�����ԁiNaito�p�j
    public float fadeInDuration = 1.0f;

    // Clear�t���O
    public bool Clear;

    private Coroutine rankingCoroutine;

    // PlayerScript�̃C���X�^���X
    private PlayerScript playerScript;

    void Start()
    {
        // ������
        ResetRankingDisplay();

        // PlayerScript�̃C���X�^���X���擾
        playerScript = FindObjectOfType<PlayerScript>();

        // PlayerScript��playerCount��score�ɐݒ�
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
        // --- Step 1: RankingNaito�i�t�F�[�h�C���j ---
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

        // �� �Ō�Ƀ��������I��1�ɂ��āA�t�F�[�h������������
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
            Debug.LogWarning("�Ή����郉���N�摜������܂���");
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
