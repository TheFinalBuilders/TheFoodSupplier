using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public class QuestRepository : IRepository<QuestModel>
    {
        public QuestModel Get(uint id)
        {
            return new QuestModel(
                id,
                "sample" + id.ToString(),
                "sample"
            );
        }

        public IEnumerable<QuestModel> GetALL()
        {
            var list = new List<QuestModel>();
            for (uint i = 0; i < 10; i++)
            {
                list.Add(new QuestModel(
                    i,
                    "sample" + i.ToString(),
                    "sample"
                ));
            }
            return list;
        }
    }
}
