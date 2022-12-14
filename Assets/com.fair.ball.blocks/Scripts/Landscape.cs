using UnityEngine;
using UnityEngine.UI;

public class Landscape : MonoBehaviour
{
    private Material Material { get; set; }
    [SerializeField] Vector2 dir;
    [SerializeField] float speed;

    private void Awake()
    {
        Material = GetComponent<Image>().material;
    }

    private void Update()
    {
        Material.mainTextureOffset = speed * Time.time * dir;
    }
}
