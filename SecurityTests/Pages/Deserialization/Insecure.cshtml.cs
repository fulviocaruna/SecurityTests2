using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace SecurityTests.Pages.Deserialization
{
	public class InsecureModel : PageModel
	{
		public void OnGet()
		{
			var payload = @"{
'$type':'System.Windows.Data.ObjectDataProvider, PresentationFramework,
Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35',
'MethodName':'Start',
'MethodParameters':{
'$type':'System.Collections.ArrayList, mscorlib, Version=4.0.0.0,
Culture=neutral, PublicKeyToken=b77a5c561934e089',
'$values':['cmd', '/c notepad']
},
'ObjectInstance':{'$type':'System.Diagnostics.Process, System,
Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'}
}";
			/*
            var data = JsonConvert.DeserializeObject(
                payload,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                }
            );
            */

			var data = JsonConvert.DeserializeObject(
			   payload,
			   new JsonSerializerSettings()
			   {
				   TypeNameHandling = TypeNameHandling.None
			   }
		   );

		}
	}
}