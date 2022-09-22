using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsWebBrowser.WebPagesParserBasedOnDOM
{
    internal static class DigitalVisionDOMParser
    {
        public static void DigitalVisionExtractMobileDataFromPage(WebBrowser webBrowser, ProgressBar progressBar, 
                                                                    TextBox tbSavePath, Uri baseUri)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbSavePath.Text = fbd.SelectedPath;
                    tbSavePath.Refresh();

                    HtmlDocument htmlDocument = webBrowser.Document;

                    HtmlElementCollection htmlElementCollection = htmlDocument.GetElementsByTagName("ul");
                    HtmlElementCollection childrenHtmlDocument = htmlElementCollection[4].Children;

                    progressBar.Minimum = 1;
                    progressBar.Maximum = childrenHtmlDocument.Count;
                    progressBar.Value = 1;
                    progressBar.Step = 1;

                    for (int i = 0; i < childrenHtmlDocument.Count; i++)
                    {

                        // Get first child element since it contains image and article title
                        HtmlElement htmlElement = childrenHtmlDocument[i];
                        HtmlElementCollection article = htmlElement.Children;
                        string innerHtml = article[0].Children[0].InnerHtml;

                        string articleTitle = "";
                        string articleLink = "";
                        string articleImage = "";

                        // Create a pattern for article elements:
                        string patternTitle = @"img\s+(?:[^>]*?\s+)?alt=([""'])(.*?)\1";
                        string patternLink = @"<a\s+(?:[^>]*?\s+)?href=([""'])(.*?)\1";
                        string patternImage = @"img\s+(?:[^>]*?\s+)?src=([""'])(.*?)\1";

                        // Create a regular expression:
                        // Title:
                        Regex rg = new Regex(patternTitle, RegexOptions.IgnoreCase);
                        MatchCollection matched = rg.Matches(innerHtml);
                        articleTitle = matched[0].Groups[2].Value;

                        // Link:
                        rg = new Regex(patternLink, RegexOptions.IgnoreCase);
                        matched = rg.Matches(innerHtml);
                        articleLink = matched[0].Groups[2].Value;

                        // Image:
                        rg = new Regex(patternImage, RegexOptions.IgnoreCase);
                        matched = rg.Matches(innerHtml);
                        articleImage = matched[0].Groups[2].Value;

                        string[] imageSegments = articleImage.Split('&');

                        // ARTICLE IS EXTRACTED FROM WEB SITE
                        // SAVE ARTICLE TO FILE SYSTEM
                        // DOWNLOAD ARTICLE IMAGE

                        string articleDirectory = System.IO.Path.Combine(fbd.SelectedPath, articleTitle);
                        string articleFile = System.IO.Path.Combine(articleDirectory, articleTitle + ".txt");
                        Directory.CreateDirectory(articleDirectory);

                        using (StreamWriter file = new StreamWriter(articleFile, append: true))
                        {
                            file.WriteLine(articleTitle);
                            file.WriteLine(articleLink);
                        }

                        using (WebClient webClient = new WebClient())
                        {
                            string pathToDownloadImage = System.IO.Path.Combine(articleDirectory, string.Format(@"{0}.png", articleTitle));
                            webClient.DownloadFile(new Uri(baseUri.OriginalString + imageSegments[0]), pathToDownloadImage);
                        }

                        progressBar.PerformStep();
                    }
                }
            }
        }
    }
}
