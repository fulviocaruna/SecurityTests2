using System.ComponentModel.DataAnnotations;

namespace SecurityTests.Models.Validation
{
	public class Issue
	{
		public Issue()
		{
			this.CreationDate = DateTime.Now.ToString();
		}
		public int Id { get; set; }

		[Required]
		[RegularExpression(@"^[a-zA-Z]{1,10}$")]
		public string Title { get; set; } = string.Empty;

		[Required]
		[RegularExpression(@"^[a-zA-Z]{1,50}$")]
		public string Description { get; set; } = string.Empty;

		[Display(Name = "Creation Date")]
		public String CreationDate { get; set; }
	}
}