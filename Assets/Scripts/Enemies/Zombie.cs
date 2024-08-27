using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{

    GameObject target;
    public Transform borderCheck;
    public int EnemyHP = 100;
    public Animator animator;
    public bool isBoss=false;

    public GameObject endDoorAnimator;

    public Slider zombyHealthBar;

    private float playerDirection=1.0f;
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player");


        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        zombyHealthBar.maxValue = EnemyHP;

        zombyHealthBar.value = EnemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if( HealthManager.health > 0 && EnemyHP>0)
        {
           
            if (target.transform.position.x > transform.position.x)
        {
                playerDirection = 1.0f;
            }
        else
        {
                playerDirection =- 1.0f;
            }

            transform.localScale = new Vector2(transform.localScale.y * playerDirection, transform.localScale.y);
        }
    }

    public void TakeDammage(int damageAmount)
    {
        EnemyHP -= damageAmount;

        zombyHealthBar.value = EnemyHP;


        if (EnemyHP > 0)
        {
            animator.SetTrigger("Dammage");
            //animator.SetBool("IsChasing", true);

        }
        else
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Bullet").GetComponent<CapsuleCollider2D>(), GetComponent<Collider2D>());

            animator.SetTrigger("Death");
            GetComponent<Collider2D>().enabled = false;
            zombyHealthBar.gameObject.SetActive(false);
            this.enabled = false;

            if (isBoss)
            {
                endDoorAnimator.GetComponent<Animator>().SetTrigger("OpenDoor");
                AudioManager.instance.Play("OpenDoor");
            }

        }
    }


    public void PlayerDammage()
    {
        if(!target.GetComponent<PlayerCollision>().isInvincible && HealthManager.health >0)   
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>().TakeDammage();
    }
}
