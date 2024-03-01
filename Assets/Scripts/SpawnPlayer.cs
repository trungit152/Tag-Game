using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    void Start()
    {
        Vector2 randPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randPos, Quaternion.identity);
    }

    void Update()
    {

    }
}
