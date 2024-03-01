using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    [SerializeField] private DataSO data;
    System.Random rd;
    private void Start()
    {
        rd = new System.Random();
    }
    public void CreateRoom()
    {
        for (int i = 0; i < data.players.Count; i++)
        {
            Destroy(data.players[i]);
        }
        data.players.Clear();
        PhotonNetwork.CreateRoom(createInput.text);

    }
    public void JoinRoom()
    {
        for (int i = 0; i < data.players.Count; i++)
        {
            Destroy(data.players[i]);
        }
        data.players.Clear();
        PhotonNetwork.JoinRoom(joinInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

}
