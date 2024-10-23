using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountStart : MonoBehaviour
{
    //スクリプト
    public SoundManager _soundManager;

    //スタートのカウントダウン
    [SerializeField]
    public int _startCount;

    //カウントダウン用タイマー
    private float _countTimmer = 1f;

    //カウントダウンテキスト
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
            //カウントダウンテキストを表示
            _countText.text = _startCount.ToString();
        }
        else if(_startCount == 0)
        {
            //スタートテキストを表示
            _countText.text = "START";

            _soundManager.StartSE();
        }
        else
        {
            //カウントダウンテキスト非表示
            _countText.text = "";
        }

        if(_countTimmer <= 0f && _startCount > -1)
        {
            //スタートカウントを１つ減らす
            _startCount--;

            //タイマーを戻す
            _countTimmer = 1;
        }
    }
}
