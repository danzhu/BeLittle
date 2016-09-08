using BeLittle.Library;
using ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLittle.Components
{
    public class BlockComponent : IComponent
    {
        public Int3 Position;

        public Int3 Size;
    }
}
