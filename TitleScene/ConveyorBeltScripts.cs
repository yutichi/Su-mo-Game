using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorBeltScripts : MonoBehaviour
{
    //�x���g�R���x�A�̑��x
    public float _speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //�x���g�R���x�A��̃I�u�W�F�N�g���ړ�������
        collision.transform.Translate(transform.right * _speed * Time.deltaTime);
    }
}
