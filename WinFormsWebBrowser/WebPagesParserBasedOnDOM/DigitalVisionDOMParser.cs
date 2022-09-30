using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = System.Windows.Forms.HtmlDocument;
using WinFormsWebBrowser.Properties;

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
            // TODO: implement functionality for mobile phones
        }

        private static string articleFilePath = "";
        private static bool processed = false;

        public static void DigitalVisionExtractMobilePhoneMasksDataFromPage(WebBrowser webBrowser, ProgressBar progressBar,
                                                                    TextBox tbSavePath, Uri baseUri)
        {
            try
            {
                ExtractMobilePhoneMasksDataFromHtml(webBrowser, progressBar, tbSavePath, baseUri);
            }
            catch (Exception)
            {
                string wd = Directory.GetCurrentDirectory();
                string defaultHtmlPagePath = "file://" + Path.Combine(wd, "HTMLPages", Resources.DefaultPageUrl);
                webBrowser.Navigate(defaultHtmlPagePath);
            }
        }

        public static void DigitalVisionExtractMobilePhoneMasksCategoryFromPage(WebBrowser webBrowser, ProgressBar progressBar,
                                                                    TextBox tbSavePath, Uri baseUri, ComboBox cbPhoneMasksCategory)
        {
            ExtractMobilePhoneMasksCategoryFromHtml(webBrowser, progressBar, tbSavePath, baseUri, cbPhoneMasksCategory);
        }

        private static string RemoveSpecialCharacters(string str)
        {
            char[] buffer = new char[str.Length];
            int idx = 0;

            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z')
                    || (c >= 'a' && c <= 'z')
                    || (c == '_') || (c == ' '))
                {
                    buffer[idx] = c;
                    idx++;
                }
            }

            return new string(buffer, 0, idx);
        }


        private static void ExtractMobilePhoneMasksCategoryFromHtml(WebBrowser webBrowser, ProgressBar progressBar, TextBox tbSavePath, Uri baseUri, ComboBox phoneMasksCategory)
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

        // TODO: Method refactoring and optimization
        private static void ExtractMobilePhoneMasksDataFromHtml(WebBrowser webBrowser, ProgressBar progressBar, TextBox tbSavePath, Uri baseUri)
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

                    if (childrenHtmlDocument[0].InnerText.Contains("Stranica:"))
                    {
                        childrenHtmlDocument = htmlElementCollection[5].Children;
                    }

                    progressBar.Minimum = 1;
                    progressBar.Maximum = childrenHtmlDocument.Count * 2;
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
                        string amount = "";

                        // Create a pattern for article elements:
                        string patternTitle = @".*<a class=\""(.*)\"" href=\""(.*)\"">(.*)</a>";
                        string patternLink = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";
                        string patternImage = @"img\s+(?:[^>]*?\s+)?src=([""'])(.*?)\1";
                        string patternAmount = @"<div class=""cena"">(.*?)</div>";

                        // Create a regular expression:
                        // Title:
                        Regex rg = new Regex(patternTitle, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        MatchCollection matched = rg.Matches(innerAHrefHtml);
                        articleTitle = matched[0].Groups[3].Value;

                        // Link:
                        rg = new Regex(patternLink, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        matched = rg.Matches(innerAHrefHtml);
                        articleLink = matched[0].Groups[1].Value;

                        // Amount:
                        rg = new Regex(patternAmount, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        matched = rg.Matches(innerAHrefHtml);
                        if (matched.Count > 1 && matched[1].Groups.Count > 1 && matched[1].Groups[1].Value != null && matched[1].Groups[1].Value.Contains("RSD"))
                        {
                            amount = matched[1].Groups[1].Value.Replace("Sa PDV-om:", "").Replace("RSD", "").Trim();
                            amount = Math.Round(float.Parse(amount)).ToString();
                        }

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
                            file.WriteLine("Title$" + articleTitle);
                            file.WriteLine("WebLink$" + new Uri(baseUri, articleLink).OriginalString);
                            file.WriteLine("Amount$" + amount);
                            // Description is added after first iteration
                        }

                        using (WebClient webClient = new WebClient())
                        {
                            string pathToDownloadImage = System.IO.Path.Combine(articleDirectory, string.Format(@"{0}.png", articleTitle));
                            string pathToDownloadImageTargetResolution = System.IO.Path.Combine(articleDirectory, string.Format(@"{0}TargetResolution.jpeg", articleTitle));
                            webClient.DownloadFile(new Uri(baseUri.OriginalString + imageSegments[0]), pathToDownloadImage);

                            using (Bitmap bitmap = (Bitmap)Image.FromFile(pathToDownloadImage))
                            {
                                using (Bitmap newBitmap = new Bitmap(bitmap, new Size(480, 320)))
                                {
                                    newBitmap.Save(pathToDownloadImageTargetResolution, ImageFormat.Jpeg);
                                }
                            }
                        }

                        progressBar.PerformStep();
                    }
                }
            }

            if (String.IsNullOrEmpty(tbSavePath.Text.Trim()))
            {
                return;
            }

            string[] loadedArticles = Directory.GetDirectories(tbSavePath.Text);

            for (int i = 0; i < loadedArticles.Length; i++)
            {
                processed = false;
                DirectoryInfo directoryInfo = new DirectoryInfo(loadedArticles[i]);
                string webArticleTitle = directoryInfo.Name;

                string[] title;
                string[] webLink;
                string webPageLink = String.Empty;

                articleFilePath = Path.Combine(loadedArticles[i], webArticleTitle + ".txt");
                using (StreamReader sr = new StreamReader(articleFilePath))
                {
                    title = sr.ReadLine().Split('$');
                    webLink = sr.ReadLine().Split('$');
                    webPageLink = webLink[1];
                }

                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(webPageLink);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                var responseString = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(responseString);

                string description = String.Empty;
                foreach (HtmlNode div in htmlDocument.DocumentNode.SelectNodes("//*[@id=\"tabs-1\"]"))
                {
                    description = div.InnerHtml;
                }

                string articleDescription = "Desc$";
                string oneLineDescription = description.Replace('\r', ' ').Replace('\n', ' ').Trim();
                oneLineDescription = StripHTML(oneLineDescription);

                if (string.IsNullOrEmpty(oneLineDescription))
                {
                    oneLineDescription = title[1];
                }
                oneLineDescription += "- Za sve informacije obratiti se putem kontakta, telefon i/ili porukom.";

                using (StreamWriter sw = new StreamWriter(articleFilePath, true))
                {
                    sw.WriteLine(articleDescription + oneLineDescription);
                }

                progressBar.PerformStep();
            }
        }

        private static string StripHTML(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return Regex.Replace(input, "<.*?>", String.Empty);

        }
    }
}
