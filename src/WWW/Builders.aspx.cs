using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.IO;

namespace WWW
{
	public partial class Builders : System.Web.UI.Page
	{
		public string[] BuilderNames = new string[]{};

		public void Page_Load(object sender, EventArgs e)
		{
			var list = new List<string> ();

			foreach (var dir in Directory.GetDirectories(Server.MapPath("builders"))) {
				list.Add (Path.GetFileNameWithoutExtension (dir));
			}

			BuilderNames = list.ToArray ();
		}
	}
}

