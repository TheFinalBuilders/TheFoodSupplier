using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleButtonAnimator : MonoBehaviour {

    [SerializeField]
    Button targetUI = null;

    [SerializeField]
    float scaleX = 0.1f;

    [SerializeField]
    float scaleY = 0.1f;

    [SerializeField]
    float time = 0.4f;

	// Use this for initialization
	void Start () {

        // クリック時の処理
        targetUI.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCompleteHandler()
    {
        // ボタンの有効化をする
        targetUI.interactable = true;    
    }

    public void OnClick()
    {
        SoundManager.Instance.PlaySe("button");

        // ボタンの無効化をする
        targetUI.interactable = false;

        // アニメーションを行う
        iTween.PunchScale(
            targetUI.gameObject, 
            iTween.Hash(
                "x", scaleX, 
                "y", scaleY, 
                "time", time,
                "oncomplete", "OnCompleteHandler",
                "oncompletetarget", this.gameObject
            ));
    }


}
