namespace ParticleSystem
{
    public interface IRenderable
    {
        char[,] GetImage();

        MatrixCoords GetTopLeft();
    }
}