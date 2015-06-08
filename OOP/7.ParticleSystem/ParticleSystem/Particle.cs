using System.Collections.Generic;

namespace ParticleSystem
{
    public class Particle : IRenderable, IAcceleratable
    {
        public Particle(MatrixCoords position, MatrixCoords speed)
        {
            this.Position = position;
            this.Speed = speed;
        }

        public virtual bool Exists
        {
            get { return true; }
        }

        public MatrixCoords Position { get; private set; }

        public MatrixCoords Speed { get; private set; }

        public void Accelerate(MatrixCoords acceleration)
        {
            this.Speed += acceleration;
        }

        public virtual char[,] GetImage()
        {
            return new char[,] { { '$' } };
        }

        public MatrixCoords GetTopLeft()
        {
            return this.Position;
        }

        public virtual IEnumerable<Particle> Update()
        {
            Move();

            return new List<Particle>();
        }

        protected virtual void Move()
        {
            this.Position += this.Speed;
        }
    }
}