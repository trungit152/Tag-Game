using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_TagController : MonoBehaviour
{
    [SerializeField] private GameObject playerTag;
    private bool isTagged = false;
    private bool canTag = false;
    private float coolDown = 1f;
    public static Player_TagController Instance;
    [SerializeField] private DataSO data;
    private Renderer rend;
    public bool firstTag = true;
    System.Random rd;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rend =GetComponent<Renderer>();
        rd = new System.Random();
        data.players.Add(this.gameObject);
    }

    void Update()
    {
        CoolDown();
        playerTag.SetActive(isTagged);
    }
    public void SetTag()
    {
        {
            if (gameObject == data.players[1])
            {
                this.isTagged = true;
                Debug.Log("done");
            }
            canTag = true;
            firstTag = false;
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
            isTagged = !isTagged;
            coolDown = 1f;
        }
    }
    //E01C1C
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Color"))
        {
            rend.material.color = Random.ColorHSV();
        }
    }
    public void ButtonStart1()
    {
        Debug.Log("ok");
    }
}
