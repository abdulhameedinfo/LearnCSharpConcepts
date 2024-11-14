public class Robot
{
    private ISpeaker _speaker;
    private IMover _mover;
    public Robot(ISpeaker speaker, IMover mover)
    {
        _speaker = speaker;
        _mover = mover;
    }

    public string CanSpeak() => _speaker.CanSpeak();
    public string CanMove() => _mover.CanMove();
}