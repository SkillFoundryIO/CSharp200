using AirportLockerRental.Actions;

namespace AirportLockerRental.Workflows
{
    // we only need one App object, so making it static is appropriate
    public static class App
    {
        public static void Run()
        {
            // instantiate a locker manager to do the work
            LockerManager _lockerManager = new LockerManager();

            while (true)
            {
                int choice = ConsoleIO.GetMenuOption();

                if(choice == 5)
                {
                    return;
                }
                else if(choice == 4)
                {
                    _lockerManager.ListContents();
                }
                else
                {
                    // we need a locker number for these three choices
                    int lockerNumber = ConsoleIO.GetLockerNumber();

                    if(choice == 1)
                    {
                        _lockerManager.ViewLocker(lockerNumber);
                    }
                    else if(choice == 2)
                    {
                        _lockerManager.RentLocker(lockerNumber);
                    }
                    else
                    {
                        _lockerManager.EndRental(lockerNumber);
                    }
                }

                ConsoleIO.AnyKey();
            }
        }
    }
}
