using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{


    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;
    public float length = 38.4f*3.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mainCam.position.x>middleBG.position.x)
        {
            sideBG.position = middleBG.position + Vector3.right * length;
        }
        if(mainCam.position.x<middleBG.position.x)
        {
            sideBG.position = middleBG.position + Vector3.left * length;
        }

        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform temp = middleBG;
            middleBG = sideBG;
            sideBG = temp;
        }



    }
}
