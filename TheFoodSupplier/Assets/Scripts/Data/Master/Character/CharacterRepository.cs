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
                "Haniwa",
                "sampled",
                CharacterType.Boomerang,
                "haniwa"
            );
        }

        public IEnumerable<CharacterModel> GetALL()
        {
            var charaIconName = new string[10]{
                "haniwa",
                "kotodama",
                "umibouzu",
                "haniwa",
                "kotodama",
                "umibouzu",
                "haniwa",
                "kotodama",
                "umibouzu",
                "haniwa",
            };

            var list = new List<CharacterModel>();
            for (int id = 0; id < 10; id++)
            {
                list.Add(new CharacterModel(
                    0,
                    "sample"+ id.ToString(),
                    "sampled"+ id.ToString(),
                    CharacterType.Normal,
                    charaIconName[id]
                ));
            }
            return list;
        }
    }
}
