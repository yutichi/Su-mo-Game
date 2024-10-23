using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�X�N���v�g�@
    public CountStart _countStart;
    public FadeScripts _fadeScripts;
    public SoundManager _soundManager;

    //�X�R�A
    public static int _gameScore;

    //�X�R�A�R���{
    public static int _comboCount;

    //���Ԑ���(�ݒ�)
    public int _time;

    //�^�C�}�[
    public float _timmer;

    //�e�L�X�g�p�^�C�}�[
    private int _secondF
               ,_secondS
               ,_secondT;

    //Text�֘A
    [SerializeField]
    private TextMeshProUGUI _scoreText
                           ,_timeText
                           ,_levelText
                           ,_comboText;

    //��Փx
    private float _gameLevel
                 ,_levelScale;

    //��Փx�p�^�C�}�[
    private int _levelTimmer;

    //�t�F�[�h���
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
        //�Q�[�����x(��Փx���オ��Ƒ����Ȃ�)
        Time.timeScale = _levelScale;

        //�X�R�A�̉�������
        if(_gameScore < 0)
        {
            _gameScore = 0;
        }

        //Text�֘A
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
            //�^�C�}�[�����炷
            _timmer -= Time.deltaTime;
        }

        //0�ɂȂ�����J�E���g��1���炷
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

        //�e�L�X�g�p�^�C�}�[
        _secondT =  _time / 100;
        _secondS = (_time - (100 * _secondT)) / 10;
        _secondF = _time - (100 * _secondT + 10 * _secondS);

        //���Ԃ��؂ꂽ��
        if(_time <= 0)
        {
            _soundManager.FinishSE();

            _fadeScripts.LoadButton();
        }
    }
}
