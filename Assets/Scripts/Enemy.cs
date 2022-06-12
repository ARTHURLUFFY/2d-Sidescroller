using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage;
    public float knockbackX;
    public float knockbackY;
    public float timeUntilMove;
    //[HideInInspector]
    private Player player;

    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.canBeHit)
            {
                if (damage>0)
                {
                    Instantiate(player.hurtParticle, player.transform.position, Quaternion.identity);
                    player.health -= damage;
                    player.canBeHit = false;
                    player.invisibleTimeCounter = player.invisibleTime;
                }
            } 
      
            
            player.knockbackCount = timeUntilMove;
            


            if (collision.transform.position.x <= transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-knockbackX, knockbackY);
                   // .velocity = new Vector2(-2f, 2f);
            }
            else if (collision.transform.position.x > transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(knockbackX, knockbackY);
            }
            //var player = collision.GetComponent<Player>();
        }
    }
}
