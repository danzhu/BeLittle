using ECS;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Systems
{
    public class TimeSystem : EntitySystem
    {
        private const float PERIOD = 1.0f;

        private Engine engine;

        private int frames = 0;
        private int fps = -1;
        public int FPS => fps;

        private int cycle = 0;
        public int Cycle => cycle;

        private float progress = 0.0f;
        public float Progress => progress;

        private bool leaping = false;
        public bool Leaping => leaping;

        public float Now => cycle + progress;

        public float TimeScale { get; set; } = 1.0f;

        public TimeSystem(Engine engine)
        {
            this.engine = engine;
        }

        protected override void Update()
        {
            // increment progress based on elapsed time
            progress += (float)engine.Time.ElapsedGameTime.TotalSeconds * TimeScale;

            leaping = progress > PERIOD;
            if (leaping)
            {
                // update progress and cycles
                progress -= PERIOD;
                cycle++;

                // update FPS
                fps = frames;
                frames = 0;
            }
        }

        protected override void Render()
        {
            frames++;
        }
    }
}
