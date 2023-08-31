using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string[] Files;
    [SerializeField]AudioSource audioSource;
    public int nowPlayAudioNum,lastPlayAudioNum;
    [SerializeField] TextMeshProUGUI answerTextMeshPro;
    [SerializeField]string defaultAnswerText;

    // Start is called before the first frame update
    void Start()
    {
        Files = FileLoader.LoadAudioFiles("AudioFiles");
        nowPlayAudioNum = 0;
        lastPlayAudioNum = 0;
    }

    public void PushRandomPlayButton(){
        if(Files[0] != null && Files[0] != ""){
            while(true){
                nowPlayAudioNum = Random.Range(0, Files.Length);
                if(nowPlayAudioNum != lastPlayAudioNum){
                    break;
                }
            }
            Debug.Log(nowPlayAudioNum);
            lastPlayAudioNum = nowPlayAudioNum;
            StartCoroutine(StreamPlayAudioFile(Files[lastPlayAudioNum]));
            answerTextMeshPro.text = defaultAnswerText;
        }
    }

    public void PushReplayButton(){
        if(Files[0] != null && Files[0] != ""){
            StartCoroutine(StreamPlayAudioFile(Files[lastPlayAudioNum]));
        }
    }

    public void PushAnswerButton(){
        if(Files[0] != null && Files[0] != ""){
            answerTextMeshPro.text = FileLoader.ShowFileName(Files[lastPlayAudioNum]);
        }
    }

    IEnumerator StreamPlayAudioFile(string fileName)
    {
        using(WWW www = new WWW("file:///" + fileName))
        {
            yield return www;

            audioSource.clip = www.GetAudioClip(false, true);
            Debug.Log("file:///" + fileName);
            audioSource.Play();
        }
    }
}
