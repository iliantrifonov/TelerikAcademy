using System.Collections.Generic;

namespace ParticleSystem
{
    public interface IParticle
    {
        bool Exists
        {
            get;
        }

        MatrixCoords Position
        {
            get;
        }

        IEnumerable<IParticle> Update();
    }
}