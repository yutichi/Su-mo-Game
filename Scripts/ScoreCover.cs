using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCover : MonoBehaviour
{
    //スクリプト
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
        //箱に入ったとき
        if (BallScripts._ballId == _coverMissId)
        {
            Failed();
        }
        else
        {
            Collect();
        }

        Debug.Log(GameManager._gameScore);

        //オブジェクトを破壊
        Destroy(collision.gameObject);
    }

    //成功
    public void Collect()
    {
        //爆弾の時
        if(BallScripts._ballId == _coverColorId)
        {
            //スコア増加
            GameManager._gameScore += BallScripts._ballScore * 2 * GameManager._comboCount;

            //コンボを増やす(最大5)
            if(GameManager._comboCount >= 5)
            {
                GameManager._comboCount++;
            }
        }
        //それ以外の時
        else
        {
            GameManager._gameScore += BallScripts._ballScore / 2;
        }

        _soundManager.CollectBallSE();
    }

    //失敗
    public void Failed()
    {
        //スコア減少
        GameManager._gameScore -= BallScripts._ballScore / 2;

        //コンボリセット
        GameManager._comboCount = 1;

        _soundManager.FailedBallSE();
    }
}
