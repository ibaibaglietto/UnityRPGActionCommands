using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class LangResolverScript : MonoBehaviour
{
    private const char Separator = '$';
    private readonly Dictionary<string, string> _lang = new Dictionary<string, string>();
    string path = @"F:\UnityGames\RPG\RPG\Assets\Lang\Resources\";
    private SystemLanguage _language; private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        ReadProperties();
        Debug.Log(_lang.Count);
        Debug.Log(_lang.Keys.First());
        Debug.Log(_lang.Values.First());
        Debug.Log("á ó í ñ");
        Debug.Log(ResolveText(_lang.Keys.First()));
    }
    private void ReadProperties()
    {
        if(gameObject.GetComponent<CurrentDataScript>().language == 1) _language = SystemLanguage.English;
        else if (gameObject.GetComponent<CurrentDataScript>().language == 2) _language = SystemLanguage.Spanish;
        else _language = SystemLanguage.Basque;
        var file = File.ReadAllText(path + _language.ToString() + ".txt", Encoding.UTF8);
        //var file = Resources.Load<TextAsset>(_language.ToString());
        foreach (var line in file.Split('\n'))
        {
            var prop = line.Split(Separator);
            _lang[prop[0]] = prop[1];
        }
    }

    public string ResolveText(string id)
    {
        return _lang[id];
    }
}
