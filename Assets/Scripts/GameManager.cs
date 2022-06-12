using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public float timeToRespawn;

    public int coins;

    //UI
    public Text coinText;
    //hearts
    public Sprite heartFull, heartHalf, heartEmpty;
    public Image heart1, heart2, heart3;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        switch(player.health)
        {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                break;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }

    IEnumerator Destroy()
    {
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(timeToRespawn);

        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);
    }
}
