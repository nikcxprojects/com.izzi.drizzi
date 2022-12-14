using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.EndGame();
    }
}
