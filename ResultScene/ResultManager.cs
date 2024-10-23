using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    //�X�N���v�g
    public SoundManager _soundManager;

    //�X�R�A�p�e�L�X�g
    [SerializeField]
    private TextMeshProUGUI _scoreText
                           ,_highScoreText;

    //�n�C�X�R�A�X�V���b�Z�[�W
    [SerializeField]
    private GameObject _highScoreMessage;

    //�t�F�[�h���
    [SerializeField]
    private GameObject _fadeScene;

    // Start is called before the first frame update
    void Start()
    {
        _fadeScene.SetActive(true);

        //�n�C�X�R�A�̃f�[�^�����[�h
        var highScore = PlayerPrefs.GetInt("HighScore");

        //�n�C�X�R�A�������Ă����ꍇ
        if (GameManager._gameScore > highScore)
        {
            //�n�C�X�R�A���X�V
            PlayerPrefs.SetInt("HighScore", GameManager._gameScore);

            //�n�C�X�R�A�X�V���b�Z�[�W��\��
            _highScoreMessage.SetActive(true);
        }
        else 
        {
            //�n�C�X�R�A�X�V���b�Z�[�W���\��
            _highScoreMessage.SetActive(false);
        }


        //�X�R�A�A�n�C�X�R�A�\��
        _scoreText.text = "SCORE:" + GameManager._gameScore;
        _highScoreText.text = "HIGHSCORE:" + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���g���C�{�^��
    public void Retry()
    {
        _soundManager.ButtonSE();

        //�V�[���؂�ւ�
        SceneManager.LoadScene("GameScene");
    }

    //�^�C�g����ʂɖ߂�{�^��
    public void BackTitle()
    {
        _soundManager.ButtonSE();

        //�V�[���؂�ւ�
        SceneManager.LoadScene("TitleScene");
    }
}
