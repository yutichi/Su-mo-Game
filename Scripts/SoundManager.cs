using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource _audioSource;

    [SerializeField]
    public AudioClip _buttonSE
                    ,_collectBallSE
                    ,_failedBallSE
                    ,_bombBallSE
                    ,_levelUpSE
                    ,_startSE
                    ,_finishSE;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ButtonSE()
    {
        _audioSource.PlayOneShot(_buttonSE);
    }

    public void CollectBallSE()
    {
        _audioSource.PlayOneShot(_collectBallSE);
    }

    public void FailedBallSE()
    {
        _audioSource.PlayOneShot(_failedBallSE);
    }

    public void BombBallSE()
    {
        _audioSource.PlayOneShot(_bombBallSE);
    }

    public void LevelUpSE()
    {
        _audioSource.PlayOneShot(_levelUpSE);
    }

    public void StartSE()
    {
        _audioSource.PlayOneShot(_startSE);
    }

    public void FinishSE()
    {
        _audioSource.PlayOneShot(_finishSE);
    }
}
