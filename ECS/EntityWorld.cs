using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public class EntityWorld : IEnumerable<EntitySystem>
    {
        private List<EntitySystem> systems = new List<EntitySystem>();
        private Dictionary<string, EntityFactory> factories = new Dictionary<string, EntityFactory>();
        internal List<EntityFilter> filters = new List<EntityFilter>();

        public void Add(EntitySystem system)
        {
            system.world = this;
            systems.Add(system);
        }

        public void Add(EntityFactory factory)
        {
            factory.world = this;
            factories.Add(factory.Name, factory);
        }

        public T GetSystem<T>() where T : EntitySystem
            => systems.First(s => s.GetType() == typeof(T)) as T;

        public T GetFactory<T>() where T : EntityFactory
            => factories.Values.First(f => f.GetType() == typeof(T)) as T;

        public void Initialize()
        {
            foreach (var system in systems)
                system.Initialize();
        }

        public void Load()
        {
            foreach (var factory in factories.Values)
                factory.Load();
            foreach (var system in systems)
                system.Load();
        }

        public void Unload()
        {
            foreach (var system in systems)
                system.Unload();
            foreach (var factory in factories.Values)
                factory.Unload();
        }

        public void Update()
        {
            foreach (var system in systems)
                system.Update();
        }

        public void Render()
        {
            foreach (var system in systems)
                system.Render();
        }

        internal void AddEntity(Entity entity)
        {
            foreach (var filter in filters)
                filter.OnEntityAdded(entity);
        }

        internal void UpdateEntity(Entity entity)
        {
            foreach (var filter in filters)
                filter.OnEntityUpdated(entity);
        }

        internal void RemoveEntity(Entity entity)
        {
            foreach (var filter in filters)
                filter.OnEntityRemoved(entity);
            entity.Factory?.Recycle(entity);
        }

        #region Interface
        public IEnumerator<EntitySystem> GetEnumerator() => systems.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => systems.GetEnumerator();
        #endregion
    }
}
