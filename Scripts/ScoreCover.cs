using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCover : MonoBehaviour
{
    //�X�N���v�g
    public SoundManager _soundManager;

    [SerializeField]
    private ColorType _coverColorType
                     ,_missingColorType;


    private int _coverColorId
               ,_coverMissId;

    // Start is called before the first frame update
    void Start()
    {
        _coverColorId = (int)_coverColorType;
        _coverMissId = (int)_missingColorType;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //���ɓ������Ƃ�
        if (BallScripts._ballId == _coverMissId)
        {
            Failed();
        }
        else
        {
            Collect();
        }

        Debug.Log(GameManager._gameScore);

        //�I�u�W�F�N�g��j��
        Destroy(collision.gameObject);
    }

    //����
    public void Collect()
    {
        //���e�̎�
        if(BallScripts._ballId == _coverColorId)
        {
            //�X�R�A����
            GameManager._gameScore += BallScripts._ballScore * 2 * GameManager._comboCount;

            //�R���{�𑝂₷(�ő�5)
            if(GameManager._comboCount >= 5)
            {
                GameManager._comboCount++;
            }
        }
        //����ȊO�̎�
        else
        {
            GameManager._gameScore += BallScripts._ballScore / 2;
        }

        _soundManager.CollectBallSE();
    }

    //���s
    public void Failed()
    {
        //�X�R�A����
        GameManager._gameScore -= BallScripts._ballScore / 2;

        //�R���{���Z�b�g
        GameManager._comboCount = 1;

        _soundManager.FailedBallSE();
    }
}
