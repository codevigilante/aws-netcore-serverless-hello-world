namespace AWSNetCore
{
    public enum ControllerVisitOptions { Default }

    public class SillyOptions
    {
        public ControllerVisitOptions OnControllerVisit { get; set; }
        public bool RootControllerPriority { get; set; }

        public SillyOptions()
        {
            OnControllerVisit = ControllerVisitOptions.Default;
            RootControllerPriority = false;
        }
    }
}