
namespace GameLogic
{
    public interface IChipFactoryController
    {
        ChipFactory[] ballFactories { get; }
        ChipFactory[] barrierFactories { get; }
        ChipFactory much4BallFactory { get; }
        ChipFactory much5BallFactory { get; }
        ChipFactory much6BallFactory { get; }
        void AddChipsToGame(int numOfChips);
    }
}