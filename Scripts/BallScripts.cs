using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType
{
    Bomb = 0,
    Color_R = 1, 
    Color_G = 2, 
    Color_B = 3
}

public class BallScripts : MonoBehaviour
{
    //�X�N���v�g
    public BallDataBase _ballDataBase;

    public static int _ballId
                     ,_ballScore;

    [SerializeField]
    private ColorType _colorType;
    private int _colorTypeNum;

    // Start is called before the first frame update
    void Start()
    {
        //enum��int�ɕϊ�
        _colorTypeNum = (int)_colorType;
    }

    void Update()
    {
        //���l���ɍs������
        if(this.transform.position.y < -20)
        {
            //�j�󂷂�
            Destroy(this.gameObject);
        }

        for (int i = 0; i <= _ballDataBase._ballDataBase.Count; i++)
        {
            var ballData = _ballDataBase._ballDataBase[i];

            //�f�[�^�擾
            _ballId = ballData._colorId;
            _ballScore = ballData._score;

            //ID����v������~�߂�
            if (_ballId == _colorTypeNum)
            {
                Debug.Log(i + ":" + _ballId + ":" + _ballScore);
                return;
            }
        }
    }
}
