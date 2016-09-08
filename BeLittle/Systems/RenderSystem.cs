using BeLittle.Components;
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
    public class RenderSystem : EntitySystem
    {
        private Engine engine;

        private EntityFilter renderables;
        private Matrix[] transforms = new Matrix[256];

        public Vector3 Position { get; set; } = new Vector3(5.0f);

        public Vector3 Target { get; set; } = Vector3.Zero;

        public Vector3 Up { get; set; } = Vector3.Up;

        public float FieldOfView { get; set; } = MathHelper.PiOver4;

        public float NearPlaneDistance { get; set; } = 1.0f;

        public float FarPlaneDistance { get; set; } = 1000.0f;

        public RenderSystem(Engine engine)
        {
            this.engine = engine;
        }

        protected override void Initialize()
        {
            renderables = CreateFilter<ModelComponent>();
        }

        protected override void Render()
        {
            engine.GraphicsDevice.BlendState = BlendState.Opaque;
            engine.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            engine.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            var view = Matrix.CreateLookAt(Position, Target, Up);
            var projection = Matrix.CreatePerspectiveFieldOfView(
                FieldOfView,
                engine.GraphicsDevice.Viewport.AspectRatio,
                NearPlaneDistance,
                FarPlaneDistance
                );

            foreach (var e in renderables)
            {
                var transform = e.Get<TransformComponent>();
                var model = e.Get<ModelComponent>();

                model.Model.CopyAbsoluteBoneTransformsTo(transforms);
                var trans = transform != null ?
                        Matrix.CreateTranslation(transform.Position) *
                        Matrix.CreateFromQuaternion(transform.Rotation) *
                        Matrix.CreateScale(transform.Scale) :
                        Matrix.Identity;

                foreach (var mesh in model.Model.Meshes)
                {
                    var world = transforms[mesh.ParentBone.Index] * trans;

                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();
                        effect.PreferPerPixelLighting = true;
                        effect.World = world;
                        effect.View = view;
                        effect.Projection = projection;
                    }

                    mesh.Draw();
                }
            }
        }
    }
}
