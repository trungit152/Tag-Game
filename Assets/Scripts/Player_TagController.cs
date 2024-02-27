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

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameController.Instance.tags.Add(isTagged);
        GameController.Instance.players.Add(this.gameObject);
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
            isTagged = !isTagged;
            coolDown = 1f;
        }
    }
}
