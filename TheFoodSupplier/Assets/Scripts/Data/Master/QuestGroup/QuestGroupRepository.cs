using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public class QuestGroupRepository : IRepository<QuestGroupModel>
    {
        public static readonly int GroupCount = 10;
        public static readonly int QuestCount = GroupCount*3;

        static List<QuestGroupModel> questGroupModels = null;

        public QuestGroupRepository()
        {
            if (questGroupModels != null)
            {
                return;
            }

            questGroupModels = new List<QuestGroupModel>();
            for (uint id = 0; id < GroupCount; id++)
            {
                questGroupModels.Add(new QuestGroupModel(
                    id,
                    "sample" + id.ToString(),
                    "sample",
                    new uint[3] { 
                        id * 3 + 0, 
                        id * 3 + 1, 
                        id * 3 + 2 }
                ));
            }
        }

        public QuestGroupModel Get(uint id)
        {
            return questGroupModels[(int)id];
        }

        public IEnumerable<QuestGroupModel> GetALL()
        {
            return questGroupModels;
        }
    }
}
