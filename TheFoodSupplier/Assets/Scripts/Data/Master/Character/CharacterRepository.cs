using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public class CharacterRepository : IRepository<CharacterModel>
    {
        public CharacterModel Get(uint id)
        {
            return new CharacterModel(
                id,
                "sample"+id.ToString(),
                "sampled",
                CharacterType.Normal,
                "sample"
            );
        }

        public IEnumerable<CharacterModel> GetALL()
        {
            var list = new List<CharacterModel>();
            for (int id = 0; id < 10; id++)
            {
                list.Add(new CharacterModel(
                    0,
                    "sample"+ id.ToString(),
                    "sampled"+ id.ToString(),
                    CharacterType.Normal,
                    "sample"
                ));
            }
            return list;
        }
    }
}