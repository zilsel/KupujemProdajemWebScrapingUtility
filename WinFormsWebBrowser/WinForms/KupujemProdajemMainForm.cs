using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWebBrowser.Properties;
using WinFormsWebBrowser.WebPagesParserBasedOnDOM;

namespace WinFormsWebBrowser
{
    /*
     *  Kupujem Prodajem main form class
     */
    public partial class KupujemProdajemMainForm : Form
    {
        #region [ Private Properties ]

        private Uri baseUri = null;
        private enum TypeOfWebPage { None = 0, DigitalVisionMobilePhones, DigitalVisionPhoneMasks, DigitalVisionPhoneMasksCategory, DigitalVisionPhoneMaskSelection, KupujemProdajemLogin, KupujemProdajemOglasi };

        private TypeOfWebPage currentTypeOfWebPage = TypeOfWebPage.None;

        private string[] loadedArticles;
        private int articleIndex = 0;
        private int maxArticles = 0;
        private string webArticleTitle;
        private string webArticleAmount;
        private string webArticleDescription;
        private string webLink;

        #endregion

        #region [ Constructors ]

        public KupujemProdajemMainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region [ DOM Parser Methods ]

        #region [ Digital Vision ]

        private void DigitalVisionGetMobilePhones()
        {
            DigitalVisionDOMParser.DigitalVisionExtractMobileDataFromPage(this.webBrowser, this.progressBar, this.tbSavePath, this.baseUri);

            this.btnDigitalVisionMobilePhones.Enabled = true;
        }

        private void DigitalVisionGetMobilePhoneMasks()
        {
            DigitalVisionDOMParser.DigitalVisionExtractMobilePhoneMasksDataFromPage(this.webBrowser, this.progressBar, this.tbSavePath, this.baseUri);

            this.btnPhoneMask.Enabled = true;
        }

        private void DigitalVisionMobileMaskCategory()
        {
            DigitalVisionDOMParser.DigitalVisionExtractMobilePhoneMasksCategoryFromPage(this.webBrowser, this.progressBar, this.tbSavePath, this.baseUri, this.cbMobilePhoneMasks);

            this.btnMobileMaskCategory.Enabled = true;
        }

        #endregion

        #region [ Kupujem Prodajem ]

        private void KupujemProdajemLogin()
        {
            this.btnKupujemProdajemLogin.Enabled = true;
        }

        private void KupujemProdajemOglasi()
        {
            KupujemProdajemDOMParser.KupujemProdajemDOMParserInsertArticles(this.webBrowser, webArticleTitle, webArticleAmount,
                webArticleDescription, this.tbPIB.Text, this.tbCompanyName.Text, this.tbCompanyAddress.Text);

            this.btnLoadArticles.Enabled = true;
        }

        #endregion

        #endregion

        #region [ Event Handlers ]

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (currentTypeOfWebPage)
            {
                case TypeOfWebPage.DigitalVisionMobilePhones:

                    DigitalVisionGetMobilePhones();
                    this.currentTypeOfWebPage = TypeOfWebPage.None;
                    break;
                case TypeOfWebPage.DigitalVisionPhoneMasks:

                    DigitalVisionGetMobilePhoneMasks();
                    this.currentTypeOfWebPage = TypeOfWebPage.None;
                    break;
                case TypeOfWebPage.DigitalVisionPhoneMasksCategory:

                    DigitalVisionMobileMaskCategory();
                    this.currentTypeOfWebPage = TypeOfWebPage.None;
                    break;
                case TypeOfWebPage.KupujemProdajemLogin:

                    KupujemProdajemLogin();
                    this.currentTypeOfWebPage = TypeOfWebPage.None;
                    break;
                case TypeOfWebPage.KupujemProdajemOglasi:

                    KupujemProdajemOglasi();
                    this.currentTypeOfWebPage = TypeOfWebPage.None;
                    break;
                case TypeOfWebPage.DigitalVisionPhoneMaskSelection:
                    // DO NOTHING
                    this.currentTypeOfWebPage = TypeOfWebPage.None;
                    break;
                case TypeOfWebPage.None:
                    this.currentTypeOfWebPage = TypeOfWebPage.None;
                    break;
                default:
                    break;
            }

            this.btnDigitalVisionMobilePhones.Enabled = true;
        }

        private void btnExtractDataDigitalVisionMobilePhones_Click(object sender, EventArgs e)
        {
            this.baseUri = new Uri("https://digitalvision.rs");
            this.currentTypeOfWebPage = TypeOfWebPage.DigitalVisionMobilePhones;
            this.webBrowser.Navigate(new Uri(baseUri.OriginalString + @"/razno-2841"));
            this.webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            this.btnDigitalVisionMobilePhones.Enabled = false;
        }

