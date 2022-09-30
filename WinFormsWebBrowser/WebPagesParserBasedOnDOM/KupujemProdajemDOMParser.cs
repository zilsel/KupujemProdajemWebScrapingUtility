using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWebBrowser.Properties;

namespace WinFormsWebBrowser.WebPagesParserBasedOnDOM
{
    internal static class KupujemProdajemDOMParser
    {

        private static string StripHTML(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return Regex.Replace(input, "<.*?>", String.Empty);

        }

        public static void KupujemProdajemDOMParserInsertArticles(WebBrowser webBrowser, string webArticleTitle,
            string webArticleAmount, string webArticleDescription, string pib, string companyName, string companyAddress)
        {
            HtmlElement articleName = webBrowser.Document.GetElementById(Resources.articleSuggestDomId);
            if (articleName != null)
                articleName.SetAttribute(Resources.valueAttributName, webArticleTitle);

            HtmlElement goods = webBrowser.Document.GetElementById(Resources.goodsDomId);
            if (goods != null)
                goods.SetAttribute(Resources.checkAttributName, Resources.checkAttributName);

            articleName = webBrowser.Document.GetElementById(Resources.articleNameDomId);
            if (articleName != null)
                articleName.SetAttribute(Resources.valueAttributName, webArticleTitle);

            HtmlElement goodsState = webBrowser.Document.GetElementById(Resources.dataDomId);
            if (goodsState != null)
                goodsState.SetAttribute(Resources.checkAttributName, Resources.checkAttributName);

            HtmlElement priceNumber = webBrowser.Document.GetElementById(Resources.priceNumberDomId);
            if (priceNumber != null)
                priceNumber.SetAttribute(Resources.valueAttributName, webArticleAmount);

            HtmlElement currencyRsd = webBrowser.Document.GetElementById(Resources.currencyRsdDomId);
            if (currencyRsd != null)
                currencyRsd.SetAttribute(Resources.checkAttributName, Resources.checkAttributName);

            HtmlElement articleDescription = webBrowser.Document.GetElementById(Resources.descriptionDomId);
            articleDescription.InnerText = KupujemProdajemDOMParser.StripHTML(webArticleDescription);

            HtmlElement promotionType = webBrowser.Document.GetElementById(Resources.promoTypeDomId);
            if (promotionType != null)
                promotionType.SetAttribute(Resources.checkAttributName, Resources.checkAttributName);

            HtmlElement registrationNumber = webBrowser.Document.GetElementById(Resources.registrationNumberDomId);
            if (registrationNumber != null)
                registrationNumber.SetAttribute(Resources.valueAttributName, pib);

            HtmlElement companyNameElement = webBrowser.Document.GetElementById(Resources.companyNameDomId);
            if (companyNameElement != null)
                companyNameElement.SetAttribute(Resources.valueAttributName, companyName);

            HtmlElement companyAddressElement = webBrowser.Document.GetElementById(Resources.companyAddressElementDomId);
            if (companyAddressElement != null)
                companyAddressElement.SetAttribute(Resources.valueAttributName, companyAddress);

            HtmlElement swear_yes = webBrowser.Document.GetElementById(Resources.swear_yesDomId);
            if (swear_yes != null)
                swear_yes.SetAttribute(Resources.checkAttributName, Resources.checkAttributName);

            HtmlElement accept_yes = webBrowser.Document.GetElementById(Resources.accept_yesDomId);
            if (accept_yes != null)
                accept_yes.SetAttribute(Resources.checkAttributName, Resources.checkAttributName);
        }
    }
}
