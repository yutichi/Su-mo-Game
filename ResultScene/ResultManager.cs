using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    //スクリプト
    public SoundManager _soundManager;

    //スコア用テキスト
    [SerializeField]
    private TextMeshProUGUI _scoreText
                           ,_highScoreText;

    //ハイスコア更新メッセージ
    [SerializeField]
    private GameObject _highScoreMessage;

    //フェード画面
    [SerializeField]
    private GameObject _fadeScene;

    // Start is called before the first frame update
    void Start()
    {
        _fadeScene.SetActive(true);

        //ハイスコアのデータをロード
        var highScore = PlayerPrefs.GetInt("HighScore");

        //ハイスコアを上回っていた場合
        if (GameManager._gameScore > highScore)
        {
            //ハイスコアを更新
            PlayerPrefs.SetInt("HighScore", GameManager._gameScore);

            //ハイスコア更新メッセージを表示
            _highScoreMessage.SetActive(true);
        }
        else 
        {
            //ハイスコア更新メッセージを非表示
            _highScoreMessage.SetActive(false);
        }


        //スコア、ハイスコア表示
        _scoreText.text = "SCORE:" + GameManager._gameScore;
        _highScoreText.text = "HIGHSCORE:" + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //リトライボタン
    public void Retry()
    {
        _soundManager.ButtonSE();

        //シーン切り替え
        SceneManager.LoadScene("GameScene");
    }

    //タイトル画面に戻るボタン
    public void BackTitle()
    {
        _soundManager.ButtonSE();

        //シーン切り替え
        SceneManager.LoadScene("TitleScene");
    }
}