        private void btnPhoneMask_Click(object sender, EventArgs e)
        {
            this.baseUri = new Uri("https://digitalvision.rs");
            this.currentTypeOfWebPage = TypeOfWebPage.DigitalVisionPhoneMasks;

            DigitalVisionDOMParser.PhoneMaskCategoryItem selectedItem = (DigitalVisionDOMParser.PhoneMaskCategoryItem)cbMobilePhoneMasks.SelectedItem;
            if(selectedItem != null)
            {
                this.webBrowser.Navigate(new Uri(selectedItem.Link));
            }
            else
            {
                string wd = Directory.GetCurrentDirectory();
                string defaultHtmlPagePath = "file://" + Path.Combine(wd, "HTMLPages", Resources.DefaultPageUrl);
                this.webBrowser.Navigate(defaultHtmlPagePath);
                return;
            }
            
            this.webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            this.btnPhoneMask.Enabled = false;
        }

        private void btnMobileMaskCategory_Click(object sender, EventArgs e)
        {
            this.baseUri = new Uri("https://digitalvision.rs");
            this.currentTypeOfWebPage = TypeOfWebPage.DigitalVisionPhoneMasksCategory;
            this.webBrowser.Navigate(new Uri(baseUri.OriginalString + @"/torbice-za-telefone"));
            this.webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            this.btnMobileMaskCategory.Enabled = false;
        }

        private void cbMobilePhoneMasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.baseUri = new Uri(((DigitalVisionDOMParser.PhoneMaskCategoryItem)cbMobilePhoneMasks.SelectedItem).Link);
            this.currentTypeOfWebPage = TypeOfWebPage.DigitalVisionPhoneMaskSelection;
            this.webBrowser.Navigate(new Uri(baseUri.OriginalString));
        }

        private void btnKupujemProdajemLogin_Click(object sender, EventArgs e)
        {
            this.baseUri = new Uri("https://www.kupujemprodajem.com/login");
            this.currentTypeOfWebPage = TypeOfWebPage.KupujemProdajemLogin;
            this.webBrowser.Navigate(this.baseUri);
            this.webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            this.btnKupujemProdajemLogin.Enabled = false;
        }

        private void btnArticlPath_Click(object sender, EventArgs e)
        {
            // Load articles:
            this.articleWebLink.Visible = true;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.tbLoadArticles.Text = fbd.SelectedPath;

                    if (Directory.Exists(this.tbLoadArticles.Text))
                    {
                        this.loadedArticles = Directory.GetDirectories(this.tbLoadArticles.Text);
                        this.lblArticlCount.Text = String.Format(lblArticlCount.Text, loadedArticles.Length);
                        this.maxArticles = loadedArticles.Length;
                        UploadArticleToKupujemProdajem();
                    }
                }
            }
        }

        private void btnNextArticl_Click(object sender, EventArgs e)
        {
            this.articleIndex++;
            this.btnNextArticl.Enabled = !(this.articleIndex == this.maxArticles);
            ClearArticleData();
            UploadArticleToKupujemProdajem();
        }

        private void articleWebLink_Click(object sender, EventArgs e)
        {
            Process.Start(this.articleWebLink.Text);
        }

        private void oPROGRAMUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutApplication = new aboutApplication();
            aboutApplication.ShowDialog();
        }

        #endregion

        #region [ Load/Store Articles ]

        private void UploadArticleToKupujemProdajem()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(this.loadedArticles[articleIndex]);
            this.webArticleTitle = directoryInfo.Name;
            this.lblArticleName.Text = "NAZIV ARTIKLA ({0}/{1}):";
            this.lblArticleName.Text = String.Format(lblArticleName.Text, this.articleIndex + 1, this.loadedArticles.Length) + " " + this.webArticleTitle;

            using (StreamReader sr = new StreamReader(Path.Combine(this.loadedArticles[articleIndex], webArticleTitle + ".txt")))
            {
                string title = sr.ReadLine();

                string[] webLink = sr.ReadLine().Split('$');
                this.webLink = webLink[1];
                this.articleWebLink.Text = this.webLink;

                string[] amount = sr.ReadLine().Split('$');
                this.webArticleAmount = amount[1];

                while (!sr.EndOfStream)
                {
                    string[] desc = sr.ReadLine().Split('$');
                    this.webArticleDescription = webArticleDescription + " " + desc[1];
                }
            }

            string articleImagePath = Path.Combine(this.loadedArticles[articleIndex], webArticleTitle + ".png");
            if (!File.Exists(articleImagePath))
            {
                articleImagePath = Path.Combine(this.loadedArticles[articleIndex], webArticleTitle + ".jpg");
            }

            if (File.Exists(articleImagePath))
            {
                this.pbArticleImage.Image = new Bitmap(articleImagePath);
            }

            this.baseUri = new Uri("https://www.kupujemprodajem.com/oglasi.php?action=new");
            this.currentTypeOfWebPage = TypeOfWebPage.KupujemProdajemOglasi;
            this.webBrowser.Navigate(this.baseUri);
            this.webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            this.btnLoadArticles.Enabled = false;

        }

        #endregion

        #region [ Utils ]

        private void ClearArticleData()
        {
            this.webArticleTitle = String.Empty;
            this.webArticleAmount = String.Empty;
            this.webArticleDescription = String.Empty;
            this.webLink = String.Empty;
        }


        #endregion
    }
}
