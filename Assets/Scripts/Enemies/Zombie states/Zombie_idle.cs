using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_idle : StateMachineBehaviour
{

    Transform target;
    Transform zombienBorderCheck;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        zombienBorderCheck = animator.GetComponent<Zombie>().borderCheck;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (Physics2D.Raycast(zombienBorderCheck.position, Vector2.down, 2f) == false)
        {
            //animator.SetBool("isChasing", false);
            return;
        }

        float distance = Vector2.Distance(target.position, animator.transform.position);
        bool ischassing = distance < 10 && HealthManager.health>0;
 
        animator.SetBool("isChasing", ischassing);

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioManager.instance.Play("ZombieChassing");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       //  Implement code that processes and affects root motion
    }

     //OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
