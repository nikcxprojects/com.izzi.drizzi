using System;
using UnityEngine;
using UnityEngine.UI;

public class WheelMachine : MonoBehaviour
{
    public static WheelMachine Instance { get => FindObjectOfType<WheelMachine>(); }

    [SerializeField] Button pullBtn;
    public AnimationCurve speedCurve;
    public static Action<float> OnHandlePulled { get; set; }
    public static Func<float, int> OnWheelStopped { get; set; }

    public static float[] angles = new float[] { 360, 29.272f, 57.977f, 90.971f, 120.396f, 151.98f, 179.556f, 208.713f, 239.401f, 270.214f, 302.721f, 331.867f };
    public static int[] prizes = new int[] { 25, 30, 40, 10, 15, 45, 5, 50, 85, 55, 65, 75 };

    private void Awake()
    {
        pullBtn.onClick.AddListener(() =>
        {
            PullHandle();
        });

        OnWheelStopped += (angle) =>
        {
            pullBtn.interactable = true;
            
            int index = Array.IndexOf(angles, angle);
            int prize = prizes[index];

            return prize;
        };
    }

    public void PullHandle()
    {
        OnHandlePulled?.Invoke(angles[UnityEngine.Random.Range(0, angles.Length)]);
        pullBtn.interactable = false;
    }
}
