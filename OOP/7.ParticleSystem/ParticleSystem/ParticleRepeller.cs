namespace ParticleSystem
{
    internal class ParticleRepeller : Particle
    {
        //5.Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles away from it (i.e. accelerates them in a direction, opposite of the direction in which the repeller is). The repeller has an effect only on particles within a certain radius (see Euclidean distance)
        //This is implimented in the AdvancedParticleOperator class
        //6.Test the ParticleRepeller class through the ParticleSystemMain class

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int attractionPower, float repellRadius) :
            base(position, speed)
        {
            this.Power = attractionPower;
            this.Radius = repellRadius;
        }

        public int Power { get; private set; }

        public float Radius { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { 'O' } };
        }
    }
}