using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TFS.UI
{
    public class CharacterCellView : MonoBehaviour
    {
        [SerializeField]
        private Text Name = null; 

        [SerializeField]
        private Text Description = null;

        [SerializeField]
        private Button okButton;

        public void UpdateView(string name, string description)
        {
            this.Name.text = name;
            this.Description.text = description;
        }
    }

}