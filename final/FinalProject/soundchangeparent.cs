abstract class SoundChangeParent
{
    private string name;
    private string rule;
    private bool start;
    private bool fin;
    private bool middle;

    abstract public void ApplyChange();
}