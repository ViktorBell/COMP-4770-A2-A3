namespace A2.Actions
{
    /// <summary>
    /// Action to pass to actuator to set target Microbe for hunt.
    /// </summary>
    public class HuntPreyAction
    {
        /// <summary>
        /// The Hunter Microbe.
        /// </summary>
        public readonly Microbe HunterMicrobe;

        /// <summary>
        /// The Hunter Microbe.
        /// </summary>
        public readonly Microbe TargetMicrobe;

        /// <summary>
        /// Create the action data wrapper. Used to pass the HuntPrey Action to the HuntingActuator which causes the Microbe to pursue and eat its prey
        /// </summary>
        /// <param name="hunterMicrobe">The energy component to pass.</param>
        public HuntPreyAction(Microbe hunterMicrobe, Microbe targetMicrobe)
        {
            HunterMicrobe = hunterMicrobe;
            TargetMicrobe = targetMicrobe;
        }
    }
}
