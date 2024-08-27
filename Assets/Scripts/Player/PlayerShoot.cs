using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;

    public Animator animator;

    public GameObject bullet;

    public Transform bulletHole;
    public float ShootForce = 600;

    public float defaultGameHeat = 0.5f;
    float gameHeat = 0.5f;

    private void Awake()
    {
        gameHeat = defaultGameHeat;
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.shoot.performed += ctx => Fire();

    }

    private void Update()
    {
        if (gameHeat > 0)
        {
            gameHeat-= Time.deltaTime; ;
        }
    }
    private void Fire()
    {
        if (gameHeat > 0)
            return;

        gameHeat = defaultGameHeat;

        animator.SetTrigger("Shoot");
        GameObject go= Instantiate(bullet, bulletHole.position,bulletHole.rotation);

        if (GetComponent<playerMouvement>().isFacinfRight)
        {

            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * ShootForce);

        }
        else
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * ShootForce);
        }
    }
}
