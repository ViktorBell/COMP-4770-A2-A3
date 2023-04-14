using A2.Pickups;

namespace A2.Actions
{ 

    public class PickupRetrievalAction
    {
        /// <summary>
        /// The Microbe seeking the Pickup.
        /// </summary>
        public readonly Microbe pickUpSeekingMicrobe;

        /// <summary>
        /// The Pickup.
        /// </summary>
        public readonly MicrobeBasePickup pickUp;

        /// <summary>
        /// Create the action data wrapper. Used to pass the PickUpretrieval Action to the PickupActuator which causes the Microbe to retrieve a pickup
        /// </summary>
        /// <param name="pickUpMicrobe">The energy component to pass.</param>
        public PickupRetrievalAction(Microbe pickUpMicrobe, MicrobeBasePickup currentPickUp)
        {
            pickUpSeekingMicrobe = pickUpMicrobe;
            pickUp = currentPickUp;
        }
    }

}
