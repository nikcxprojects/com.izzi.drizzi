using UnityEngine;
using UnityEngine.UI;

public class Landscape : MonoBehaviour
{
    private Material Material { get; set; }

    private void Awake()
    {
        Material = GetComponent<Image>().material;
    }

    private void Update()
    {
        Material.mainTextureOffset = 0.1f * Time.time * new Vector2(0.3f, 0.6f);
    }
}
