using ECS;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Components
{
    public class TransformComponent : IComponent
    {
        public Vector3 Position = Vector3.Zero;

        public Quaternion Rotation = Quaternion.Identity;

        public Vector3 Scale = Vector3.One;
    }
}
