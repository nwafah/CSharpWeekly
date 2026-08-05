using System;
using System.Collections.Generic;
using System.Text;

namespace ResultPattern.Model
{
    public static class UserErrors
    {
        public static readonly Error NameRequired = new(
            "User.NameRequired",
            "Name is Required",
            ErrorType.Validation); 
        public static readonly Error InvalidEmail = new(
            "User.InvalidEmail",
            "Invalid email formate",
            ErrorType.Validation); 
        public static readonly Error EmailToken = new(
            "User.EmailToken",
            "Email is already in use",
            ErrorType.Conflict); 
    }
}
