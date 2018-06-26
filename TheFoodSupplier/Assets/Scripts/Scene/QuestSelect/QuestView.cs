using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TFS.Model;

namespace TFS.UI
{
    public class QuestView : MonoBehaviour
    {

        [SerializeField]
        private Text Name = null;

        [SerializeField]
        private Image image = null;

        [SerializeField]
        private StarView starView = null;

        [SerializeField]
        private Text scoreText = null;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateView(QuestModel model, PlayerQuestModel playerQuestModel = null) 
        {
            int currentVisible = 0;
            string score = "";
            if (playerQuestModel != null) {
                currentVisible = playerQuestModel.CurrentStarNum;
                score = playerQuestModel.CurrentScore.ToString();
            }
            
            UpdateView(
                model.Name,
                model.bannerFilename,
                currentVisible,
                score
            );
        }

        public void UpdateView(string name, string imageFilename, int currentVisible = 0, string score = "")
        {
            this.Name.text = name;
            this.image.sprite = ResourceLoader.LoadSceneSprite(imageFilename);

            if (this.starView != null)
            {
                this.starView.UpdateView(currentVisible);
            }

            if (this.scoreText != null) 
            {
                this.scoreText.text = score + "pt";
            }
        }
    }
}