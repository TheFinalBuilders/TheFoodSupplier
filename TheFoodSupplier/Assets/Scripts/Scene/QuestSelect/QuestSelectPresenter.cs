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
            var list = questGroupRepository.GetALL().ToList();
            for (int i = 0;i < list.Count(); i++)
            {
                var model = list[i];
                if (model.IsOpen()){
                    AddCell(model);
                }
            }

            SoundManager.Instance.PlayBgm("kodoku");
        }

        public override void InitializeCell(QuestGroupView view, QuestGroupModel model)
        {
            view.UpdateView(model);
        }
    }
}