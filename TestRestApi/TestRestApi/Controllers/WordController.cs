using Microsoft.AspNetCore.Mvc;
namespace TestRestApi.Controllers
{
    [Route("api/word")]
    [ApiController]
    public class WordController : ControllerBase
    {
        [HttpPost("spellcheck")]
        public IActionResult SpellCheck([FromBody] Paragraph paragraph)
        {

            Issue issue = new()
            {
                Id = paragraph.ParagraphId,
                Text = paragraph.ParagraphText,
                WordList = new List<string>()
            };
            foreach (string word in paragraph.ParagraphsWordsList)
            {
                if (word == "si" || word == "samp" || word == "tex" || word == "commuinction\r")
                    issue.WordList.Add(word);
            }
            return Ok(issue);
        }

        [HttpPost("fixedspell")]
        public IActionResult FixedSpell([FromBody] List<FixedIssue> fixedIssueList)
        {
            List<FixedIssue> returnFixedIssueList = new List<FixedIssue>();
            
                fixedIssueList.ForEach(fixedIssue =>
                {
                    if (fixedIssue.OldText == "si")
                    {
                        returnFixedIssueList.Add(new FixedIssue { OldText = fixedIssue.OldText, NewText = "is" });
                    }
                    else if (fixedIssue.OldText == "samp")
                    {
                        returnFixedIssueList.Add(new FixedIssue { OldText = fixedIssue.OldText, NewText = "sample" });
                    }
                    else if (fixedIssue.OldText == "tex")
                    {
                        returnFixedIssueList.Add(new FixedIssue { OldText = fixedIssue.OldText, NewText = "text" });
                    }
                    else if (fixedIssue.OldText == "commuinction\r")
                    {
                        returnFixedIssueList.Add(new FixedIssue { OldText = fixedIssue.OldText, NewText = "communication" });
                    }
                });
            
            return Ok(returnFixedIssueList);
        }
    }
}
