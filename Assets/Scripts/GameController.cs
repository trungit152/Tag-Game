using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<bool> tags;
    public List<GameObject> players;
    public static GameController Instance;
    private float time = 0f;
    private bool setable = true;
    private void Awake()
    {
        if(Instance == null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        System.Random rd = new System.Random();

    }
    private void Update()
    {
        SetTag();
    }
    private void SetTag()
    {
        time += Time.deltaTime;
        if (time > 2f && setable)
        {
            GameController.Instance.tags[RandomPlayer()] = true;
            setable = false;
        }
    }
    private int RandomPlayer()
    {
        System.Random rd = new System.Random();
        return rd.Next(1, 2);
    }
}
