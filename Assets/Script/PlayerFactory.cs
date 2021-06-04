using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerFactory : MonoBehaviour
{
    public GameObject[] playerPrefabs;

    void Start()
    {
        //접속 유저 생성
        if(playerPrefabs.Length != 0)
        {
            int rand = Random.Range(0, playerPrefabs.Length);
            PhotonNetwork.Instantiate(playerPrefabs[rand].name, new Vector3(9, 1, -3), Quaternion.identity,0);
        }
    }
}
