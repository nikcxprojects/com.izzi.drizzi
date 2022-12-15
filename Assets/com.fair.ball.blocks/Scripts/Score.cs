using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void Awake()
    {
        Text textComponent = GetComponent<Text>();
        WheelSpinner.OnEndRolling += (value) =>
        {
            textComponent.text = $"SCORE: {value}";
        };

        textComponent.text = $"SCORE: {0}";
    }
}
