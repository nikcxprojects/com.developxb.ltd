using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] Transform[] records;

    private void Start() => UpdateBoard();

    public void UpdateBoard()
    {
        int[] scores = new int[records.Length];
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(2000, 6000);
        }

        var sortedScores = scores.OrderByDescending(i => i).ToArray();
        for(int i = 0; i < records.Length; i++)
        {
            Text leader = records[i].GetComponent<Text>();
            leader.text = $"{i+1}.{sortedScores[i]}";
        }
    }
}
