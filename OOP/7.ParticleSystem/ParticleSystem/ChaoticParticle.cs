using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    //1.Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed). You are not allowed to edit any existing class.
    //2.Test the ChaoticParticle through the ParticleSystemMain class

    public class ChaoticParticle : Particle, IRenderable, IAcceleratable
    {
        public ChaoticParticle(MatrixCoords coords, MatrixCoords startSpeed, Random rnGenerator)
            : base(coords, startSpeed)
        {
            this.Rng = rnGenerator;
        }

        protected Random Rng { get; set; }

        public override char[,] GetImage()
        {
            return new char[,] { { 'X' } };
        }

        public override IEnumerable<Particle> Update()
        {
            this.Accelerate(new MatrixCoords(this.Rng.Next(-1, 2), this.Rng.Next(-1, 2)));
            return base.Update();
        }
    }
}