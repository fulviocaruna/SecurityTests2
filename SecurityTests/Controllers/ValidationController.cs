using Microsoft.AspNetCore.Mvc;
using SecurityTests.Models.Validation;

namespace SecurityTests.Controllers
{
	public class ValidationController : Controller
	{
		private static List<Issue> issues = new List<Issue>();

		public IActionResult Index()
		{
			return View(issues);
		}

		public IActionResult Create()
		{
			return View();
		}

		/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Issue issue)
        {
            if (ModelState.IsValid)
            {
                issues.Add(issue);
                return RedirectToAction(nameof(Index));
            }
            
            return View(issue);
        }
        */

		/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateIssueViewModel issueVm)
        {
            if (ModelState.IsValid)
            {
                var issue = new Issue()
                {
                    Title = issueVm.Title,
                    Description = issueVm.Description,
                };

                issues.Add(issue);
                return RedirectToAction(nameof(Index));
            }

            return View(issueVm);
        }
        */

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Title,Description")] Issue issue)
		{
			if (ModelState.IsValid)
			{
				issues.Add(issue);
				return RedirectToAction(nameof(Index));
			}

			return View(issue);
		}

	}
}