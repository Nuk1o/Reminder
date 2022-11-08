using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class write_read_json : MonoBehaviour
{
    private string SavePath;

    private void Awake()
    {
        SavePath = Path.Combine(Application.dataPath, "Tasks.nukio");
    }

    public void write_json()//Write
    {
        try
        {
            task_struct ts = new task_struct
            {
                _tasks = Singleton._tasks
            };
            string json = JsonUtility.ToJson(ts, true);
            File.WriteAllText(SavePath,json);
        }
        catch
        {
            Debug.Log("Error");
        }
    }

    public void read_json()//Read
    {
        try
        {
            string json = File.ReadAllText(SavePath);
            task_struct ts = JsonUtility.FromJson<task_struct>(json);
            Singleton._tasks = ts._tasks;
        }
        catch
        {
            Debug.Log("Error");
        }
        
    }
}

[System.Serializable]
public struct task_struct
{
    public List<GameObject> _tasks;
}
