using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue;
    public GameManager gm;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gm.coins += coinValue;
            gm.coinText.text = "Coins: " + gm.coins;
            Destroy(gameObject);
        }
    }

}
