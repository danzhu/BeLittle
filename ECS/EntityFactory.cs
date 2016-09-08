using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public abstract class EntityFactory
    {
        Stack<Entity> recycled = new Stack<Entity>();

        internal EntityWorld world;
        public EntityWorld World => world;

        public virtual string Name => GetType().Name.Replace("Factory", "");

        public virtual Entity Create()
        {
            // re-use if possible
            var entity = recycled.Count > 0 ? recycled.Pop() : New();

            Initialize(entity);
            World.AddEntity(entity);
            return entity;
        }

        internal void Recycle(Entity entity)
        {
            World.RemoveEntity(entity);
            recycled.Push(entity);
        }

        protected abstract Entity New();

        protected abstract void Initialize(Entity entity);

        protected internal virtual void Load() { }

        protected internal virtual void Unload() { }

        protected internal virtual string Format(Entity entity) => Name;
    }
}
