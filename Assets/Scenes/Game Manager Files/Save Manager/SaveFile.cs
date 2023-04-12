using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class SaveFile
{
    private string path;
    private string[] data;

    private enum WriteType
    {
        AppendAllLines,
        AppendAllText
    }

    private const string DevelopmentPath = "./Assets/Scenes/Game Manager Files/Save Manager";

    public SaveFile(string fileName, bool freshFile = false)
    {
        string rootPath = Application.isEditor ? DevelopmentPath : Application.dataPath;

        if (!Directory.Exists($"{rootPath}/Saves"))
            Directory.CreateDirectory($"{rootPath}/Saves");

        path = $"{rootPath}/Saves/{fileName}.txt";

        if (freshFile)
            Destroy();

        if (!File.Exists(path))
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
            WriteInternal(WriteType.AppendAllLines, arr: data);
        }
        else
        {
            WriteInternal(WriteType.AppendAllText, single:toWrite);
        }

        Load();
        return true;
    }

    public string GetValue(string search)
    {
        Load();
        int index = Search(search);

        if (index == -1)
            return null;

        string line = data[index];
        return line.Split("=")[1];
    }
    
    private string[] Load()
    {
        while (true)
        {
            try
            {
                data = File.ReadAllLines(path);
                break;
            }
            catch (Exception e)
            {
                Wait();
            }
        }
        
        return data;
    }

    private void WriteInternal(WriteType type, string single = null, string[] arr = null)
    {
        while (true)
        {
            try
            {
                if (type == WriteType.AppendAllText)
                    File.AppendAllText(path, single + "\n");
                else
                    File.AppendAllLines(path, arr);
                
                break;
            }
            catch (Exception e)
            {
                Wait();
            }
        }
    }

    private async void Wait()
    {
        while (IsFileLocked())
        {
            await Task.Delay(5); 
        }
    }

    private bool IsFileLocked()
    {
        try
        {
            using FileStream stream = File.Open(path, FileMode.Open);
            stream.Close();
        }
        catch (Exception e)
        {
            return true;
        }

        return false;
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