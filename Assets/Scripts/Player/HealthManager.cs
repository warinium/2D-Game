using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public static int health=3;
    public Image[] Hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Awake()
    {
        health = 3;//Sinon après la premiere mort, health reste toujour à 0 puisque elle est statique
    }

    void Update()
    {
        foreach (Image IMG  in Hearts)
        {
            IMG.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++)
        {
            Hearts [i].sprite = fullHeart;
        }
    }
}
