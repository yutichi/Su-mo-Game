using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountStart : MonoBehaviour
{
    //�X�N���v�g
    public SoundManager _soundManager;

    //�X�^�[�g�̃J�E���g�_�E��
    [SerializeField]
    public int _startCount;

    //�J�E���g�_�E���p�^�C�}�[
    private float _countTimmer = 1f;

    //�J�E���g�_�E���e�L�X�g
    [SerializeField]
    private TextMeshProUGUI _countText;

    // Start is called before the first frame update
    void Start()
    {
        _countTimmer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        _countTimmer -= Time.deltaTime;

        if( _startCount <= 3 && _startCount >= 1)
        {
            //�J�E���g�_�E���e�L�X�g��\��
            _countText.text = _startCount.ToString();
        }
        else if(_startCount == 0)
        {
            //�X�^�[�g�e�L�X�g��\��
            _countText.text = "START";

            _soundManager.StartSE();
        }
        else
        {
            //�J�E���g�_�E���e�L�X�g��\��
            _countText.text = "";
        }

        if(_countTimmer <= 0f && _startCount > -1)
        {
            //�X�^�[�g�J�E���g���P���炷
            _startCount--;

            //�^�C�}�[��߂�
            _countTimmer = 1;
        }
    }
}
