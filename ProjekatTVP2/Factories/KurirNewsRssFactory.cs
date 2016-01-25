using ProjekatTVP2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace ProjekatTVP2.Factories
{
    class KurirNewsRssFactory
    {
        private static int IdCounter = 0;

        public async Task<List<KurirNews>> ReadRssVesti(string url, NewsType tipVesti)
        {
            //string kurirUrl = "http://www.kurir.rs/rss/vesti/";
            SyndicationClient client = new SyndicationClient();
            SyndicationFeed feed = await client.RetrieveFeedAsync(new Uri(url));
            List<KurirNews> kurirNews = new List<KurirNews>();
            if (feed != null)
            {
                foreach (SyndicationItem item in feed.Items)
                {
                    string[] slikaText = item.Summary.Text.Split(new[] { "<img src=\"", "\"><br>" }, StringSplitOptions.RemoveEmptyEntries);
                    kurirNews.Add(new KurirNews()
                    {
                        Id = IdCounter++,
                        ImagePath = slikaText.Length > 0 ? slikaText[0] : "",
                        Summary = slikaText.Length > 1 ? slikaText[1] : "",
                        PublishedDateTime = item.PublishedDate.DateTime,
                        Title = item.Title.Text,
                        Url = item.Links[0].NodeValue ?? item.Id,
                        NewsType = tipVesti.ToString()
                    });
                }
            }
            return kurirNews;
        }
    }
}
