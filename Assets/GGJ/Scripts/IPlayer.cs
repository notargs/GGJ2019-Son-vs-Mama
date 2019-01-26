using UniRx;

public interface IPlayer
{
    IReadOnlyReactiveProperty<PlayerState> State { get; }
}