using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   // public Sprite flagClosed;
    //public Sprite flagOpen;
    //private SpriteRenderer flag;
    private Animator anim;

    //isws to ftiaksw kapoia stigmi
    [Header("Θελεις να μπορει να γυριζει στα προηγουμενα checkpoints?")]
    public bool canReturn;
    [HideInInspector]
    public bool isFlagOpen ;

    // Start is called before the first frame update
    void Start()
    {
        isFlagOpen = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isFlagOpen)
        {
            anim.SetBool("isFlagOpen", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isFlagOpen = true;
            
        }
    }
}
