using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Transform upgradeTab, customizationTab, gemTab;
    public RectTransform tabs, homeButton;
    public Image shopLogo;


    // Start is called before the first frame update
    void Start()
    {
        upgradeTab.DOLocalMove(new Vector3(-42, -47, 0), 0.25f);
        tabs.DOAnchorPos(new Vector3(0, 303, 0), 0.3f);
        homeButton.DOAnchorPos(new Vector3(20, -26, 0), 0.3f);
        shopLogo.DOFade(100, 0.3f);
    }

    public void upgradeMenu()
    {
        upgradeTab.DOLocalMove(new Vector3(-43, -47, 0), 0.25f);
        customizationTab.DOLocalMove(new Vector3(300, -55, 0), 0.25f);
        gemTab.DOLocalMove(new Vector3(300, -55, 0), 0.25f);
    }

    public void customizationMenu()
    {
        upgradeTab.DOLocalMove(new Vector3(-400, -47, 0), 0.25f);
        customizationTab.DOLocalMove(new Vector3(-42, -55, 0), 0.25f);
        gemTab.DOLocalMove(new Vector3(300, -55, 0), 0.25f);
    }

    public void GemMenu()
    {
        upgradeTab.DOLocalMove(new Vector3(-400, -47, 0), 0.25f);
        customizationTab.DOLocalMove(new Vector3(-400, -55, 0), 0.25f);
        gemTab.DOLocalMove(new Vector3(-45, -55, 0), 0.25f);
    }
}
