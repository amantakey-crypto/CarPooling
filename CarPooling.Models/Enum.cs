using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Enum
    {
        public enum MainMenuOption
        {
            Login = 1,
            Signup,
            Exit
        };

        public enum UserMainMenuOption
        {
            CreateRideOffer=1,
            BookRideOffer,
            ViewBookingStatus,
            ModifyOffer,
            DeleteRideOffer,
            UpdateDetails,
            DeleteAccount,
            SignOut,
            Exit
        };

        public enum BookinStatusMenuOPtion
        {
            RideOffer=1,
            RideRequest,
            RiderDetail,
            SignOut,
            Exit
        };

        public enum UpdateUserDetailMenuOPtion
        {
            Name=1,
            MobileNumber,
            EmailAddress,
            Address,
            DrivingLicence,
            IdProofNumber,
            Signout,
            Exit
        };

        public enum RideOption
        {
            Yes=1,
            No
        };

        public enum BookingStatus
        {
            Confirm=1,
            Rejected,
            Pending
        };

        public enum UserType
        {
            Owner,
            Traveller
        }
    }
}
