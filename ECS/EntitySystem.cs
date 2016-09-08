using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public abstract class EntitySystem
    {
        internal EntityWorld world;
        public EntityWorld World => world;

        protected void GetSystem<T>(out T system) where T : EntitySystem
            => system = world.GetSystem<T>();

        protected void GetFactory<T>(out T factory) where T : EntityFactory
            => factory = world.GetFactory<T>();

        protected EntityFilter CreateFilter<T>() where T : IComponent
            => new EntityFilter(world, e => e.Has<T>());

        protected internal virtual void Initialize() { }

        protected internal virtual void Load() { }

        protected internal virtual void Unload() { }

        protected internal virtual void Update() { }

        protected internal virtual void Render() { }
    }
}
