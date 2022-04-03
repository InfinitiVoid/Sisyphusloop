using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chest;
    public bool starter;
    private Player player;
    private int rand;
    private UpgradesScript uS;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        uS = GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradesScript>();
        rand = Random.Range(0, 100);
        if(rand >= 90-(5*uS.upgrades[1].currentLevel))
        {
            Instantiate(chest, transform.position, chest.transform.rotation);
        }
    }

    void FixedUpdate()
    {
        if (!player.isAlive)
        {
            if (!starter)
            {
                Destroy(gameObject);
            }
        }
    }
}
