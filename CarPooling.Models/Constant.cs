using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Constant
    {
        public static readonly string MainMenu = "1. Login\n2. Signup\n3. Exit";

        public static readonly string UserMainMenu = "1. Create Ride Offer\n2. Book Ride Offer\n3. View Booking Status\n4. Modify Offer\n5. Delete Ride Offer\n6. Update Details\n7. Delete Account\n8. SignOut\n9. Exit";

        public static readonly string StatusMenu = "1. Ride Offer\n2. Ride Request\n3. View Ride Detail\n4. SignOut\n5. Exit";

        public static readonly string UpdateUserDetailMenu = "1. Name\n2. MobileNumber\n3. EmailAddress\n4. Address\n5. DrivingLicence\n6. IdProofNumber\n7. Signout\n8. Exit";

        public static readonly string RequestChoice = "Press 1. Confirm\n      2. Rejected\n      3. Waiting";

        public static readonly string RideChoice = "Press 1. Yes\n      2. No";

        public static readonly string ViewAnotherOffer = "Press 1. Yes\n      2. No";

        public static readonly string ConfirmOption = "Press 1 for confirm this ";

        public static readonly string UpdateDetail = "Your Detail has been updated";

        public static readonly string DeleteAccount = "You Account has been deleted";

        public static readonly string VacantSeatNotCorrect = "Vacant seat is less or equal to max capacity";

        public static readonly string InvalidUserIdOrPassword = "Press correct user Id or password";

        public static readonly string InvalidBooking = "You can't book this booking right now";

        public static readonly string RequestSentToOwner = "Request has been sent to Owner if he/she approve then enjoy your Ride";

        public static readonly string NoOfferForThisRoute = "No any offer available for this route";

        public static readonly string SeatFullMessage = "Seat full on this car better for next time";

        public static readonly string SeatBookSuccessfull = "Seat has been successfully booked thanks for confirming";

        public static readonly string NoRequestCurrently = "No request currently present";

        public static readonly string InvalidValue = "Please Enter Correct Value";

        public static readonly string InValidDate = "Please Enter Correct Date";

        public static readonly string UserId = "User Id : ";

        public static readonly string Password = "Password : ";

        public static readonly string Name = "Name : ";

        public static readonly string EmailAddress = "Email Address : ";

        public static readonly string Address = "Address : ";

        public static readonly string MobileNumber = "Mobile Number : ";

        public static readonly string DrivingLicenceNumber = "Driving Licence Number : ";

        public static readonly string IdProofNumber = "Id Proof Number : ";

        public static readonly string CarDetail = "Car Detail  ";

        public static readonly string CarNumber = "Number : ";

        public static readonly string CarModel = "Model Number :";

        public static readonly string CarCapacity = "Max Capacity : ";

        public static readonly string VacantSeat = "Vacant Seat : ";

        public static readonly string JourneyDetail = "Journey Detail : ";

        public static readonly string Pincode = "Pincode : ";

        public static readonly string Begining = "Starting Location : ";

        public static readonly string Ending = "End Location : ";

        public static readonly string Date = "Date : ";

        public static readonly string LandMark = "LandMark : ";

        public static readonly string PassangerCount = "No of passanger : ";

        public static readonly string DisplayConfirmBooking = "Your Booking has been Confirmed Please contact once with Owner for more Detail";

        public static readonly string DisplayRejectBooking = "Requestd Booking has been Rejected by the Owner";

        public static readonly string DisplayWaitingBooking = "Waiting for Owner Response";
    }
}
