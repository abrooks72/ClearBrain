using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //private MaterialApplier materialApplier;

    private void Awake()
    {
        //materialApplier = GetComponent<MaterialApplier>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //materialApplier.ApplyOther();
        print("Clicked");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // materialApplier.ApplyOrgiginal();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("Clicked");
        //Empty
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
