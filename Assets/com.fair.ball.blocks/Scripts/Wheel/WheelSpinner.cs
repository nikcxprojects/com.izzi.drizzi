using UnityEngine;
using System.Collections;

using Random = UnityEngine.Random;

public class WheelSpinner : MonoBehaviour
{
    private void Awake()
    {
        WheelMachine.OnHandlePulled += (angle) =>
        {
            StartCoroutine(RotateMe(angle));
        };
    }

    IEnumerator RotateMe(float angle)
    {
        int fullCycleCount = Random.Range(5, 15);
        float elDistance = 0.0f;
        float totalDistance = 360.0f * fullCycleCount + angle;

        while (elDistance < totalDistance)
        {
            float time = elDistance / totalDistance;

            transform.rotation = Quaternion.Euler(Vector3.back * elDistance);
            elDistance = Mathf.MoveTowards(elDistance, totalDistance, WheelMachine.Instance.speedCurve.Evaluate(time) * Time.deltaTime);

            yield return null;
        }

        transform.localRotation = Quaternion.Euler(Vector3.back * angle);
        int prize = (int)WheelMachine.OnWheelStopped?.Invoke(angle);

        //GameManager.OnGameFinished?.Invoke(prize);
    }
}
