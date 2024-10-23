using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSwitch : MonoBehaviour
{
    //�X�N���v�g
    public SoundManager _soundManager;

    //�J�o�[
    [SerializeField]
    private GameObject _cover;

    //�J�o�[�̊J�g���K�[
    private bool _coverTrigger;

    //�J�o�[�����鎝������
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
            //���ɖ߂�
            _cover.transform.rotation = Quaternion.Euler(0, 0, 0);
            _cover.transform.localScale = new Vector3(0.07f, 0.33f, 1f);

            _coverTrigger = false;
        }
    }
    
    public void SwitchTrigger()
    {
        if(_coverTrigger == false) 
        {
            //�W����]����
            _cover.transform.rotation = Quaternion.Euler(0, 0, 90);

            //�W�̃T�C�Y�����킹��
            _cover.transform.localScale = new Vector3(0.07f, 0.7f, 1f);

            //�^�C�}�[�쓮
            _coverTimmer = _coverTimmerSet;

            //�A�Ŗh�~
            _coverTrigger = true;

            _soundManager.ButtonSE();
        }
    }
}
