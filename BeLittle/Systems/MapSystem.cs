using BeLittle.Components;
using ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Systems
{
    public class MapSystem : EntitySystem
    {
        private Engine engine;
        private TimeSystem time;

        private EntityFilter blocks;

        public MapSystem(Engine engine)
        {
            this.engine = engine;
        }

        protected override void Initialize()
        {
            GetSystem(out time);
            blocks = CreateFilter<BlockComponent>();
        }
    }
}
