using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //スクリプト　
    public CountStart _countStart;
    public FadeScripts _fadeScripts;
    public SoundManager _soundManager;

    //スコア
    public static int _gameScore;

    //スコアコンボ
    public static int _comboCount;

    //時間制限(設定)
    public int _time;

    //タイマー
    public float _timmer;

    //テキスト用タイマー
    private int _secondF
               ,_secondS
               ,_secondT;

    //Text関連
    [SerializeField]
    private TextMeshProUGUI _scoreText
                           ,_timeText
                           ,_levelText
                           ,_comboText;

    //難易度
    private float _gameLevel
                 ,_levelScale;

    //難易度用タイマー
    private int _levelTimmer;

    //フェード画面
    [SerializeField]
    private GameObject _fadeScene;


    // Start is called before the first frame update
    void Start()
    {
        _fadeScene.SetActive(true);

        _gameScore = 0;
        _comboCount = 1;

        _timmer = 1.0f;
        _gameLevel = 1;

        _levelScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム速度(難易度が上がると早くなる)
        Time.timeScale = _levelScale;

        //スコアの下限制限
        if(_gameScore < 0)
        {
            _gameScore = 0;
        }

        //Text関連
        _scoreText.text = "SCORE:" + _gameScore;
        _timeText.text = "Time:" + _secondT + _secondS + _secondF;
        
        if(_gameLevel > 3)
        {
            _levelText.text = "LEVEL:MAX";
        }
        else
        {
            _levelText.text = "LEVEL:" + _gameLevel;
        }

        if(_comboCount >= 5)
        {
            _comboText.text = "COMBO:MAX";
        }
        else
        {
            _comboText.text = "COMBO:" + _comboCount;
        }


        if (_countStart._startCount < 0)
        {
            //タイマーを減らす
            _timmer -= Time.deltaTime;
        }

        //0になったらカウントを1減らす
        if(_timmer <= 0.0f)
        {
            _time--;
            _levelTimmer++;
            
            if(_levelTimmer >= 20 && _gameLevel <= 3)
            {
                _levelScale += 0.5f;
                _gameLevel++;
                _levelTimmer = 0;

                _soundManager.LevelUpSE();
            }
            
            _timmer = _gameLevel;
        }

        //テキスト用タイマー
        _secondT =  _time / 100;
        _secondS = (_time - (100 * _secondT)) / 10;
        _secondF = _time - (100 * _secondT + 10 * _secondS);

        //時間が切れたら
        if(_time <= 0)
        {
            _soundManager.FinishSE();

            _fadeScripts.LoadButton();
        }
    }
}
