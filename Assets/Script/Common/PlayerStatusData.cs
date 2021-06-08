using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


//숫자 1 2버튼을 눌러 HP를 조절하고 해당 값을 서버에 저장하여 공유함
public class PlayerStatusData : MonoBehaviourPun,IPunObservable
{
    [SerializeField]
    int myHP = 10;
    PhotonView view;
    [SerializeField]
    Image hpImg;

    void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    //동기화 메서드 (IPunObservable)
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //유저가 들어오면 본인은 계속 데이터를 writing 함
        if(stream.IsWriting)
        {
            //서버로 해당 데이터를 보냄
            stream.SendNext(myHP);
        }
        //클론은 데이터를 Receive함
        else
        {
            //보낸데이터와 같은 이름, 같은 타입으로 받을 수 있음
            myHP = (int)stream.ReceiveNext();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && view.IsMine)
        {
            myHP -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && view.IsMine)
        {
            myHP += 1;
        }
        hpImg.fillAmount = (float)myHP / 10.0f;

    }
}
