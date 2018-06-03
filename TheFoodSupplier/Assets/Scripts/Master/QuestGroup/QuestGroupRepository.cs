using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public class QuestGroupRepository : IRepository<QuestGroupModel>
    {
        public QuestGroupModel Get(uint id)
        {
            return new QuestGroupModel(
                id,
                "sample" + id.ToString(),
                "sample",
                new uint[3]{0,1,2}
            );
        }

        public IEnumerable<QuestGroupModel> GetALL()
        {
            var list = new List<QuestGroupModel>();
            for (uint i = 0; i < 10; i++)
            {
                list.Add(new QuestGroupModel(
                    i,
                    "sample" + i.ToString(),
                    "sample",
                    new uint[3] { 0, 1, 2 }
                ));
            }
            return list;
        }
    }
}
