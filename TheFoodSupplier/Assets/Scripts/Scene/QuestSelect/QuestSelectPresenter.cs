using UnityEngine;
using System.Collections;
using System.Linq;
using TFS.Model;
using TFS.Repository;

namespace TFS.UI
{
    public class QuestSelectPresenter : BaseCellPresenter<QuestGroupView, QuestGroupModel>
    {
        public override void Start()
        {
            base.Start();

            var questGroupRepository = new QuestGroupRepository();
            foreach (var model in questGroupRepository.GetALL())
            {
                AddCell(model);
            }
        }

        public override void InitializeCell(QuestGroupView view, QuestGroupModel model)
        {
            view.UpdateView(model);
        }
    }
}