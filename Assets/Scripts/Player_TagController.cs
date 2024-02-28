using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_TagController : MonoBehaviour
{
    [SerializeField] private GameObject playerTag;
    private bool isTagged = false;
    private bool canTag = true;
    private float coolDown = 1f;
    public static Player_TagController Instance;
    [SerializeField] private DataSO data;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        data.players.Add(this.gameObject);
    }
    public void PlayClick()
    {
        if (this.gameObject == data.players[data.randNumber])
        {
            this.isTagged = true;
            GameController.Instance.count = true;
        }
    }
    void Update()
    {
        CoolDown();
        playerTag.SetActive(isTagged);
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
