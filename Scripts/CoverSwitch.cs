using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSwitch : MonoBehaviour
{
    //スクリプト
    public SoundManager _soundManager;

    //カバー
    [SerializeField]
    private GameObject _cover;

    //カバーの開閉トリガー
    private bool _coverTrigger;

    //カバーが閉じる持続時間
    [SerializeField]
    private float _coverTimmerSet;

    private float _coverTimmer;



    // Start is called before the first frame update
    void Start()
    {
        _coverTrigger = false;

        _coverTimmer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_coverTimmer > 0)
        {
            _coverTimmer -= Time.deltaTime;
        }

        if(_coverTimmer < 0 && _coverTrigger == true)
        {
            //元に戻す
            _cover.transform.rotation = Quaternion.Euler(0, 0, 0);
            _cover.transform.localScale = new Vector3(0.07f, 0.33f, 1f);

            _coverTrigger = false;
        }
    }
    
    public void SwitchTrigger()
    {
        if(_coverTrigger == false) 
        {
            //蓋を回転する
            _cover.transform.rotation = Quaternion.Euler(0, 0, 90);

            //蓋のサイズを合わせる
            _cover.transform.localScale = new Vector3(0.07f, 0.7f, 1f);

            //タイマー作動
            _coverTimmer = _coverTimmerSet;

            //連打防止
            _coverTrigger = true;

            _soundManager.ButtonSE();
        }
    }
}
