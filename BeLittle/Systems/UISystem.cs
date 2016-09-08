using ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Systems
{
    public class UISystem : EntitySystem
    {
        private Engine engine;
        private TimeSystem time;

        private SpriteFont font;

        public UISystem(Engine engine)
        {
            this.engine = engine;
        }

        protected override void Initialize()
        {
            GetSystem(out time);
        }

        protected override void Load()
        {
            font = engine.Content.Load<SpriteFont>("Fonts/monospace");
        }

        protected override void Render()
        {
            engine.Sprite.Begin();
            if (time.FPS >= 0)
                engine.Sprite.DrawString(font, $"FPS: {time.FPS}", new Vector2(10.0f), Color.White);
            engine.Sprite.End();
        }
    }
}
