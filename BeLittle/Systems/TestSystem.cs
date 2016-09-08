using BeLittle.Components;
using BeLittle.Factories;
using ECS;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Systems
{
    public class TestSystem : EntitySystem
    {
        private Engine engine;
        private TimeSystem time;

        private BoxFactory box;

        public TestSystem(Engine engine)
        {
            this.engine = engine;
        }

        protected override void Initialize()
        {
            GetSystem(out time);
            GetFactory(out box);
        }

        protected override void Update()
        {
            if (!time.Leaping)
                return;
            var entity = box.Create();
            entity.Get<AnimationComponent>().StartTime = time.Cycle;
        }
    }
}
