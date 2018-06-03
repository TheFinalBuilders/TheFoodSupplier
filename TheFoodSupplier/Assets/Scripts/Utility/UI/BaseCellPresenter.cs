using UnityEngine;
using System.Collections;

namespace TFS.UI
{
    public abstract class BaseCellPresenter<CellView, Model> : MonoBehaviour
    {
        [SerializeField]
        GameObject CellPrefab = null;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        // セルの生成を行う
        public void AddCell(Model model)
        {
            Debug.Assert(CellPrefab != null, "cellprefab が設定されていません");

            var cell = GameObject.Instantiate(CellPrefab);
            cell.transform.SetParent(transform,false);

            CellView view = cell.GetComponent<CellView>();

            Debug.Assert(view != null,"view が設定されていません");

            InitializeCell(view, model);
        }

        // モデルの生成を行う
        public abstract void InitializeCell(CellView view, Model model);
    }
}