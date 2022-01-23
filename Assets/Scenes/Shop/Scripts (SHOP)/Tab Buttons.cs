using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabButtons : MonoBehaviour
{

    public Text theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = Color.yellow; //Or however you do your color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.white; //Or however you do your color
    }
}
