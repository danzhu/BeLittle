using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public class EntityFilter : IReadOnlyCollection<Entity>
    {
        Predicate<Entity> predicate;
        HashSet<Entity> entities = new HashSet<Entity>();

        public EntityFilter(EntityWorld world, Predicate<Entity> pred)
        {
            world.filters.Add(this);
            predicate = pred;
        }

        internal bool OnEntityAdded(Entity entity)
            => predicate(entity) ? entities.Add(entity) : false;

        internal bool OnEntityUpdated(Entity entity)
            => predicate(entity) ? entities.Add(entity) : entities.Remove(entity);

        internal bool OnEntityRemoved(Entity entity)
            => entities.Remove(entity);

        #region Interface
        public int Count => entities.Count;

        public IEnumerator<Entity> GetEnumerator() => entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => entities.GetEnumerator();
        #endregion
    }
}
