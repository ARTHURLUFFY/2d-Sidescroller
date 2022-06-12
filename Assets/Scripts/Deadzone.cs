using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (player.transform.position.x, transform.position.y);
    }
    /*
     * Να δω αν μπορω να βαλω το τριγκερ απο εδω
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.gameObject.SetActive(false);
            //collision.gameObject.transform.position = FindObjectOfType<Player>().respawnPosition;
            //collision.gameObject.SetActive(true);
        }
    }
    */
}
