namespace A2.Actions
{
    /// <summary>
    /// Action to pass to actuator to set potential Mate Microbe for reproduction.
    /// </summary>
    public class MateAction
    {
        /// <summary>
        /// The Hunter Microbe.
        /// </summary>
        public readonly Microbe InterestedMicrobe;

        /// <summary>
        /// The Hunter Microbe.
        /// </summary>
        public readonly Microbe PotentialMateMicrobe;

        /// <summary>
        /// Create the action data wrapper. Used to pass the Mate Action to the matingActuator which causes the Microbe to pursue a lover
        /// </summary>
        /// <param name="interestedMicrobe">The energy component to pass.</param>
        public MateAction(Microbe interestedMicrobe, Microbe potentialmateMicrobe)
        {
            InterestedMicrobe = interestedMicrobe;
            PotentialMateMicrobe = potentialmateMicrobe;
        }
    }
}