using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class gameUIManager : MonoBehaviour
{
    public Transform gameCam;
    public RectTransform pauseButton, scoreText;


    // Start is called before the first frame update
    void Start()
    {
        gameCam.DOLocalMove(new Vector3(0, -16, 0), 1f).SetDelay(1);
        pauseButton.DOAnchorPos(new Vector3(27, -28, 0), .5f).SetDelay(1);
        scoreText.DOAnchorPos(new Vector3(0, 220, 0), .4f).SetDelay(1);
    }

   
}
