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
    private void Start()
    {
        rd = new System.Random();
    }
    private void Update()
    {
        timeText.text = System.Math.Round(countTime, 0).ToString();
        if (count)
        {
            countTime -= Time.deltaTime;
        }
        if (countTime < 0f)
        {
            count = false;
        }
    }
    public void ButtonStart()
    {

        data.randNumber = rd.Next(0,2);
        for (int i = 0; i < data.players.Count; i++)
        {
            Destroy(data.players[i]);
        }
        data.players.Clear();
        SceneManager.LoadScene("Loading");
    }
    public void Test()
    {
        int n = rd.Next(0, 2);
        Debug.Log(n.ToString());
    }
    public void Test2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
