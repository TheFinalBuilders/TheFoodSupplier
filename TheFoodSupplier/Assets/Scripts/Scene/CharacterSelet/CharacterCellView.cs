using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TFS.UI
{
    public class CharacterCellView : MonoBehaviour
    {
        [SerializeField]
        private GameObject ShowArea = null;

        [SerializeField]
        private Text Name = null; 

        [SerializeField]
        private Text Description = null;

        [SerializeField]
        private Button okButton;
        public Button.ButtonClickedEvent OnSelectCharacter{
            get { return okButton.onClick; }
        }

        public void UpdateView(GameObject prefab, string name, string description)
        {
            var instance = Instantiate(prefab);
            instance.transform.SetParent(ShowArea.transform,false);

            this.Name.text = name;
            this.Description.text = description;
        }
    }

}