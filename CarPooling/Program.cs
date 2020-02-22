using CarPooling.Models;
using CarPooling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CarPooling.Models.Enum;

namespace CarPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Write(Constant.MainMenu);
            MainMenuOption option = (MainMenuOption)Helper.ValidInteger();
            switch (option)
            {
                case MainMenuOption.Login:
                    try
                    {
                        User user = AppDataServices.Authentication(UserInput.GetCredential());

                        if (user != null)
                        {
                            Menu menu = new Menu(user.Id);
                            menu.UserMainMenu();
                        }
                        else
                        {
                            Console.WriteLine(Constant.InvalidUserIdOrPassword);
                        }
                    }

                    catch (Exception)
                    {
                        Console.WriteLine(Constant.InvalidUserIdOrPassword);
                    }
                    MainMenu();

                    break;

                case MainMenuOption.Signup:
                    AppDataServices.AddNewUser(UserInput.NewUser());
                    MainMenu();

                    break;

                case MainMenuOption.Exit:
                    Environment.Exit(0);

                    break;
            }
        }
    }

    public class Menu
    {
        public BookingServices Booking { get; set; }

        public string UserId { get; set; }

        public Menu(string userId)
        {
            this.Booking = new BookingServices(userId);

            this.UserId = userId;
        }

        public void UserMainMenu()
        {
            Console.Clear();
            Console.Write(Constant.UserMainMenu);
            UserMainMenuOption option = (UserMainMenuOption)Helper.ValidInteger();
            switch (option)
            {
                case UserMainMenuOption.CreateRideOffer:
                    this.Booking.CreateBooking(UserInput.GetBooking());

                    UserMainMenu();

                    break;

                case UserMainMenuOption.BookRideOffer:
                    List<Booking> bookings = this.Booking.ViewRideOffer(UserInput.GetRiderJourney());
                    if (bookings.Count>0)
                    {
                        foreach (var booking in bookings)
                        {
                            Console.Clear();
                            Console.WriteLine(booking.Id);
                            Display.OfferRide(booking);
                            if (UserInput.RideChoice())
                            {
                                if (!this.Booking.RequestBooking(booking))
                                {
                                    Console.WriteLine(Constant.InvalidBooking);
                                }
                                else
                                {
                                    Console.WriteLine(Constant.RequestSentToOwner);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(Constant.NoOfferForThisRoute);
                    }

                    Console.ReadKey();
                    UserMainMenu();

                    break;

                case UserMainMenuOption.ViewBookingStatus:
                    Console.Write(Constant.StatusMenu);
                    BookinStatusMenuOPtion statusOption = (BookinStatusMenuOPtion)Helper.ValidInteger();
                    switch (statusOption)
                    {
                        case BookinStatusMenuOPtion.RideOffer:
                            bookings = this.Booking.ViewCreatedBookingStatus();
                            if (bookings != null)
                            {
                                foreach (var booking in bookings)
                                {
                                    Console.Clear();
                                    Display.OfferRide(booking);
                                    switch(UserInput.RequestChoice())
                                    {
                                        case BookingStatus.Confirm:
                                            if (!this.Booking.SeatBookingConfirm(booking))
                                            {
                                                Console.WriteLine(Constant.SeatFullMessage);
                                            }
                                            else
                                            {
                                                Console.WriteLine(Constant.SeatBookSuccessfull);
                                            }

                                            Console.ReadKey();

                                            break;

                                        case BookingStatus.Rejected:
                                            this.Booking.SeatBookingReject(booking);

                                            break;

                                        case BookingStatus.Pending:
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(Constant.NoRequestCurrently);
                            }

                            Console.ReadKey();
                            UserMainMenu();

                            break;

                        case BookinStatusMenuOPtion.RideRequest:
                            bookings = this.Booking.ViewSeatBookingRequestStatus();
                            foreach(var booking in bookings)
                            {
                                Display.RideRequest(booking);
                                switch (booking.Status)
                                {
                                    case BookingStatus.Confirm:
                                        Console.WriteLine(Constant.DisplayConfirmBooking);

                                        break;

                                    case BookingStatus.Rejected:
                                        Console.WriteLine(Constant.DisplayRejectBooking);

                                        break;

                                    case BookingStatus.Pending:
                                        Console.WriteLine(Constant.DisplayWaitingBooking);

                                        break;
                                }
                            }

                            Console.ReadKey();
                            UserMainMenu();

                            break;

                        case BookinStatusMenuOPtion.RiderDetail:
                            bookings = this.Booking.ViewOfferStatus();
                            foreach(var booking in bookings)
                            {
                                Console.Clear();
                                Display.OfferRide(booking);
                                Console.WriteLine(Constant.PassangerCount + booking.Traveller.Count);
                            }

                            Console.ReadKey();
                            UserMainMenu();

                            break;

                        case BookinStatusMenuOPtion.SignOut:
                            Program.MainMenu();

                            break;

                        case BookinStatusMenuOPtion.Exit:
                            Environment.Exit(0);

                            break;
                    }
                    UserMainMenu();

                    break;

                case UserMainMenuOption.ModifyOffer:
                    bookings = this.Booking.ViewOfferStatus();
                    foreach (var booking in bookings)
                    {
                        Console.Clear();
                        Display.OfferRide(booking);
                        Console.WriteLine(Constant.PassangerCount + booking.Traveller.Count);
                        Console.WriteLine(Constant.ConfirmOption);
                        if (Helper.ValidInteger() == 1&&booking.Traveller.Count==0)
                        {
                            this.Booking.ModifyBooking(UserInput.GetBooking(),booking);
                        }
                    }

                    break;

                case UserMainMenuOption.DeleteRideOffer:
                    bookings = this.Booking.ViewOfferStatus();
                    foreach (var booking in bookings)
                    {
                        Console.Clear();
                        Display.OfferRide(booking);
                        Console.WriteLine(Constant.PassangerCount + booking.Traveller.Count);
                        Console.WriteLine(Constant.ConfirmOption);
                        if (Helper.ValidInteger() == 1)
                        {
                            this.Booking.DeleteRideOffer(booking);
                        }
                    }

                    Console.ReadKey();
                    UserMainMenu();

                    break;

                case UserMainMenuOption.UpdateDetails:
                    if (AppDataServices.UpdateUserDetail(UserInput.NewUser(), AppDataServices.GetUser(this.UserId)))
                    {
                        Console.WriteLine(Constant.UpdateDetail);
                    }

                    break;

                case UserMainMenuOption.DeleteAccount:
                    if (AppDataServices.DeleteUser(AppDataServices.GetUser(this.UserId)))
                    {
                        Console.WriteLine(Constant.DeleteAccount);
                    }

                    break;

                case UserMainMenuOption.SignOut:
                    Program.MainMenu();

                    break;

                case UserMainMenuOption.Exit:
                    Environment.Exit(0);

                    break;
            }

            UserMainMenu();
        }
    }
}
