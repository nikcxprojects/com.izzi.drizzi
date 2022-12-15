using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    private bool IsEnable { get; set; } = true;

    [SerializeField] Sprite active;
    [SerializeField] Sprite inactive;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            IsEnable = !IsEnable;
            AudioListener.pause = IsEnable;

            GetComponent<Image>().sprite = IsEnable ? active:inactive;
        });
    }
}
