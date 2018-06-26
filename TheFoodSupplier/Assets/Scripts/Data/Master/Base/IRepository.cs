using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public interface IRepository<Model> where Model : IModel 
    {
        Model Get(uint ID);
        IEnumerable<Model> GetALL();
    }
}
