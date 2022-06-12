using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWalls : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().color = new Color(child.GetComponent<SpriteRenderer>().color.r, child.GetComponent<SpriteRenderer>().color.g, child.GetComponent<SpriteRenderer>().color.b, 0.7f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().color = new Color(child.GetComponent<SpriteRenderer>().color.r, child.GetComponent<SpriteRenderer>().color.g, child.GetComponent<SpriteRenderer>().color.b, 1f);
        }
    }

}
