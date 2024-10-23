using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //�X�N���v�g
    public SoundManager _soundManager;

    //�e�V�[��
    [SerializeField]
    private GameObject _titleScene
                      ,_ruleScene1
                      ,_ruleScene2
                      ,_fadeScene;

    //�^�C�g����ʂ̊e�{�^��
    [SerializeField]
    private Button _startButton
                  ,_ruleButton
                  ,_exitButton;

    //�^�C�g���̃{�[���̕\���A��\��
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

    //�X�^�[�g�{�^��
    public void StartButton()
    {
        _soundManager.ButtonSE();

        //�V�[���؂�ւ�
        SceneManager.LoadScene("GameScene");

        //�A�Ŗh�~
        _startButton.interactable = false;
    }

    //���[���\���{�^��
    public void OpenRuleButton()
    {
        _soundManager.ButtonSE();

        //���[���̕\��
        _titleScene.SetActive(!_titleScene.activeSelf);
        _ruleScene1.SetActive(!_ruleScene1.activeSelf);

        //�{�[���̔�\��
        _titleBallSwitch = !_titleBallSwitch;
    }

    //���[������{�^��
    public void CloseRuleButton()
    {
        _soundManager.ButtonSE();

        //���[���̔�\��
        _titleScene.SetActive(!_titleScene.activeSelf);
        _ruleScene1.SetActive(false);
        _ruleScene2.SetActive(false);

        //�{�[���̕\��
        _titleBallSwitch = !_titleBallSwitch;
    }


    //���[���̃y�[�W�؂�ւ��{�^��
    public void RulePage()
    {
        _soundManager.ButtonSE();

        //�y�[�W�؂�ւ�
        _ruleScene1.SetActive(!_ruleScene1.activeSelf);
        _ruleScene2.SetActive(!_ruleScene2.activeSelf);
    }

    //�Q�[���I���{�^��
    public void ExitButton()
    {
#if UNITY_EDITOR

        //�Q�[���I��
        UnityEditor.EditorApplication.isPlaying = false;
#else

            //�Q�[���I��
            Application.Quit();

#endif
    }

}
