using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    //スクリプト
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
        //箱に入ったとき
        if (BallScripts._ballId == _boxColorId)
        {
            Collect();
        }
        else
        {
            Failed();
        }
 
        Debug.Log(GameManager._gameScore);

        //オブジェクトを破壊
        Destroy(collision.gameObject);
    }

    //成功
    public void Collect()
    {
        //スコア増加
        GameManager._gameScore += BallScripts._ballScore * GameManager._comboCount;

        //コンボ増加(最大5)
        if(GameManager._comboCount >= 5)
        {
            GameManager._comboCount++;
        }

        _soundManager.CollectBallSE();
    }

    //失敗
    public void Failed(int bombCheck = 0) 
    {
        //爆弾だったら
        if (bombCheck == BallScripts._ballId)
        {
            //スコアを減らす
            bombCheck = 1;

            _soundManager.BombBallSE();
        }
        //それ以外
        else
        {
            //スコアを減らさない
            bombCheck = 0;

            _soundManager.FailedBallSE();
        }

        //スコア減少
        GameManager._gameScore -= BallScripts._ballScore * bombCheck;

        //コンボリセット
        GameManager._comboCount = 1;

    }
}
