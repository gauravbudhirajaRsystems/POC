using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;

namespace VstoApiAddin
{
    public partial class SampleControl : UserControl
    {
        Document document;
        Issue issue = new Issue();
        public SampleControl()
        {
            InitializeComponent();
        }

        private void btnCheckSpelling_Click(object sender, EventArgs e)
        {

            document = Globals.ThisAddIn.Application.ActiveDocument;
            var firstParagraph = document.Paragraphs.First;
            Paragraph paragraph = new Paragraph()
            {
                ParagraphId = firstParagraph.ParaID,
                ParagraphText = firstParagraph.Range.Text,
                ParagraphsWordsList = firstParagraph.Range.Text.Split(new char[] { ' ' },
                                                                      StringSplitOptions.RemoveEmptyEntries).ToList(),
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7039/");
                /*Document*/
                var json = JsonConvert.SerializeObject(paragraph);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP POST  
                var response = client.PostAsync("api/word/spellcheck", data).Result;

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    var result = response.Content.ReadAsStringAsync().Result;
                    issue = JsonConvert.DeserializeObject<Issue>(result);

                }
            }

            if (issue != null)
            {
                chkIssueList.Items.Clear();
                chkIssueList.Items.AddRange(issue.WordList.ToArray());
                chkIssueList.Visible = Visible;

            }
        }

        private void btnFixSpelling_Click(object sender, EventArgs e)
        {
            //    DataRowView row As DataRowView = TryCast(item, DataRowView)
            //message += "Name: " & row("Name")
            List<FixedIssue> fixedIssueList = new List<FixedIssue>();
            List<FixedIssue> returnfixedIssueList = new List<FixedIssue>();
            foreach (var item in chkIssueList.CheckedItems)
            {
                fixedIssueList.Add(new FixedIssue { OldText = item.ToString(), NewText = string.Empty });
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7039/");
                /*Document*/
                var json = JsonConvert.SerializeObject(fixedIssueList);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP POST  
                var response = client.PostAsync("api/word/fixedspell", data).Result;

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    var result = response.Content.ReadAsStringAsync().Result;
                    returnfixedIssueList = JsonConvert.DeserializeObject<List<FixedIssue>>(result);
                }
            }

            if (returnfixedIssueList != null && returnfixedIssueList.Count > 0)
            {
                document = Globals.ThisAddIn.Application.ActiveDocument;
                //var firstParagraph = document.Paragraphs.First;
                //string text = firstParagraph.Range.Text;
                returnfixedIssueList.ForEach(returnfixedIssue =>
                {
                    document.Paragraphs.First.Range.Text = document.Paragraphs.First.Range.Text.
                                                Replace(returnfixedIssue.OldText, returnfixedIssue.NewText);
                });
            }

        }
    }
}
