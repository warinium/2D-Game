using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float TimeToLiveBullet = 0.8f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/

        if (collision.tag == "Zombie")
        {
            collision.GetComponent<Zombie>().TakeDammage(25);
            // Destroy(collision.gameObject);
            // Destroy(gameObject);
        }

       
    }

    private void Update()
    {
        
    }

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(TimeToLiveBullet);
        Destroy(gameObject);
    }
}
