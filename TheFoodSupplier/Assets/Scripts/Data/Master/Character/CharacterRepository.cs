using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public class CharacterRepository : IRepository<CharacterModel>
    {
        private readonly string Path = "Param/Character";

        public CharacterModel Get(uint id)
        {
            CharacterModelParam meta = Resources.Load<CharacterModelParam>(Path+"/"+id.ToString());
            return new CharacterModel(
                meta.id,
                meta.name,
                meta.description,
                meta.type ,
                meta.iconPath,
                meta.openClearQuestID
            );
        }

        public IEnumerable<CharacterModel> GetALL()
        {
            var characterDefs = Resources.LoadAll<CharacterModelParam>(Path);
            var list = new List<CharacterModel>();
            foreach (var def in characterDefs)
            {
                list.Add(new CharacterModel(
                    def.id,
                    def.name,
                    def.description,
                    def.type,
                    def.iconPath,
                    def.openClearQuestID
                ));
            }
            return list;
        }
    }
}
