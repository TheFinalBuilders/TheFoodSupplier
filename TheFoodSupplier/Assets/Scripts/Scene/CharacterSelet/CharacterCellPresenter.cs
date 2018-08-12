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
                if (model.IsOpen()) {
                    AddCell(model);
                }
            }

            SoundManager.Instance.PlayBgm("kodoku");
        }

        public override void InitializeCell(CharacterCellView view, CharacterModel model)
        {
            view.UpdateView(
                ResourceLoader.LoadCharacterSelectPrefab(model.iconPath),
                model.Name,
                model.Description
            );

            view.OnSelectCharacter.AddListener(() =>
            {
                var playerSettingRepository = new PlayerSettingRepository();
                var playerSettingModel = playerSettingRepository.Get(0);
                playerSettingModel.CharacterID = model.ID;
                playerSettingRepository.Set(0, playerSettingModel);

                SceneMoveManager.Instance.BackScene();
            });
        }
    }
}