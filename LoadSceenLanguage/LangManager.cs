using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

//Enums de cada idioma
public enum Language
{
    eng,
    spa
}

public class LangManager : MonoBehaviour
{
    //Enum para saber en que idioma va a ejecutarse
    public Language selectedLanguage;

    //Diccionario de Lenguaje, que va a contener otro diccionario que va a tomar como key un ID y como Value el texto correspondiente
    public Dictionary<Language, Dictionary<string, string>> LanguageManager;

    //URL para saber de donde descargar nuestro documento
    public string externalURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTRutt1AxkuKL6-8NdEpDmTyMSL40bOBjT6Q8w3Qp50ZCbI38lLMrM-ajaXZzSkv0Xbrh2lWrfCQVEj/pub?output=csv";

    //Un evento para actualizar cuando se tiene que cambiar el texto
    public event Action OnUpdate = delegate { };

    public static LangManager Instance;

    //Bajamos el archivo de internet
    void Awake()
    {
        StartCoroutine(DownloadCSV(externalURL));
                
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public LangManager GetInstance
    {
        get { return Instance; } 
    }

    
    
    /// <summary>
    /// En base a un ID devolvemos el texto correspondiente
    /// </summary>
    /// <param name="_id"></param>
    /// <returns></returns>
    public string GetTranslate(string _id)
    {
        if (!LanguageManager[Instance.selectedLanguage].ContainsKey(_id))
            return "Error 404: Not Found";
        else
            return LanguageManager[Instance.selectedLanguage][_id];
    }

    /// <summary>
    /// Bajamos el documento desde la pagina indicada por parametro y lo cortamos
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        LanguageManager = LanguageU.loadCodexFromString("www", www.downloadHandler.text);

        Instance.OnUpdate();
    }

    public void ChangeLanguage()
    {
        if (Instance.selectedLanguage == Language.eng)
            Instance.selectedLanguage = Language.spa;
        else
            Instance.selectedLanguage = Language.eng;

        Instance.OnUpdate();
    }


}
