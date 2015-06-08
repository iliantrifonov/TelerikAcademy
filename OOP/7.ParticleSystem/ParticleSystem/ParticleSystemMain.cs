using System;

namespace ParticleSystem
{
    internal class ParticleSystemMain
    {
        private const int Cols = 60;
        private const int Rows = 30;
        private static readonly Random RandomGenerator = new Random();

        private static void GenerateInitialData(Engine engine)
        {
            engine.AddParticle(
                new Particle(
                    new MatrixCoords(19, 20),
                    new MatrixCoords(0, 0))
                );

            engine.AddParticle(
                new DyingParticle(
                    new MatrixCoords(20, 5),
                    new MatrixCoords(-1, 1),
                    12)
                );
            //test chaotic particle
            engine.AddParticle(
                new ChaoticParticle(
                    new MatrixCoords(19, 25),
                    new MatrixCoords(-1, 1),
                    RandomGenerator)
                );
            //test chickenparticle
            engine.AddParticle(
                new ChickenParticle(
                    new MatrixCoords(19, 25),
                    new MatrixCoords(-1, 1),
                    RandomGenerator)
                );
            var repellerPosition = new MatrixCoords(15, 30);
            var repeller = new ParticleRepeller(
                repellerPosition,
                new MatrixCoords(0, 0),
                1, 12);
            engine.AddParticle(repeller);
            //var emitterPosition = new MatrixCoords(29, 0);
            //var emitterSpeed = new MatrixCoords(0, 0);
            //var emitter = new ParticleEmitter(emitterPosition, emitterSpeed,
            //    RandomGenerator,
            //    5,
            //    2,
            //    GenerateRandomParticle
            //    );

            ////engine.AddParticle(emitter);

            //var attractorPosition = new MatrixCoords(10, 3);
            //var attractor = new ParticleAttractor(
            //    attractorPosition,
            //    new MatrixCoords(0, 0),
            //    1);

            //var attractorPosition2 = new MatrixCoords(10, 13);
            //var attractor2 = new ParticleAttractor(
            //    attractorPosition2,
            //    new MatrixCoords(0, 0),
            //    3);

            //engine.AddParticle(attractor);
            //engine.AddParticle(attractor2);
        }

        private static Particle GenerateRandomParticle(ParticleEmitter emitterParameter)
        {
            MatrixCoords particlePos = emitterParameter.Position;

            int particleRowSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
            int particleColSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);

            MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

            Particle generated = null;

            int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);
            switch (particleTypeIndex)
            {
                case 0: generated = new Particle(particlePos, particleSpeed); break;
                case 1:
                    uint lifespan = (uint)emitterParameter.RandomGenerator.Next(8);
                    generated = new DyingParticle(particlePos, particleSpeed, lifespan);
                    break;

                default:
                    throw new Exception("No such particle for this particleTypeIndex");
                    break;
            }
            return generated;
        }

        private static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer(Rows, Cols);

            var particleOperator = new AdvancedParticleOperator();

            var engine =
                new Engine(renderer, particleOperator, null, 300);

            GenerateInitialData(engine);

            engine.Run();
        }
    }
}