using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public int Direction;
    public bool spawner = false;
    private RoadTemplates templates;
    private Player player;
    private UpgradesScript uS;
    private int rand;
    [HideInInspector]
    public bool spawned = false;// 1 - left, 2 - right, 3 - top, 4 - bottom

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("RoadTemplates").GetComponent<RoadTemplates>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        uS = GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradesScript>();
        if (player.isAlive) {
            StartCoroutine(Spawn());
        } 
    }
    
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2 - (uS.upgrades[2].currentLevel * 0.2f));
        if (spawned == false && spawner)
        {
            if (Direction == 2)
            {
                rand = Random.Range(0, templates.leftRoad.Length);
                Instantiate(templates.leftRoad[rand], transform.position, templates.leftRoad[rand].transform.rotation);
            }
            else if (Direction == 3)
            {
                rand = Random.Range(0, templates.bottomRoad.Length);
                Instantiate(templates.bottomRoad[rand], transform.position, templates.bottomRoad[rand].transform.rotation);
            }
            else if (Direction == 4)
            {
                rand = Random.Range(0, templates.topRoad.Length);
                Instantiate(templates.topRoad[rand], transform.position, templates.topRoad[rand].transform.rotation);
            }
            spawned = true;
        }
    }
}
