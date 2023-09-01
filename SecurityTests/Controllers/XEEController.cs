using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace SecurityTests.Controllers
{
	public class XEEController : Controller
	{
		[HttpGet]
		public ActionResult XmlEndpoint()
		{
			string xml = "<?xml version=\"1.0\" ?>" +
				"<!DOCTYPE attack[" +
				"<!ELEMENT attack ANY>" +
				"<!ENTITY xxe SYSTEM \"file:///c:/etc/passwd\">]>" +
				"<attack>&xxe;</attack>";

			XmlReader xmlReader = XmlReader.Create(new StringReader(xml), new XmlReaderSettings() { DtdProcessing = DtdProcessing.Parse });

			var document = new System.Xml.XPath.XPathDocument(xmlReader);
			var navigator = document.CreateNavigator();
			var output = navigator.InnerXml.ToString();
			return View("XmlEndpoint", output);
		}
	}
}