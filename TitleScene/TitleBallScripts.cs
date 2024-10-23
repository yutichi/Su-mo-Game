using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBallScripts : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TitleManager._titleBallSwitch == true)
        {
            Destroy(this.gameObject);
        }

        //àÍíËílâ∫Ç…çsÇ¡ÇΩÇÁ
        if (this.transform.position.y < -20)
        {
            //îjâÛÇ∑ÇÈ
            Destroy(this.gameObject);
        }
    }
}
