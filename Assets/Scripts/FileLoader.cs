using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileLoader
{
    public static string[] LoadAudioFiles(string directoryName){
        string path = Application.dataPath + "/" + directoryName;
        string[] mp3files = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories);
        string[] wavfiles = Directory.GetFiles(path, "*.wav", SearchOption.AllDirectories);
        string[] oggfiles = Directory.GetFiles(path, "*.ogg", SearchOption.AllDirectories);
        string[] files1 = new string[mp3files.Length + wavfiles.Length];
        mp3files.CopyTo(files1, 0);
        wavfiles.CopyTo(files1, mp3files.Length);
        string[] audiofiles = new string[files1.Length + oggfiles.Length];
        files1.CopyTo(audiofiles, 0);
        oggfiles.CopyTo(audiofiles, files1.Length);
        
        return audiofiles;
    }

    public static void ShowAllFilesNameWithOutExtension(string[] str){
        for (int i = 0; i < str.Length; i++){
            Debug.Log(Path.GetFileNameWithoutExtension(str[i]));
        }
    }

    public static void ShowAllFilesName(string[] str){
        for (int i = 0; i < str.Length; i++){
            Debug.Log(str[i]);
        }
    }

    public static string ShowFileName(string name){
        return Path.GetFileNameWithoutExtension(name);
    }
}
