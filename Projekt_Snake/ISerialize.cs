using System.Collections.Generic;

namespace Projekt_Snake
{
    public interface ISerialize<T>
    {
        public void Serialize(List<T> list);
        public List<T> Deserialize();
    }
}
