using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IFactory<T> where T : Object
    {
        public List<T> objects { get; }
        public T Create();
        public void Destroy(T objectToDestroy);
    }
}