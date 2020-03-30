using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19_Tracker.Web.Models
{
	public class AdminViewModel
	{
		public IEnumerable<IdentityUser> Admins { get; set; }
		public IEnumerable<IdentityUser> Managers { get; set; }
		public IEnumerable<IdentityUser> Users { get; set; }
	}
}
