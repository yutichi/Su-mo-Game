using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //スクリプト
    public SoundManager _soundManager;

    //各シーン
    [SerializeField]
    private GameObject _titleScene
                      ,_ruleScene1
                      ,_ruleScene2
                      ,_fadeScene;

    //タイトル画面の各ボタン
    [SerializeField]
    private Button _startButton
                  ,_ruleButton
                  ,_exitButton;

    //タイトルのボールの表示、非表示
    public static bool _titleBallSwitch;

    // Start is called before the first frame update
    void Start()
    {
        _titleScene.SetActive(true);
        _ruleScene1.SetActive(false);
        _ruleScene2.SetActive(false);
        _fadeScene.SetActive(true);

        _titleBallSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //スタートボタン
    public void StartButton()
    {
        _soundManager.ButtonSE();

        //シーン切り替え
        SceneManager.LoadScene("GameScene");

        //連打防止
        _startButton.interactable = false;
    }

    //ルール表示ボタン
    public void OpenRuleButton()
    {
        _soundManager.ButtonSE();

        //ルールの表示
        _titleScene.SetActive(!_titleScene.activeSelf);
        _ruleScene1.SetActive(!_ruleScene1.activeSelf);

        //ボールの非表示
        _titleBallSwitch = !_titleBallSwitch;
    }

    //ルール閉じるボタン
    public void CloseRuleButton()
    {
        _soundManager.ButtonSE();

        //ルールの非表示
        _titleScene.SetActive(!_titleScene.activeSelf);
        _ruleScene1.SetActive(false);
        _ruleScene2.SetActive(false);

        //ボールの表示
        _titleBallSwitch = !_titleBallSwitch;
    }


    //ルールのページ切り替えボタン
    public void RulePage()
    {
        _soundManager.ButtonSE();

        //ページ切り替え
        _ruleScene1.SetActive(!_ruleScene1.activeSelf);
        _ruleScene2.SetActive(!_ruleScene2.activeSelf);
    }

    //ゲーム終了ボタン
    public void ExitButton()
    {
#if UNITY_EDITOR

        //ゲーム終了
        UnityEditor.EditorApplication.isPlaying = false;
#else

            //ゲーム終了
            Application.Quit();

#endif
    }

}
