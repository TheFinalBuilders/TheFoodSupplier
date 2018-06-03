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
                "sample",
                "sampled",
                CharacterType.Normal,
                "sample.png"
            );
        }

        public IEnumerable<CharacterModel> GetALL()
        {
            var list = new List<CharacterModel>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new CharacterModel(
                    0,
                    "sample",
                    "sampled",
                    CharacterType.Normal,
                    "sample.png"
                ));
            }
            return list;
        }
    }
}
