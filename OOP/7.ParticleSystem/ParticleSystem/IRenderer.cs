namespace ParticleSystem
{
    public interface IRenderer
    {
        void ClearQueue();

        void EnqueueForRendering(IRenderable obj);

        void RenderAll();
    }
}