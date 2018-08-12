using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public class QuestGroupRepository : IRepository<QuestGroupModel>
    {
        private readonly string Path = "Param/QuestGroup";

        public QuestGroupModel Get(uint id)
        {
            var meta = Resources.Load<QuestGroupModelParam>(Path + "/" + id.ToString());
            return new QuestGroupModel(
                meta.ID,
                meta.Name,
                meta.bannerFilename,
                meta.Description,
                meta.questIDs
            );
        }

        public IEnumerable<QuestGroupModel> GetALL()
        {
            var questDefs = Resources.LoadAll<QuestGroupModelParam>(Path);
            var list = new List<QuestGroupModel>();
            foreach (var def in questDefs)
            {
                list.Add(new QuestGroupModel(
                    def.ID,
                    def.Name,
                    def.bannerFilename,
                    def.Description,
                    def.questIDs
                ));
            }
            return list;
        }
    }
}
