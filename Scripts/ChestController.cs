using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Player player;
    private int[] goldEarned = { 100, 150, 200, 250 };
    private string[] itemName = { "Phosphorus powder", "Powdered ruby", "Gold of Kings", "Water of Philosophers" };
    int rand;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player.goldAmount += goldEarned[Random.Range(1, 4)];
            rand = Random.Range(1, 100);
            if(rand < 50)
            {
                player.phosCount += 1;
                StartCoroutine(player.GetItem(itemName[0]));
            } else if(50 < rand && rand < 75) {
                player.prCount += 1;
                StartCoroutine(player.GetItem(itemName[1]));
            } else if (75 < rand && rand < 90)
            {
                player.gokCount += 1;
                StartCoroutine(player.GetItem(itemName[2]));
            } else
            {
                player.wofCount += 1;
                StartCoroutine(player.GetItem(itemName[3]));
            }
            FindObjectOfType<AudioManager>().Play("ChestPickup");
            Destroy(gameObject);
        }
    }
}