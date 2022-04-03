using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingDialogue : MonoBehaviour
{
    public Text sT;
    public Text oT;
    public string[] sDialogues;
    public string[] oDialogues;
    public GameObject objectt;

    void Start()
    {
        StartCoroutine(Dialogue());    
    }

    IEnumerator Dialogue()
    {
        for(int i = 0; i < sDialogues.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            sT.text = sDialogues[i];
            yield return new WaitForSeconds(2f);
            sT.text = "";
            yield return new WaitForSeconds(0.5f);
            oT.text = oDialogues[i];
            yield return new WaitForSeconds(2f);
            oT.text = "";
        }
        objectt.SetActive(false);
        Loader.Load(Loader.Scene.MainMenu);
    }
}
