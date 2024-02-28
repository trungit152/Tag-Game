using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] private DataSO data;
    System.Random rd;
    private void Start()
    {
        rd = new System.Random();
    }
    public void ButtonStart()
    {

        data.randNumber = rd.Next(0,2);
        for (int i = 0; i < data.players.Count; i++)
        {
            Destroy(data.players[i]);
        }
        data.players.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
