using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField]
    Button startButton = null;

    [SerializeField]
    Button skinButton = null;

	// Use this for initialization
	void Start()
	{
        startButton.onClick.AddListener(() =>
        {
            SceneMoveManager.Instance.MoveScene("QuestSelect", new QuestSelectSceneParamter());
        });

        skinButton.onClick.AddListener(() =>
        {
            SceneMoveManager.Instance.MoveScene("CharacterSelectScene", new CharacterSelectSceneParameter());
        });
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
