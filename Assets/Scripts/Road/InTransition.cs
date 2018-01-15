public class InTransition : Transition
{
    public Transition Next;

    public void Update()
    {
        if (Endpoint.CanPull())
        {
            if (Type == TransitionType.EndPoint)
            {
                Endpoint.Pull().Despawn();
            }
            else if (Next != null && Next.HasPlace)
            {
                Next.Push(Endpoint.Pull());
            }
        }
    }
}