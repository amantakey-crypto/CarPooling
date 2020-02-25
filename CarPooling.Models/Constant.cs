using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Constant
    {
        public static readonly string MainMenuOption = "1. Login\n2. Signup\n3. Exit";

        public static readonly string UserMainMenuOption = "1. Create ride \n2. Book a ride \n3. View requested status\n4. Modify ride detail\n5. Delete ride\n6. Update account detail\n7. Delete account\n8. SignOut\n9. Exit";

        public static readonly string CheckRequestStatusOption = "1. Ride request\n2. booking request\n3. View booking Detail\n4. SignOut\n5. Exit";

        public static readonly string UpdateUserDetailOption = "1. Name\n2. Mobile number\n3. Email address\n4. Address\n5. Driving licence\n6. Id proof number\n7. Signout\n8. Exit";

        public static readonly string RideRequestChoice = "Press 1. Confirm\n      2. Rejected\n      3. Waiting";

        public static readonly string BookingChoice = "Press 1. Yes\n      2. No";

        public static readonly string ViewAnotherOffer = "Press 1. Yes\n      2. No";

        public static readonly string ConfirmOption = "Press 1 for confirm this offer";

        public static readonly string Another = "Press 1. Yes\n      2. No";

        public static readonly string UpdateDetailResponse = "Your detail has been updated";

        public static readonly string AccountDeleteResponse = "You account has been deleted";

        public static readonly string Confirmation = "Press 1. Yes\n      2. No";

        public static readonly string InvalidVacantSeat = "Vacant seat is less or equal to max capacity";

        public static readonly string InvalidUserIdPassword = "Press correct user Id or password";

        public static readonly string InvalidBookingRequest = "You can not book this ride offer";

        public static readonly string RequestSentToOwner = "Request has been sent to owner if he/she approve then enjoy your Ride";

        public static readonly string NoRideOffer = "No any ride available for this route";

        public static readonly string SeatFull = "Seat full for these ride offer";

        public static readonly string SeatBookResponse = "Seat has been successfully booked thanks for confirming";

        public static readonly string NoRequestCurrently = "No request currently available for this route";

        public static readonly string InvalidValue = "Please enter correct value";

        public static readonly string InValidDate = "Please enter correct date";

        public static readonly string City = "City : ";

        public static readonly string UserId = "User id : ";

        public static readonly string Password = "Password : ";

        public static readonly string Name = "Name : ";

        public static readonly string Email = "Email : ";

        public static readonly string Address = "Address : ";

        public static readonly string MobileNumber = "Mobile number : ";

        public static readonly string DrivingLicenceNumber = "Driving licence number : ";

        public static readonly string IdProofNumber = "Id proof number : ";

        public static readonly string CarDetail = "Car detail  ";

        public static readonly string CarNumber = "Number : ";

        public static readonly string CarModel = "Model number :";

        public static readonly string CarCapacity = "Max capacity : ";

        public static readonly string VacantSeat = "Vacant seat : ";

        public static readonly string JourneyDetail = "Journey detail : ";

        public static readonly string Pincode = "Pincode : ";

        public static readonly string Source = "Source location : ";

        public static readonly string Destination = "Destination location : ";

        public static readonly string Date = "Date : ";

        public static readonly string LandMark = "LandMark : ";

        public static readonly string PassangerCount = "No of passanger : ";

        public static readonly string DisplayConfirmBooking = "Your booking has been confirmed please contact once with owner for more detail";

        public static readonly string DisplayRejectBooking = "Requestd booking has been rejected by the owner";

        public static readonly string DisplayWaitingBooking = "Waiting for owner response";

        public static readonly string NoOfViaPlaces = "No of via place : ";

        public static readonly string UserNameAvailable = "Sorry this username will be taken by someone please choose another or username will be null";

        public static readonly string ViaCities = "Via City";
    }
}
