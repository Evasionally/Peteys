using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

public class SaveFile
{
    private string path;
    private string[] data;

    public SaveFile(string fileName, bool freshFile = false)
    {
        path = $"./Assets/Scenes/Save Manager/Saves/{fileName}.txt";

        if (freshFile)
            Destroy();

        File.Create(path);
    }

    public bool Write(string name, string state)
    {
        string toWrite = $"{name}={state}";

        Load();
        int index = Search(name);
        if (index >= 0)
        {
            Destroy();

            data[index] = toWrite;
            File.AppendAllLines(path, data);
        }
        else
        {
            File.AppendAllText(path, toWrite + "\n");
        }

        Load();
        return true;
    }

    public string GetValue(string search)
    {
        int index = Search(search);

        if (index == -1)
            return null;

        string line = data[index];
        return line.Split("=")[1];
    }
    
    private string[] Load()
    {
        data = File.ReadAllLines(path);
        return data;
    }

    private int Search(string val)
    {
        if (data is not null)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].StartsWith(val))
                    return i;
            }
        }
        
        return -1;
    }

    public void Destroy()
    {
        File.Delete(path);
    }
}