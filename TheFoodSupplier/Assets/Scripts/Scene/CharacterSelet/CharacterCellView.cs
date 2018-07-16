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

        public void UpdateView(GameObject prefab, string name, string description)
        {
            var instance = Instantiate(prefab);
            instance.transform.SetParent(Image.transform,false);

            this.Name.text = name;
            this.Description.text = description;
        }
    }

}