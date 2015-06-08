using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        private List<ParticleAttractor> attractors = new List<ParticleAttractor>();
        private List<Particle> particles = new List<Particle>();
        private List<ParticleRepeller> repellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var attractorCandidate = p as ParticleAttractor;
            var repellerCandidate = p as ParticleRepeller;
            if (attractorCandidate == null && repellerCandidate == null)
            {
                this.particles.Add(p);
            }
            else
            {
                if (repellerCandidate == null)
                {
                    this.attractors.Add(attractorCandidate);
                }
                else
                {
                    this.repellers.Add(repellerCandidate);
                }
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.attractors)
            {
                foreach (var particle in this.particles)
                {
                    var currAcceleration = GetAccelerationFromParticleToAttractor(attractor, particle);

                    particle.Accelerate(currAcceleration);
                }
            }

            foreach (var repeller in this.repellers)
            {
                foreach (var particle in this.particles)
                {
                    var currAcceleration = GetAccelerationFromParticleToRepeller(repeller, particle);

                    particle.Accelerate(currAcceleration);
                }
            }
            this.attractors.Clear();
            this.particles.Clear();
            this.repellers.Clear();
            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.Power)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * attractor.Power;
            }
            return pToAttrCoord;
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > repeller.Power)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * repeller.Power;
            }
            return -pToAttrCoord;
        }

        private static MatrixCoords GetAccelerationFromParticleToAttractor(ParticleAttractor attractor, Particle particle)
        {
            var currParticleToAttractorVector = attractor.Position - particle.Position;

            int pToAttrRow = currParticleToAttractorVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(attractor, pToAttrRow);

            int pToAttrCol = currParticleToAttractorVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(attractor, pToAttrCol);

            var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);
            return currAcceleration;
        }

        private static MatrixCoords GetAccelerationFromParticleToRepeller(ParticleRepeller repeller, Particle particle)
        {
            if (IsTooFarFromTheRepeller(repeller, particle))
            {
                return new MatrixCoords(0, 0);
            }
            var currParticleToAttractorVector = repeller.Position - particle.Position;

            int pToAttrRow = currParticleToAttractorVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(repeller, pToAttrRow);

            int pToAttrCol = currParticleToAttractorVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(repeller, pToAttrCol);

            var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);
            return currAcceleration;
        }

        private static bool IsTooFarFromTheRepeller(ParticleRepeller repeller, Particle particle)
        {
            if ((Math.Pow(repeller.Position.Col - particle.Position.Col, 2) + Math.Pow(repeller.Position.Row - particle.Position.Row, 2)) < repeller.Radius * repeller.Radius)
            {
                return false;
            }
            return true;
        }
    }
}