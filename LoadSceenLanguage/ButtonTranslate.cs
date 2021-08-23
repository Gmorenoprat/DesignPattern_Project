using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTranslate : MonoBehaviour
{
    public string ID;

    public LangManager manager;

    public Text myView;

    string _myText = "";


    private void Start()
    {
        _myText = myView.GetComponent<Text>().text;

        if (!manager)
        {
            manager = GameObject.Find("LanguageManager").GetComponent<LangManager>().GetInstance;
        }

        manager.OnUpdate += ChangeLang;
        try { ChangeLang(); }
        catch { return; }
    }


    void ChangeLang()
    {
        myView.text = manager.GetTranslate(ID);
    }

    private void OnDestroy()
    {
        manager.OnUpdate -= ChangeLang;
    }
}
