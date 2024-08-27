using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerManager.lastCheckpointsPos=transform.position;
            GetComponent<SpriteRenderer>().color = Color.white;
            AudioManager.instance.Play("CheckPoint");
            PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
        }
    }
}
