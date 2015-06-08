using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    //3.Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle, but randomly stops at different positions for several simulation ticks and, for each of those stops, creates (lays) a new ChickenParticle. You are not allowed to edit any existing class.
    //4.Test the ChickenParticle class through the ParcticleSystemMain class.

    public class ChickenParticle : ChaoticParticle, IRenderable, IAcceleratable
    {
        private int ticks;

        public ChickenParticle(MatrixCoords coords, MatrixCoords startSpeed, Random rnGenerator)
            : base(coords, startSpeed, rnGenerator)
        {
            this.ticks = 0;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'S' } };
        }

        public override IEnumerable<Particle> Update()
        {
            List<Particle> particles = new List<Particle>();
            if (this.ticks == 0)
            {
                IEnumerable<Particle> basePart = base.Update();
                particles.AddRange(basePart);
                this.ticks = base.Rng.Next(4);
                if (ticks != 0)
                {
                    Particle layed = new ChickenParticle(this.Position, new MatrixCoords(0, 0), this.Rng);
                    particles.Add(layed);
                }
            }
            if (ticks != 0)
            {
                ticks--;
            }
            return particles;
        }
    }
}