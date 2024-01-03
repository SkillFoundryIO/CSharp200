using AirportLockerRental.DTOs;

namespace AirportLockerRental.Actions
{
    public class LockerManager
    {
        private LockerContents[] _lockers = new LockerContents[100];

        public void ListContents()
        {
            for (int i = 0; i < _lockers.Length; i++)
            {
                if (_lockers[i] != null)
                {
                    ConsoleIO.DisplayLockerContents(_lockers[i], i + 1);
                }
            }
        }

        public void ViewLocker(int number)
        {
            if (_lockers[number-1] == null)
            {
                Console.WriteLine($"Locker {number} is EMPTY");
            }
            else
            {
                ConsoleIO.DisplayLockerContents(_lockers[number - 1], number);
            }
        }

        public void RentLocker(int number)
        {
            // is the locker already rented?
            if (_lockers[number-1] != null)
            {
                Console.WriteLine($"Sorry, but locker {number} has already been rented!");
            }
            else
            {
                LockerContents contents = new LockerContents();

                contents.RenterName = ConsoleIO.GetRequiredString("Enter your name: ");
                contents.Description = ConsoleIO.GetRequiredString("Enter the item you want to store in the locker: ");

                _lockers[number-1] = contents;
            }
        }

        public void EndRental(int number)
        {
            if (_lockers[number-1] == null)
            {
                Console.WriteLine($"Locker {number} is not currently rented.");
            }
            else
            {
                Console.WriteLine($"Locker {number} rental has ended, please take your {_lockers[number-1].Description}.");
                _lockers[number-1] = null;
            }
        }
    }
}
