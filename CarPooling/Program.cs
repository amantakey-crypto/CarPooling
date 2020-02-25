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
            Console.Write(Constant.MainMenuOption);
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
                            Console.WriteLine(Constant.InvalidUserIdPassword);
                        }
                    }

                    catch (Exception)
                    {
                        Console.WriteLine(Constant.InvalidUserIdPassword);
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
        public BookingServices BookingServices { get; set; }

        public string UserId { get; set; }

        public Menu(string userId)
        {
            this.BookingServices = new BookingServices(userId);
            this.UserId = userId;
        }

        public void UserMainMenu()
        {
            Console.Clear();
            Console.Write(Constant.UserMainMenuOption);
            UserMainMenuOption option = (UserMainMenuOption)Helper.ValidInteger();
            switch (option)
            {
                case UserMainMenuOption.CreateRide:
                    this.BookingServices.CreateBooking(UserInput.GetRideDetail());
                    UserMainMenu();

                    break;

                case UserMainMenuOption.BookARide:
                    Booking booking = UserInput.GetBooking();
                    List<Ride> rides = this.BookingServices.ViewRideOffer(booking);
                    if (rides.Count > 0)
                    {
                        foreach (var ride in rides)
                        {
                            Console.Clear();
                            Console.WriteLine(booking.Id);
                            Display.OfferRide(ride);
                            if (UserInput.Confirmation()==ConfirmationResponse.Yes)
                            {
                                if (!this.BookingServices.RequestBooking(booking, ride.Id))
                                {
                                    Console.WriteLine(Constant.InvalidBookingRequest);
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
                        Console.WriteLine(Constant.NoRequestCurrently);
                    }

                    Console.ReadKey();
                    UserMainMenu();

                    break;

                case UserMainMenuOption.ViewStatus:
                    Console.Write(Constant.CheckRequestStatusOption);
                    BookingStatusMenuOption statusOption = (BookingStatusMenuOption)Helper.ValidInteger();
                    switch (statusOption)
                    {
                        case BookingStatusMenuOption.RideOffer:
                            rides = this.BookingServices.ViewCreatedRideStatus();
                            foreach (var ride in rides)
                            {
                                foreach (var bookingId in ride.RequestBookerId)
                                {
                                    Display.BookingRequest(AppDataServices.GetBooking(bookingId));
                                    switch (UserInput.BookingChoice())
                                    {
                                        case BookingStatus.Confirm:
                                            if (!this.BookingServices.SeatBookingConfirm(bookingId))
                                            {
                                                Console.WriteLine(Constant.SeatFull);
                                            }
                                            else
                                            {
                                                Console.WriteLine(Constant.SeatBookResponse);
                                            }
                                            break;

                                        case BookingStatus.Rejected:
                                            this.BookingServices.SeatBookingReject(bookingId);

                                            break;
                                    }
                                    if (UserInput.Confirmation() == ConfirmationResponse.Yes)
                                    {
                                        break;
                                    }

                                }

                                if (rides.Count < 1)
                                {
                                    Console.WriteLine(Constant.NoRequestCurrently);
                                }

                                Console.ReadKey();
                                UserMainMenu();
                            }
                            break;

                        case BookingStatusMenuOption.RideRequest:
                            List<Booking> bookings = this.BookingServices.ViewSeatBookingRequestStatus();
                            foreach (var book in bookings)
                            {
                                Display.BookingRequest(book);
                                switch (book.Status)
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
                                if (UserInput.Confirmation() == ConfirmationResponse.Yes)
                                {
                                    break;
                                }
                            }
                            Console.ReadKey();
                            UserMainMenu();

                            break;

                        case BookingStatusMenuOption.RiderDetail:
                            rides = this.BookingServices.ViewOfferStatus();
                            foreach (var ride in rides)
                            {
                                Console.Clear();
                                Display.OfferRide(ride);
                                int travellerCount = ride.AcceptedBookerId.Count;
                                Console.WriteLine(Constant.PassangerCount + travellerCount);
                            }
                            Console.ReadKey();
                            UserMainMenu();

                            break;

                        case BookingStatusMenuOption.SignOut:
                            Program.MainMenu();

                            break;

                        case BookingStatusMenuOption.Exit:
                            Environment.Exit(0);

                            break;
                    }
                    UserMainMenu();

                    break;

                case UserMainMenuOption.ModifyRide:
                    rides = this.BookingServices.ViewOfferStatus();
                    foreach (var ride in rides)
                    {
                        Console.Clear();
                        Display.OfferRide(ride);
                        int confirmBookingCount = ride.AcceptedBookerId.Count;
                        Console.WriteLine(Constant.PassangerCount + confirmBookingCount);
                        Console.WriteLine(Constant.ConfirmOption);
                        if (UserInput.Confirmation()==ConfirmationResponse.Yes && confirmBookingCount == 0)
                        {
                            this.BookingServices.ModifyRide(UserInput.GetRideDetail(), ride);
                        }
                    }

                    break;

                case UserMainMenuOption.DeleteRide:
                    rides = this.BookingServices.ViewOfferStatus();
                    foreach (var ride in rides)
                    {
                        Console.Clear();
                        Display.OfferRide(ride);
                        int ConfirmBookingCount = ride.AcceptedBookerId.Count;
                        Console.WriteLine(Constant.PassangerCount + ConfirmBookingCount);
                        Console.WriteLine(Constant.ConfirmOption);
                        if (UserInput.Confirmation()==ConfirmationResponse.Yes)
                        {
                            this.BookingServices.DeleteRideOffer(ride);
                        }
                    }

                    Console.ReadKey();
                    UserMainMenu();

                    break;

                case UserMainMenuOption.UpdateAccountDetail:
                    if (AppDataServices.UpdateUserDetail(UserInput.NewUser(), AppDataServices.GetUser(this.UserId)))
                    {
                        Console.WriteLine(Constant.UpdateDetailResponse);
                    }

                    break;

                case UserMainMenuOption.DeleteUserAccount:
                    Console.WriteLine(Constant.Confirmation);
                    if (UserInput.Confirmation() == ConfirmationResponse.Yes)
                    {
                        if (AppDataServices.DeleteUser(AppDataServices.GetUser(this.UserId)))
                        {
                            Console.WriteLine(Constant.AccountDeleteResponse);
                        }
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
