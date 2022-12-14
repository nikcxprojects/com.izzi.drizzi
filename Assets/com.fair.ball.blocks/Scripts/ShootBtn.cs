using UnityEngine;
using UnityEngine.EventSystems;

public class ShootBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    bool IsPressing { get; set; }

    private void Update()
    {
        if(!IsPressing)
        {
            return;
        }

        GameManager.Instance.Shoot();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressing = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsPressing = false;
    }
}
