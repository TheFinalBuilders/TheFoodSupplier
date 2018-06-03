using UnityEngine;
using System.Collections;
using System.Linq;
using TFS.Model;
using TFS.Repository;

namespace TFS.UI
{
    public class CharacterCellPresenter : BaseCellPresenter<CharacterCellView, CharacterModel>
    {
        public void Start()
        {
            var characterRepository = new CharacterRepository();
            foreach(var model in characterRepository.GetALL()){
                AddCell(model);
            }
        }

        public override void InitializeCell(CharacterCellView view, CharacterModel model)
        {
            view.UpdateView(
                model.Name,
                model.Description
            );
        }
    }
}