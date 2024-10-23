using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //スクリプト
    public CountStart _countStart;

    //ボール
    [SerializeField]
    private GameObject[] _colorObject;

    //スポーンタイマー
    private float _spawnTimmer;

    //スポーンする時間間隔
    private float _spawnInterval;

    //ランダムで決まるスポーン間隔の最大値、最小値
    [SerializeField]
    private float _maxInterval
                 ,_minInterval;

    [SerializeField]
    private Vector2[] _spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        _spawnInterval = Random.Range(_minInterval, _maxInterval);

        _spawnTimmer = _spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (_countStart._startCount >= 0) return;

        _spawnTimmer -= Time.deltaTime;

        if (_spawnTimmer < 0) 
        {
            //スポーン
            Instantiate(_colorObject[Random.Range(0, _colorObject.Length)], _spawnPos[Random.Range(0, _spawnPos.Length)],
                        Quaternion.identity);

            //次のスポーン間隔を決定
            _spawnInterval = Random.Range(_minInterval, _maxInterval);

            //タイマーリセット
            _spawnTimmer = _spawnInterval;
        }
    }
}
