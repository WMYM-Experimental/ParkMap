using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ParkMap.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ParkMapUser class
public class ParkMapUser : IdentityUser
{
    public string? NickName { get; set; }

    public static implicit operator ParkMapUser(string v)
    {
        throw new NotImplementedException();
    }
}

