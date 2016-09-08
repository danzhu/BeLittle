using ECS;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Components
{
    public class AnimationComponent : IComponent
    {
        public int StartTime;
        public Vector3 Velocity;
        public Vector3 Acceleration;
        public Vector3 Position;
    }
}
