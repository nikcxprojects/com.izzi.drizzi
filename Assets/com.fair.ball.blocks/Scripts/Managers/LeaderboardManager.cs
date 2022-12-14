using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] Transform container;

    private void OnEnable() => UpdateBoard();

    public void UpdateBoard()
    {
        int[] scores = new int[container.childCount];
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(4500, 9999);
        }

        var sorted = scores.OrderByDescending(i => i).ToArray();

        for(int i = 0; i < container.childCount; i++)
        {
            Text leader = container.GetChild(i).GetChild(1).GetComponentInChildren<Text>();
            leader.text = string.Format("{0:0000}", sorted[i]);
        }
    }
}
