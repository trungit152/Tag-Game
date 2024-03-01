using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] private DataSO data;
    [SerializeField] private Text timeText;
    public bool count = false;
    private float countTime = 30f;
    System.Random rd;
    public bool GCfirstTag = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        rd = new System.Random();
    }
    private void Update()
    {
        timeText.text = System.Math.Round(countTime, 0).ToString();
        CounterTime();
    }
    public void PlayClick()
    {
        ChangeColor.Instance.DestroyMe();
        Debug.Log("doneClick");
        count = true;
        GCfirstTag = true;
        Player_TagController.Instance.SetTag();
    }
    private void CounterTime()
    {
        if (count)
        {
            countTime -= Time.deltaTime;
        }
        if (countTime < 0f)
        {
            count = false;
        }
    }
    public void Test2()
    {
        SceneManager.LoadScene("Start");
    }
}
