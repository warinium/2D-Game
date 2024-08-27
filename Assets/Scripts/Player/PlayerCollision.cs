using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{


    private void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            GameOver();
        }
    }

    public bool isInvincible = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
       
        if (collision.transform.tag == "Enemy" && !isInvincible)
        {
            
            TakeDammage();
                
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);//Ennemy and player layer index, disable collisions
     
        GetComponent<Animator>().SetLayerWeight( 1,1);//Layer 1  and value 1

        isInvincible = true;

        yield return new WaitForSeconds(3);

        isInvincible = false;
        GetComponent<Animator>().SetLayerWeight(1, 0);//Remove hurt annimation
        Physics2D.IgnoreLayerCollision(6, 8,false);//Re-Enable collision detection
    }


   void GameOver()
    {
        AudioManager.instance.Play("GameOver");
        PlayerManager.isGameOver = true;
        gameObject.SetActive(false);
    }
    public void TakeDammage()
    {
        AudioManager.instance.Play("Hurt");

        HealthManager.health--;

        if (HealthManager.health <= 0)
        {
            GameOver();
        }
        else
        {
            StartCoroutine(GetHurt());
        }
    }
    
}
