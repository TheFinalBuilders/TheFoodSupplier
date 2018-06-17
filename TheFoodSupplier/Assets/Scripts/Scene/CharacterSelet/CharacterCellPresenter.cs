using UnityEngine;
using System.Collections;
using System.Linq;
using TFS.Model;
using TFS.Repository;

namespace TFS.UI
{
    public class CharacterCellPresenter : BaseCellPresenter<CharacterCellView, CharacterModel>
    {
        public override void Start()
        {
            base.Start();

            var characterRepository = new CharacterRepository();
            foreach(var model in characterRepository.GetALL()){
                AddCell(model);
            }
        }

        public override void InitializeCell(CharacterCellView view, CharacterModel model)
        {
            view.UpdateView(
                ResourceLoader.LoadSceneSprite(model.iconPath),
                model.Name,
                model.Description
            );
        }
    }
}