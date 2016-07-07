using System;
namespace Definition.Model
{
	public class Users
	{
		public string user { get; set; }
		public string access_token { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public Account account { get; set; }
	}
	public class Account
	{
		public int id { get; set; }
		public string subdomain { get; set; }
	}
}

