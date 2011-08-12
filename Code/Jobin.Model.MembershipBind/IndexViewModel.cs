using System.Collections.Generic;
using System.Web.Security;
using PagedList;

//namespace Jobin.Web.Admin.Controllers.Models.UserAdministration
namespace Jobin.Model.MembershipBind
{
	public class IndexViewModel
	{
		public IPagedList<MembershipUser> Users { get; set; }
		public IEnumerable<string> Roles { get; set; }
	}
}