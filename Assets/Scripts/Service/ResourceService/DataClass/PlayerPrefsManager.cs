using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

public class PlayerPrefsManager
{
    public static PlayerPrefsManager Instance { get; } = new PlayerPrefsManager();

    private PlayerPrefsManager()
    {
    }

    public void SaveData(string keyName, object data)
    {
        Type dataType = data.GetType();
        foreach (FieldInfo info in dataType.GetFields())
        {
            string saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" + info.Name;
            SaveValue(saveKeyName, info.GetValue(data));
        }
    }

    private void SaveValue(string keyName, object value)
    {
        if (value == null) return;
        Type fieldType = value.GetType();

        if (fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int) value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float) value);
        }
        else if (fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if (fieldType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool) value ? 1 : 0);
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            if (value is not IList list) return;
            PlayerPrefs.SetInt(keyName, list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                SaveValue(keyName + i, list[i]);
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            if (value is not IDictionary dictionary) return;
            PlayerPrefs.SetInt(keyName, dictionary.Count);


            int index = 0;
            foreach (DictionaryEntry dictionaryEntry in dictionary)
            {
                SaveValue(keyName + "_key_" + index, dictionaryEntry.Key);
                SaveValue(keyName + "_value_" + index, dictionaryEntry.Value);
                index++;
            }
        }
        else
        {
            SaveData(keyName, value);
        }
    }

    public object LoadData(string keyName, Type type)
    {
        object data = Activator.CreateInstance(type);

        foreach (FieldInfo info in type.GetFields())
        {
            string loadKeyName = keyName + "_" + type.Name + "_" + info.FieldType.Name + "_" + info.Name;
            info.SetValue(data, LoadValue(loadKeyName, info.FieldType));
        }

        return data;
    }

    private object LoadValue(string keyName, Type filedType)
    {
        if (filedType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName);
        }

        if (filedType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName);
        }

        if (filedType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName);
        }

        if (filedType == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyName) == 1;
        }

        if (typeof(IList).IsAssignableFrom(filedType))
        {
            int count = PlayerPrefs.GetInt(keyName);
            IList list = Activator.CreateInstance(filedType) as IList;
            for (int i = 0; i < count; i++)
            {
                list?.Add(LoadValue(keyName + i, filedType.GetGenericArguments()[0]));
            }

            return list;
        }

        if (typeof(IDictionary).IsAssignableFrom(filedType))
        {
            int count = PlayerPrefs.GetInt(keyName);
            IDictionary dictionary = Activator.CreateInstance(filedType) as IDictionary;
            Type[] types = filedType.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                dictionary?.Add(LoadValue(keyName + "_key_" + i, types[0]),
                    LoadValue(keyName + "_value_" + i, types[1]));
            }

            return dictionary;
        }
        

        return LoadData(keyName,filedType);
    }
}