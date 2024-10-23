using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //�X�N���v�g
    public CountStart _countStart;

    //�{�[��
    [SerializeField]
    private GameObject[] _colorObject;

    //�X�|�[���^�C�}�[
    private float _spawnTimmer;

    //�X�|�[�����鎞�ԊԊu
    private float _spawnInterval;

    //�����_���Ō��܂�X�|�[���Ԋu�̍ő�l�A�ŏ��l
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
            //�X�|�[��
            Instantiate(_colorObject[Random.Range(0, _colorObject.Length)], _spawnPos[Random.Range(0, _spawnPos.Length)],
                        Quaternion.identity);

            //���̃X�|�[���Ԋu������
            _spawnInterval = Random.Range(_minInterval, _maxInterval);

            //�^�C�}�[���Z�b�g
            _spawnTimmer = _spawnInterval;
        }
    }
}
