using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : MonoBehaviour
{
    public Button continueBtn;
    private string[] selectSound = { "Select1", "Select2", "Select3" };

    void Start()
    {
        Button btn = continueBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        FindObjectOfType<AudioManager>().Play(selectSound[Random.Range(0, 2)]);
        Loader.Load(Loader.Scene.MainMenu);
    }
}
