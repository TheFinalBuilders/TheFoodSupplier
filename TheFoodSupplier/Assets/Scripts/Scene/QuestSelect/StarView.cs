using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TFS.UI
{
    public class StarView : MonoBehaviour
    {

        [SerializeField]
        private Image Star1 = null;

        [SerializeField]
        private Image Star2 = null;

        [SerializeField]
        private Image Star3 = null;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateView(int currentVisible)
        {
            Debug.Assert(currentVisible <= 3 && currentVisible >= 0, "星の値が不正です");

            UpdateView(
                currentVisible >= 1,
                currentVisible >= 2,
                currentVisible >= 3
            );
        }

        public void UpdateView(bool visible1, bool visible2, bool visible3)
        {
            Star1.gameObject.SetActive(visible1);
            Star2.gameObject.SetActive(visible2);
            Star3.gameObject.SetActive(visible3);
        }
    }
}