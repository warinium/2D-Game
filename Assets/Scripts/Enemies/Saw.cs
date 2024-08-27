using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float speed = 20;

    int direction = 1;

    public Transform leftCheck;
    public Transform rightCheck;


    void FixedUpdate()
    {
        Debug.DrawRay(rightCheck.position, Vector2.down,  Color.green);
        Debug.DrawRay(leftCheck.position, Vector2.down, Color.green);
        transform.Translate(Vector2.right * speed * direction * Time.fixedDeltaTime);

        if (Physics2D.Raycast(rightCheck.position, Vector2.down, 5) == false)
            direction = -1 ;

        if (Physics2D.Raycast(leftCheck.position, Vector2.down, 5) == false)
            direction = 1;
    }
}
