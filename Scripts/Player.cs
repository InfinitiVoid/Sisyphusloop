using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int nextMove;
    private Vector2 destination;
    private int poisonDamage;
    private int changeAmount;
    public int goldAmount;
    public int poisonPerSec = 10;
    public Text goldText;
    public Text poisonText;
    public Image blackScreen;
    public bool isAlive = true;
    private UpgradesScript uS;
    public int phosCount;
    public int prCount;
    public int gokCount;
    public int wofCount;
    private Collider2D startingCollider;
    public RoadSpawner road;
    public Text itemText;
    private string[] selectSound = { "Select1", "Select2", "Select3" };
    private Color c = new Color32(0,0,0,0);
    // 1 - right, 2 - top, 3 - bottom

    //item texts
    public Text phosText;
    public Text rubyText;
    public Text goldaText;
    public Text waterText;

    void Start()
    {
        transform.position = new Vector2(transform.position.x + 0.16f, transform.position.y);
        startingCollider = GameObject.FindGameObjectWithTag("StarterCollider").GetComponent<Collider2D>();
        uS = GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradesScript>();
        road = GameObject.FindGameObjectWithTag("StarterRoad").GetComponent<RoadSpawner>();
    }
    
    void FixedUpdate()
    {
        goldText.text = goldAmount.ToString();
        poisonText.text = poisonDamage.ToString();
        phosText.text = "x" + phosCount;
        rubyText.text = "x" + prCount;
        goldaText.text = "x" + gokCount;
        waterText.text = "x" + wofCount;
        if (poisonDamage >= 100)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            isAlive = false;
        }
        if (Input.GetButtonDown("Combine"))
        {
            Combine();
        }
        if (phosCount >= 4 && prCount >= 3 && gokCount >= 2 && wofCount >= 1)
        {
            Loader.Load(Loader.Scene.Ending);
        }   
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "TileSpawn" && isAlive)
        {
            if(col.gameObject.GetComponent<RoadSpawner>().Direction == 1)
            {
                nextMove = 1;
                col.enabled = false;
            } else if (col.gameObject.GetComponent<RoadSpawner>().Direction == 2)
            {
                col.enabled = false;
            }else if (col.gameObject.GetComponent<RoadSpawner>().Direction == 3)
            {
                nextMove = 3;
                col.enabled = false;
            }else if (col.gameObject.GetComponent<RoadSpawner>().Direction == 4)
            {
                nextMove = 2;
                col.enabled = false;
            }
            StartCoroutine(move());
        }
    }

    IEnumerator move()
    {
        yield return new WaitForSeconds(2 - (uS.upgrades[2].currentLevel * 0.2f));
        if(nextMove == 1)
        {
            destination = new Vector2(transform.position.x + 0.16f, transform.position.y);
        } else if(nextMove == 2)
        {
            destination = new Vector2(transform.position.x, transform.position.y + 0.16f);
        } else if(nextMove == 3)
        {
            destination = new Vector2(transform.position.x, transform.position.y + -0.16f);
        }
        goldAmount += 2 + 2* uS.upgrades[3].currentLevel;
        poisonDamage += poisonPerSec - uS.upgrades[0].currentLevel;
        transform.position = destination;
        if(poisonDamage > (100 - (poisonPerSec - uS.upgrades[0].currentLevel) * 5))
        {
            c.a += 0.2f;
            blackScreen.color = c;
        }
    }

    void Combine()
    {
        if(phosCount >= 1 && prCount >= 1)
        {
            phosCount--;
            prCount--;
            poisonDamage -= 30;
        }
    }
    public void Respawn()
    {
        phosCount = 0;
        prCount = 0;
        gokCount = 0;
        wofCount = 0;
        poisonDamage = 0;
        c.a = 0f;
        blackScreen.color = c;
        isAlive = true;
        FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0, 2)]);
        StartCoroutine(Startt());
    }

    IEnumerator Startt()
    {
        startingCollider.enabled = true;
        transform.position = new Vector2(-1.28f, 0f);
        yield return new WaitForSeconds(1.5f);
        road.spawned = false;
        StartCoroutine(road.Spawn());
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector2(transform.position.x + 0.16f, transform.position.y);
    }

    public IEnumerator GetItem(string itemName)
    {
        itemText.text = itemName;
        yield return new WaitForSeconds(1.5f);
        itemText.text = "";
    }
}
