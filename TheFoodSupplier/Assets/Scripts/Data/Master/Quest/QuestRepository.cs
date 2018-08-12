using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public class QuestRepository : IRepository<QuestModel>
    {
        private readonly string Path = "Param/Quest";

        public QuestModel Get(uint id)
        {
            var meta = Resources.Load<QuestModelParam>(Path + "/" + id.ToString());
            return new QuestModel(
                meta.ID,
                meta.Name,
                meta.bannerFilename,
                meta.Difficulty
            );
        }

        public IEnumerable<QuestModel> GetALL()
        {
            var questDefs = Resources.LoadAll<QuestModelParam>(Path);
            var list = new List<QuestModel>();
            foreach (var def in questDefs)
            {
                list.Add(new QuestModel(
                    def.ID,
                    def.Name,
                    def.bannerFilename,
                    def.Difficulty
                ));
            }
            return list;
        }        
    }
}
