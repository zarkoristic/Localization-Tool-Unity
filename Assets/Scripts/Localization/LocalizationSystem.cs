using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem
{
    public enum Language
    {
        English,
        Chinese
    }

    public static Language language = Language.English;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedCHI;

    public static bool isInit;
    public static CSVLoader csvLoader;

    public static void Init()
    {
        csvLoader = new CSVLoader();

        csvLoader.LoadCSV();

        UpdateDictionary();

        isInit = true;
    }
    public static void UpdateDictionary()
    {
        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedCHI = csvLoader.GetDictionaryValues("chi");
    }

    public static Dictionary<string, string> GetDictionaryForEditor()
    {
        if (!isInit) { Init(); }
        return localisedEN;
    }

    public static string GetLocalisedValues(string key)
    {
        if (!isInit) { Init(); }

        string value = key;
        switch (language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                if (value == null) { Debug.Log("Key was not found in dictonary!!"); }
                break;
            case Language.Chinese:
                localisedCHI.TryGetValue(key, out value);
                if (value == null) { Debug.Log("Key was not found in dictonary!!"); }
                break;
        }
        return value;
    }

    public static void Add(string key, string value)
    {
        if (value.Contains("\"")) { value.Replace('"', '\"'); }

        if (csvLoader == null) { csvLoader = new CSVLoader(); }

        csvLoader.LoadCSV();
        csvLoader.Add(key, value);
        csvLoader.LoadCSV();

        UpdateDictionary();
    }

    public static void Replace(string key, string value)
    {
        if (value.Contains("\"")) { value.Replace('"', '\"'); }

        if (csvLoader == null) { csvLoader = new CSVLoader(); }

        csvLoader.LoadCSV();
        csvLoader.Edit(key, value);
        csvLoader.LoadCSV();

        UpdateDictionary();
    }

    public static void Remove(string key)
    {
        if (csvLoader == null) { csvLoader = new CSVLoader(); }

        csvLoader.LoadCSV();
        csvLoader.Remove(key);
        csvLoader.LoadCSV();

        UpdateDictionary();
    }
}
