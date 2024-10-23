using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorBeltScripts : MonoBehaviour
{
    //ベルトコンベアの速度
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
        //ベルトコンベア上のオブジェクトを移動させる
        collision.transform.Translate(transform.right * _speed * Time.deltaTime);
    }
}
