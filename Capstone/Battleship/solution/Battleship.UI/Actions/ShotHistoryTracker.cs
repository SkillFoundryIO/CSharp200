using Battleship.UI.DTOs;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// Tracks the shot history which includes the coordinate and result of a shot. This 
    /// object allows for reporting of the shot history and duplicate checking. Each implementation
    /// of IPlayer should have one only if you want to prevent duplicate shots.
    /// </summary>
    public class ShotHistoryTracker
    {
        // tracks next available element slot
        private int _availableIndex = 0; 

        // 100 possible shots
        public ShotHistoryCoordinate[] Shots { get; set; } = new ShotHistoryCoordinate[100];

        /// <summary>
        /// Checks to see if a coordinate has been targeted before
        /// </summary>
        /// <param name="target">The coordinate the user is attempting to target</param>
        /// <returns>True if the shot is a duplicate</returns>
        public bool IsDuplicateShot(Coordinate target)
        {
            for (int i = 0; i < Shots.Length; i++)
            {
                // we're inserting shots in order, so if we get to the null one we're done
                if (Shots[i] == null)
                {
                    break;
                }

                if (Shots[i].Equals(target))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds an element to the current available index and then increments the index
        /// </summary>
        /// <param name="shot">The shot information</param>
        public void AddShot(ShotHistoryCoordinate shot)
        {
            Shots[_availableIndex] = shot;
            _availableIndex++;
        }
    }
}
