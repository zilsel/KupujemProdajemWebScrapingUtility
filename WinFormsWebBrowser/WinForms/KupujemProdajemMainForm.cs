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

            AccessUIControls(true);
        }

        private void DigitalVisionGetMobilePhoneMasks()
        {
            DigitalVisionDOMParser.DigitalVisionExtractMobilePhoneMasksDataFromPage(this.webBrowser, this.progressBar, this.tbSavePath, this.baseUri);

            AccessUIControls(true);
        }

        private void DigitalVisionMobileMaskCategory()
        {
            DigitalVisionDOMParser.DigitalVisionExtractMobilePhoneMasksCategoryFromPage(this.webBrowser, this.progressBar, this.tbSavePath, this.baseUri, this.cbMobilePhoneMasks);

            AccessUIControls(true);
        }

        #endregion

        #region [ Kupujem Prodajem ]

        private void KupujemProdajemLogin()
        {
            AccessUIControls(true);
        }

        private void KupujemProdajemOglasi()
        {
            KupujemProdajemDOMParser.KupujemProdajemDOMParserInsertArticles(this.webBrowser, webArticleTitle, webArticleAmount,
                webArticleDescription, this.tbPIB.Text, this.tbCompanyName.Text, this.tbCompanyAddress.Text);

            AccessUIControls(true);
        }

        #endregion

        #endregion

        #region [ Event Handlers ]

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(((WebBrowser)sender).ReadyState != WebBrowserReadyState.Complete ||
               ((WebBrowser)sender).Url.OriginalString.Contains("file://"))
            {
                return;
            }

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

            AccessUIControls(true);
        }

        private void tbAddressBar_MouseMove(object sender, MouseEventArgs e)
        {
            this.toolTip.SetToolTip((Control)sender, "ADRESA TRENUTNO PRIKAZANE WEB STRANICE");
        }
        private void btnRefresh_MouseMove(object sender, MouseEventArgs e)
        {
            this.toolTip.SetToolTip((Control)sender, "PONOVO UČITAJ KATEGORIJU U OKVIRU WEB BROWSERA");
        }

        private void btnExtractDataDigitalVisionMobilePhones_Click(object sender, EventArgs e)
        {
            this.baseUri = new Uri("https://digitalvision.rs");
            this.currentTypeOfWebPage = TypeOfWebPage.DigitalVisionMobilePhones;
            Uri address = new Uri(baseUri.OriginalString + @"/razno-2841");
            this.tbAddressBar.Text = address.OriginalString;
            this.webBrowser.Navigate(address);
            AccessUIControls(false);
        }

        private void btnPhoneMask_Click(object sender, EventArgs e)
        {
            this.baseUri = new Uri("https://digitalvision.rs");
            this.currentTypeOfWebPage = TypeOfWebPage.DigitalVisionPhoneMasks;

            DigitalVisionDOMParser.PhoneMaskCategoryItem selectedItem = (DigitalVisionDOMParser.PhoneMaskCategoryItem)cbMobilePhoneMasks.SelectedItem;
            if(selectedItem != null)
            {
                Uri address = new Uri(selectedItem.Link);
                this.tbAddressBar.Text = address.OriginalString;
                this.webBrowser.Navigate(address);
                AccessUIControls(false);
            }
            else
            {
                string wd = Directory.GetCurrentDirectory();
                string defaultHtmlPagePath = "file://" + Path.Combine(wd, "HTMLPages", Resources.DefaultPageUrl);
                this.tbAddressBar.Text = "GREŠKA PRILIKOM KORIŠĆENJA PROGRAMA";
                this.webBrowser.Navigate(defaultHtmlPagePath);
                return;
            }
        }

        private void btnMobileMaskCategory_Click(object sender, EventArgs e)
        {
            this.baseUri = new Uri("https://digitalvision.rs");
            this.currentTypeOfWebPage = TypeOfWebPage.DigitalVisionPhoneMasksCategory;
            Uri address = new Uri(baseUri.OriginalString + @"/torbice-za-telefone");
            this.tbAddressBar.Text = address.OriginalString;
            this.webBrowser.Navigate(address);
            AccessUIControls(false);
        }

        private void cbMobilePhoneMasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.baseUri = new Uri(((DigitalVisionDOMParser.PhoneMaskCategoryItem)cbMobilePhoneMasks.SelectedItem).Link);
            this.currentTypeOfWebPage = TypeOfWebPage.DigitalVisionPhoneMaskSelection;
            Uri address = new Uri(baseUri.OriginalString);
            this.tbAddressBar.Text = address.OriginalString;
            this.webBrowser.Navigate(address);
            AccessUIControls(false);
        }

        private void btnKupujemProdajemLogin_Click(object sender, EventArgs e)
        {
            this.baseUri = new Uri("https://www.kupujemprodajem.com/login");
            this.currentTypeOfWebPage = TypeOfWebPage.KupujemProdajemLogin;
            this.tbAddressBar.Text = this.baseUri.OriginalString;
            this.webBrowser.Navigate(this.baseUri);

            AccessUIControls(false);
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
            if(this.articleIndex >= this.maxArticles)
            {
                return;
            }
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
            if (this.loadedArticles.Length == 0)
                return;

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
            this.tbAddressBar.Text = this.baseUri.OriginalString;
            this.webBrowser.Navigate(this.baseUri);

            AccessUIControls(false);

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

        private void AccessUIControls(bool value)
        {
            this.btnMobileMaskCategory.Enabled = value;
            this.btnPhoneMask.Enabled = value;
            this.btnDigitalVisionMobilePhones.Enabled = value;
            this.btnKupujemProdajemLogin.Enabled = value;
            this.btnLoadArticles.Enabled = value;
            this.btnNextArticl.Enabled = value;
            this.cbMobilePhoneMasks.Enabled = value;
            this.rbContact.Enabled = value;
            this.rbAmount.Enabled = value;
            this.btnRefresh.Enabled = value;

            this.Cursor = value ? Cursors.Default : Cursors.WaitCursor;
        }


        #endregion
    }
}
