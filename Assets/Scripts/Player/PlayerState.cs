public abstract class PlayerState
{
    protected Player _player;

    public PlayerState(Player player)
    {
        this._player = player;
    }

    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void Exit()
    {
    }
}
