using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{

    private UpgradesScript uS;
    private Player player;
    public GameObject upgradesPopup;
    //poison upgrades
    public Button b1;
    public Image i1;
    public Image i2;
    public Image i3;
    public Image i4;
    //chest upgrades
    public Button b2;
    public Image i12;
    public Image i22;
    public Image i32;
    public Image i42;
    //movement upgrades
    public Button b3;
    public Image i13;
    public Image i23;
    public Image i33;
    public Image i43;
    //gold upgrades
    public Button b4;
    public Image i14;
    public Image i24;
    public Image i34;
    public Image i44;
    //respawn button
    public Button reset;
    private string[] selectSound = { "Select1", "Select2", "Select3" };

    //texts
    public Text pUBT;
    public Text cUBT;
    public Text mUBT;
    public Text gUBT;

    void Start()
    {
        uS = GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradesScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //poison
        Button btn1 = b1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        //chest
        Button btn2 = b2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);
        //movement
        Button btn3 = b3.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick3);
        //gold
        Button btn4 = b4.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClick4);
        //restet
        Button btn5 = reset.GetComponent<Button>();
        btn5.onClick.AddListener(player.Respawn);
    }

    void FixedUpdate()
    {
        if (player.isAlive)
        {
            upgradesPopup.SetActive(false);
        } else
        {
            StartCoroutine(popups());
        }
        //upgrade buttons cost
        if (uS.upgrades[0].currentLevel < 4)
        {
            pUBT.text = uS.upgrades[0].cost[uS.upgrades[0].currentLevel].ToString();
        } else
        {
            pUBT.text = "MAX LVL";
        }
        if (uS.upgrades[1].currentLevel < 4)
        {
            cUBT.text = uS.upgrades[1].cost[uS.upgrades[1].currentLevel].ToString();
        }
        else
        {
            cUBT.text = "MAX LVL";
        }
        if (uS.upgrades[2].currentLevel < 4)
        {
            mUBT.text = uS.upgrades[2].cost[uS.upgrades[2].currentLevel].ToString();
        }
        else
        {
            mUBT.text = "MAX LVL";
        }
        if (uS.upgrades[3].currentLevel < 4)
        {
            gUBT.text = uS.upgrades[3].cost[uS.upgrades[3].currentLevel].ToString();
        }
        else
        {
            gUBT.text = "MAX LVL";
        }

        //its a fucking YandereDev looking ass code
        //poison
        if (uS.upgrades[0].currentLevel == 1)
        {
            i1.color = new Color(255, 255, 255, 100);
        }else if (uS.upgrades[0].currentLevel == 2)
        {
            i2.color = new Color(255, 255, 255, 100);
        }else if (uS.upgrades[0].currentLevel == 3)
        {
            i3.color = new Color(255, 255, 255, 100);
        }else if (uS.upgrades[0].currentLevel == 4)
        {
            i4.color = new Color(255, 255, 255, 100);
        }
        //chest
        if (uS.upgrades[1].currentLevel == 1)
        {
            i12.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[1].currentLevel == 2)
        {
            i22.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[1].currentLevel == 3)
        {
            i32.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[1].currentLevel == 4)
        {
            i42.color = new Color(255, 255, 255, 100);
        }
        //movement
        if (uS.upgrades[2].currentLevel == 1)
        {
            i13.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[2].currentLevel == 2)
        {
            i23.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[2].currentLevel == 3)
        {
            i33.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[2].currentLevel == 4)
        {
            i43.color = new Color(255, 255, 255, 100);
        }
        //gold
        if (uS.upgrades[3].currentLevel == 1)
        {
            i14.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[3].currentLevel == 2)
        {
            i24.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[3].currentLevel == 3)
        {
            i34.color = new Color(255, 255, 255, 100);
        }
        else if (uS.upgrades[3].currentLevel == 4)
        {
            i44.color = new Color(255, 255, 255, 100);
        }
    }

    void TaskOnClick1()
    {
        if(player.goldAmount > uS.upgrades[0].cost[uS.upgrades[0].currentLevel] && uS.upgrades[0].currentLevel < 4)
        {
            FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0,2)]);
            player.goldAmount -= uS.upgrades[0].cost[uS.upgrades[0].currentLevel];
            uS.upgrades[0].currentLevel++;
        }
    }

    void TaskOnClick2()
    {
        if (player.goldAmount > uS.upgrades[1].cost[uS.upgrades[1].currentLevel] && uS.upgrades[1].currentLevel < 4)
        {
            FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0, 2)]);
            player.goldAmount -= uS.upgrades[1].cost[uS.upgrades[1].currentLevel];
            uS.upgrades[1].currentLevel++;
        }
    }

    void TaskOnClick3()
    {
        if (player.goldAmount > uS.upgrades[2].cost[uS.upgrades[2].currentLevel] && uS.upgrades[2].currentLevel < 4)
        {
            FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0, 2)]);
            player.goldAmount -= uS.upgrades[2].cost[uS.upgrades[2].currentLevel];
            uS.upgrades[2].currentLevel++;
        }
    }

    void TaskOnClick4()
    {
        if (player.goldAmount > uS.upgrades[3].cost[uS.upgrades[3].currentLevel] && uS.upgrades[3].currentLevel < 4)
        {
            FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0, 2)]);
            player.goldAmount -= uS.upgrades[3].cost[uS.upgrades[3].currentLevel];
            uS.upgrades[3].currentLevel++;
        }
    }

    IEnumerator popups()
    {
        yield return new WaitForSeconds(1);
        upgradesPopup.SetActive(true);
    }
}
