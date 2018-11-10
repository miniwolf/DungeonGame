namespace Components
{
    public interface ZoomSettings
    {
        float ZoomSpeed { get; set; }
        float ZoomMin { get; set; }
        float ZoomMax { get; set; }
        float ZoomValue { get; set; }
    }
}