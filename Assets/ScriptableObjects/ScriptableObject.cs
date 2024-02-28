using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/Data")]

public class DataSO : ScriptableObject
{
    public List<GameObject> players;
    public int randNumber;
}
