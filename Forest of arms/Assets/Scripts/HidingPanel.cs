using UnityEngine;
using UnityEngine.EventSystems;

public class HidingPanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public void OnPointerClick(PointerEventData eventData)
    {
        panel.gameObject.SetActive(false);
    }
}
