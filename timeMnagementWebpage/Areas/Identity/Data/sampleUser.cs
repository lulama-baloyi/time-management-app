using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace timeMnagementWebpage.Areas.Identity.Data;

// Add profile data for application users by adding properties to the sampleUser class
public class sampleUser : IdentityUser
{
    public String Name {  get; set; }
    public String Surname {  get; set; }
}

