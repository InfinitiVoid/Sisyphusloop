using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSceneUI : MonoBehaviour
{
    public Button playBtn;
    public Button creditsBtn;
    public Button exitBtn;
    private string[] selectSound = { "Select1", "Select2", "Select3" };

    void Start()
    {
        Button btn = playBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button btn2 = creditsBtn.GetComponent<Button>();
        btn2.onClick.AddListener(ToCredits);
        Button btn3 = creditsBtn.GetComponent<Button>();
        btn3.onClick.AddListener(Exit);
    }

    void TaskOnClick()
    {
        FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0, 2)]);
        Loader.Load(Loader.Scene.Controls);
    }

    void ToCredits()
    {
        FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0, 2)]);
        Loader.Load(Loader.Scene.Credits);
    }

    void Exit()
    {
        FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0, 2)]);
        Application.Quit();
    }
}
