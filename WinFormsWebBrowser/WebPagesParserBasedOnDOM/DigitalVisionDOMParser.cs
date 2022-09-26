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

        /// <summary>
        /// This is the item of the phone mask category combo box
        /// </summary>
        public class PhoneMaskCategoryItem
        {
            public string categoryName;
            public string categoryHtmlLink;

            public PhoneMaskCategoryItem(string name, string id)
            {
                categoryName = name;
                categoryHtmlLink = id;
            }

            public string Name
            {
                get { return categoryName; }
                set { categoryName = value; }
            }

            public string Link
            {
                get { return categoryHtmlLink; }
                set { categoryHtmlLink = value; }
            }
        }

        public static void DigitalVisionExtractMobileDataFromPage(WebBrowser webBrowser, ProgressBar progressBar,
                                                                    TextBox tbSavePath, Uri baseUri)
        {
            ExtractDataFromHtml(webBrowser, progressBar, tbSavePath, baseUri);
        }

        public static void DigitalVisionExtractMobilePhoneMasksDataFromPage(WebBrowser webBrowser, ProgressBar progressBar,
                                                                    TextBox tbSavePath, Uri baseUri)
        {
            ExtractDataFromHtml(webBrowser, progressBar, tbSavePath, baseUri);
        }

        public static void DigitalVisionExtractMobilePhoneMasksCategoryFromPage(WebBrowser webBrowser, ProgressBar progressBar,
                                                                    TextBox tbSavePath, Uri baseUri, ComboBox cbPhoneMasksCategory)
        {
            ExtractCategoryFromHtml(webBrowser, progressBar, tbSavePath, baseUri, cbPhoneMasksCategory);
        }

        private static string RemoveSpecialCharacters(string str)
        {
            char[] buffer = new char[str.Length];
            int idx = 0;

            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z')
                    || (c >= 'a' && c <= 'z')
                    || (c == '.') || (c == '_') || (c == ' '))
                {
                    buffer[idx] = c;
                    idx++;
                }
            }

            return new string(buffer, 0, idx);
        }


        private static void ExtractCategoryFromHtml(WebBrowser webBrowser, ProgressBar progressBar, TextBox tbSavePath, Uri baseUri, ComboBox phoneMasksCategory)
        {
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
                string categoryLink = article[0].InnerHtml;
                string category = article[1].Children[0].InnerHtml;
                string link = string.Empty;


                string patternLink = @"a\s+(?:[^>]*?\s+)?href=([""'])(.*?)\1";

                // Create a regular expression:
                // Title:
                Regex rg = new Regex(patternLink, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                MatchCollection matched = rg.Matches(categoryLink);
                link = matched[0].Groups[2].Value;

                baseUri = new Uri(baseUri, link);

                phoneMasksCategory.Items.Add(new PhoneMaskCategoryItem(category, baseUri.OriginalString));
            }
        }

        private static void ExtractDataFromHtml(WebBrowser webBrowser, ProgressBar progressBar, TextBox tbSavePath, Uri baseUri)
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
                        string innerImgHtml = article[0].Children[0].InnerHtml;
                        string innerAHrefHtml = article[0].Children[1].InnerHtml;

                        string articleTitle = "";
                        string articleLink = "";
                        string articleImage = "";

                        // Create a pattern for article elements:
                        string patternTitle = @".*<a class=\""(.*)\"" href=\""(.*)\"">(.*)</a>";
                        string patternLink = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";
                        string patternImage = @"img\s+(?:[^>]*?\s+)?src=([""'])(.*?)\1";

                        // Create a regular expression:
                        // Title:
                        Regex rg = new Regex(patternTitle, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        MatchCollection matched = rg.Matches(innerAHrefHtml);
                        articleTitle = matched[0].Groups[3].Value;

                        // Link:
                        rg = new Regex(patternLink, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        matched = rg.Matches(innerAHrefHtml);
                        articleLink = matched[0].Groups[0].Value;

                        // Image:
                        rg = new Regex(patternImage, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        matched = rg.Matches(innerImgHtml);
                        articleImage = matched[0].Groups[2].Value;

                        string[] imageSegments = articleImage.Split('&');

                        // ARTICLE IS EXTRACTED FROM WEB SITE
                        // SAVE ARTICLE TO FILE SYSTEM
                        // DOWNLOAD ARTICLE IMAGE

                        articleTitle = RemoveSpecialCharacters(articleTitle);
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
