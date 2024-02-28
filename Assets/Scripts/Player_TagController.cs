using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_TagController : MonoBehaviour
{
    [SerializeField] private GameObject playerTag;
    private bool isTagged = false;
    private bool canTag = true;
    private float coolDown = 1f;
    public static Player_TagController Instance;
    [SerializeField] private DataSO data;
    private float time = 0f;
    private bool setable = true;
    System.Random rd;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rd = new System.Random();
        data.players.Add(this.gameObject);
    }
    void Update()
    {
        CoolDown();
        playerTag.SetActive(isTagged);
        SetTag();
    }
    private void SetTag()
    {
        time += Time.deltaTime;
        if (time > 2f && setable)
        {
            if (this.gameObject == data.players[data.randNumber])
            {
                this.isTagged = true;
                setable = false;
            }
        }
    }
    private void CoolDown()
    {
        if (coolDown > 0f)
        {
            coolDown -= Time.deltaTime;
            canTag = false;
        }
        else
        {
            coolDown = 0f;
            canTag = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canTag)
        {
            Debug.Log("ok1");
            isTagged = !isTagged;
            coolDown = 1f;
        }
    }
    public void ButtonStart1()
    {
        Debug.Log("ok");
    }
}
