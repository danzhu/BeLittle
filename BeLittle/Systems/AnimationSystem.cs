using BeLittle.Components;
using ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Systems
{
    public class AnimationSystem : EntitySystem
    {
        private Engine engine;
        private TimeSystem time;

        private EntityFilter animatables;

        public AnimationSystem(Engine engine)
        {
            this.engine = engine;
        }

        protected override void Initialize()
        {
            GetSystem(out time);
            animatables = CreateFilter<AnimationComponent>();
        }

        protected override void Render()
        {
            foreach (var entity in animatables)
            {
                var transform = entity.Get<TransformComponent>();
                var animation = entity.Get<AnimationComponent>();

                var dt = time.Now - animation.StartTime;
                transform.Position =
                    animation.Acceleration * (dt * dt / 2.0f) +
                    animation.Velocity * dt +
                    animation.Position;
            }
        }
    }
}
