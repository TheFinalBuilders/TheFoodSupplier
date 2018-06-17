using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TFS.UI
{
    public class CharacterCellView : MonoBehaviour
    {
        [SerializeField]
        private Image Image = null;

        [SerializeField]
        private Text Name = null; 

        [SerializeField]
        private Text Description = null;

        [SerializeField]
        private Button okButton;

        public void UpdateView(Sprite sprite, string name, string description)
        {
            this.Image.sprite = sprite;
            this.Name.text = name;
            this.Description.text = description;
        }
    }

}