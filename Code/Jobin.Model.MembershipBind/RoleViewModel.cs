using System.Collections.Generic;
using System.Web.Security;

//namespace Jobin.Web.Admin.Controllers.Models.UserAdministration
namespace Jobin.Model.MembershipBind
{
	public class RoleViewModel
	{
		public string Role { get; set; }
		public IEnumerable<MembershipUser> Users { get; set; }
	}
}