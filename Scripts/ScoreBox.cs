using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    //�X�N���v�g
    public SoundManager _soundManager;

    [SerializeField]
    private ColorType _boxColorType;

    private int _boxColorId;

    // Start is called before the first frame update
    void Start()
    {
        _boxColorId = (int)_boxColorType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //���ɓ������Ƃ�
        if (BallScripts._ballId == _boxColorId)
        {
            Collect();
        }
        else
        {
            Failed();
        }
 
        Debug.Log(GameManager._gameScore);

        //�I�u�W�F�N�g��j��
        Destroy(collision.gameObject);
    }

    //����
    public void Collect()
    {
        //�X�R�A����
        GameManager._gameScore += BallScripts._ballScore * GameManager._comboCount;

        //�R���{����(�ő�5)
        if(GameManager._comboCount >= 5)
        {
            GameManager._comboCount++;
        }

        _soundManager.CollectBallSE();
    }

    //���s
    public void Failed(int bombCheck = 0) 
    {
        //���e��������
        if (bombCheck == BallScripts._ballId)
        {
            //�X�R�A�����炷
            bombCheck = 1;

            _soundManager.BombBallSE();
        }
        //����ȊO
        else
        {
            //�X�R�A�����炳�Ȃ�
            bombCheck = 0;

            _soundManager.FailedBallSE();
        }

        //�X�R�A����
        GameManager._gameScore -= BallScripts._ballScore * bombCheck;

        //�R���{���Z�b�g
        GameManager._comboCount = 1;

    }
}
