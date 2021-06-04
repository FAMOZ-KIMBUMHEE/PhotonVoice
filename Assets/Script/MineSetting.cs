using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class MineSetting : MonoBehaviour
{
    PhotonView view;
    CameraWork cameraWork;

    // Start is called before the first frame update
    void Awake()
    {
        view = GetComponent<PhotonView>();
        cameraWork = GetComponent<CameraWork>();

        if(view.IsMine)
        {
            cameraWork.followOnStart = true;
        }
    }
    
}
