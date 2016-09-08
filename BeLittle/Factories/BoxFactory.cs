using BeLittle.Components;
using ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Factories
{
    public class BoxFactory : EntityFactory
    {
        private Engine engine;
        private Model model;

        public override string Name => "Box";

        public BoxFactory(Engine engine)
        {
            this.engine = engine;
        }

        protected override void Load()
        {
            model = engine.Content.Load<Model>("Models/box");
        }

        protected override Entity New()
        {
            return new Entity(World)
            {
                new TransformComponent { },
                new AnimationComponent { Velocity = new Vector3(1.0f, 2.0f, 0.0f), Acceleration = Vector3.Down },
                new ModelComponent { Model = model },
            };
        }

        protected override void Initialize(Entity entity)
        {
            entity.Get<TransformComponent>().Position = Vector3.Zero;
        }
    }
}
