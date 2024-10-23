using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CoverSwitch _coverSwitch;

    //�N���b�N���ꂽ�Q�[���I�u�W�F�N�g��������ϐ�
    private GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;

                if(clickedGameObject.tag == "CoverSwitch")
                {
                    _coverSwitch.SwitchTrigger();
                }
            }

        }
    }
}
