using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    /// <summary>
    /// Represents an object in game that contains a collection of components.
    /// </summary>
    public class Entity : ICollection<IComponent>
    {
        readonly Dictionary<Type, IComponent> components = new Dictionary<Type, IComponent>();

        public EntityWorld World { get; }
        public EntityFactory Factory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class in the given <see cref="EntityWorld"/>.
        /// </summary>
        /// <param name="world">The <see cref="EntityWorld"/> that this <see cref="Entity"/> resides in.</param>
        public Entity(EntityWorld world)
        {
            World = world;
        }

        internal Entity(EntityWorld world, EntityFactory factory) : this(world)
        {
            Factory = factory;
        }

        public void Update() => World.AddEntity(this);

        public void Remove() => World.RemoveEntity(this);

        public void Add<T>() where T : IComponent, new() => components.Add(typeof(T), new T());

        /// <summary>
        /// Gets the component with specified type.
        /// </summary>
        /// <typeparam name="T">Type of the component.</typeparam>
        /// <returns>Component of the specified type.</returns>
        public T Get<T>() where T : class, IComponent => components[typeof(T)] as T;

        public bool Has<T>() => components.ContainsKey(typeof(T));

        public override string ToString() => Factory?.Format(this) ?? base.ToString();

        #region Interface
        public int Count => components.Count;

        public bool IsReadOnly => false;

        public void Add(IComponent item) => components.Add(item.GetType(), item);

        public void Clear() => components.Clear();

        public bool Contains(IComponent item) => components.ContainsValue(item);

        public void CopyTo(IComponent[] array, int arrayIndex) => components.Values.CopyTo(array, arrayIndex);

        public bool Remove(IComponent item) => components.Remove(item.GetType());

        public IEnumerator<IComponent> GetEnumerator() => components.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => components.Values.GetEnumerator();
        #endregion
    }
}
