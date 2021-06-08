using Photon.Voice.PUN;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class voiceEffect : MonoBehaviour
{
    PhotonVoiceView voiceView;
    [SerializeField] GameObject speakerIcon;
    private void Awake()
    {
        voiceView = GetComponent<PhotonVoiceView>();
    }

    //보이스 채팅 유무
    public bool GetSoundDetection()
    {
        return voiceView.IsRecording;
    }

    private void Update()
    {
        if(GetSoundDetection())
        {
            speakerIcon.SetActive(true);
        }
        else
        {
            speakerIcon.SetActive(false);
        }
    }

}
