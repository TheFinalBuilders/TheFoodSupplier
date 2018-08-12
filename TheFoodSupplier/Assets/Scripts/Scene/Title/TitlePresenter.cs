using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TFS.Repository;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField]
    Button startButton = null;

    [SerializeField]
    Button skinButton = null;

    [SerializeField]
    Button dataDeleteButton = null;

    [SerializeField]
    Button questClearButton = null;

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

        dataDeleteButton.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
            Application.Quit();
        });

        questClearButton.onClick.AddListener(() =>
        {
            var playerQuestRepository = new PlayerQuestRepository();
            foreach(var model in playerQuestRepository.GetALL()) {
                model.CurrentScore = 1000;
                model.CurrentStarNum = 1;
                playerQuestRepository.Set(model);
            }
        });

        SoundManager.Instance.PlayBgm("kodoku");
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
