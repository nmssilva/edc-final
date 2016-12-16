using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace EDC_Trabalho3
{
    public partial class Feed : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            string url = feedChooser.SelectedValue;
            if (url.Length == 0)
            {
                url = "http://www.portugal.gov.pt/pt/o-governo/cm/comunicados/rss";
            }
            XmlReader reader = XmlReader.Create(url);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            XmlDataSource_feed.Data = doc.OuterXml;
            XmlDataSource_feed.DataBind();
            XmlDataSource_feed.XPath = "/rss/channel";


            XmlDocument xdoc = XmlDataSource_feed.GetXmlDocument();
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes(XmlDataSource_feed.XPath);

            foreach (XmlNode node in nodes)
            {
                titleLabel.Text = node.Attributes[0].Value;
                linkLabel.Text = node.Attributes[1].Value;
                descriptionLabel.Text = node.Attributes[3].Value;
                languageLabel.Text = node.Attributes[2].Value;
                ManagingEditorLabel.Text = node.Attributes[4].Value;
                WebMasterLabel.Text = node.Attributes[5].Value;
                LastBuildDateLabel.Text = node.Attributes[6].Value;
                CategoryLabel.Text = node.Attributes[7].Value;

                if (node.Attributes[8].Value.Length != 0)
                {
                    channelImage.Attributes["src"] = node.Attributes[8].Value;
                }
                else
                {
                    channelImage.Attributes["src"] = "http://www.freeiconspng.com/uploads/no-image-icon-23.jpg";
                }
            }
            XmlNodeList nodes_items = root.SelectNodes("/rss/channel/item");

            String innerHtml = "";
            feed_info.Visible = true;
            foreach (XmlNode node in nodes_items)
            {
                String node_html = "<div class=\"col-xs-12 col-md-6 col-lg-4\"><div class=\"well\" style=\"min-height: 300px\"> <div class=\"media\"> <div class=\"media-body\"> <h4 class=\"media-heading\"><a style=\" color: #0f1011;text-decoration: none;font-weight: bold;\" target=\"_blank\" href=\"" + node.Attributes[2].Value + "\">" + node.Attributes[0].Value + "</a></h4> <div class=\"row\"><div class=\"col-md-6\"><small><i class=\"fa fa-tag\"></i> " + node.Attributes[3].Value + "</small></div><div class=\"col-md-6\" style=\"text-align: right\"><small><i class=\"fa fa-calendar - check - o\"></i> " + node.Attributes[4].Value + "</small></div></div><p>" + node.Attributes[1].Value + "</p></div></div></div></div>";
                innerHtml += node_html;
            }
            counter_news.Text = nodes_items.Count.ToString();
            news.InnerHtml = innerHtml;

            XmlDocument doc_1 = new XmlDocument();
            doc_1.Load(@"D:\Nuno Silva\Documents\UA\ano4\CV\opencv\aula1\WebApplication1\WebApplication1\App_Data\FeedsList.xml");
            XmlNodeList elemList = doc_1.GetElementsByTagName("feed");
            String[] feeds = new String[elemList.Count];
            HashSet<String> categories = new HashSet<String>();
            for (int i = 0; i < elemList.Count; i++)
            {
                feeds[i] = elemList[i].Attributes["url"].Value;
            }
            for (int i = 0; i < feeds.Length; i++)
            {
                XmlReader reader_1 = XmlReader.Create(feeds[i]);
                XmlDocument doc_aux = new XmlDocument();
                doc_aux.Load(reader_1);
                reader.Close();
                //XmlNodeList aux = doc_aux.SelectNodes("/rss/channel/item//*[contains(.," + findString+")]");
                XmlNodeList aux = doc_aux.SelectNodes("/rss/channel/item/category");
                foreach(XmlNode cat in aux)
                {
                    if(!categories.Contains(cat.InnerText) && cat.InnerText != "")
                    {
                        categories.Add(cat.InnerText);
                        //teste.Value += ("\n" + cat.InnerText);
                    }
                }
            }
                
            DD_Category.DataSource = categories;
            DD_Category.DataBind();

        }
        protected void Search_New(object sender, EventArgs e)
        {
            XmlDocument doc_1 = new XmlDocument();
            doc_1.Load(@"D:\Nuno Silva\Documents\UA\ano4\CV\opencv\aula1\WebApplication1\WebApplication1\App_Data\FeedsList.xml");
            XmlNodeList elemList = doc_1.GetElementsByTagName("feed");
            String[] feeds = new String[elemList.Count];
            for (int i = 0; i < elemList.Count; i++)
            {
                feeds[i]=elemList[i].Attributes["url"].Value;
            }
            feed_info.Visible = false;
            //text_area.Visible = true;
            string findString = ToSearch.Text;
            HashSet<XmlNode> toprint = new HashSet<XmlNode>();
            //var toprint = new List<XmlNode>();
            for (int i=0; i<feeds.Length;i++)
            {
                XmlReader reader = XmlReader.Create(feeds[i]);
                XmlDocument doc_aux = new XmlDocument();
                doc_aux.Load(reader);
                reader.Close();
                //XmlNodeList aux = doc_aux.SelectNodes("/rss/channel/item//*[contains(.," + findString+")]");
                XmlNodeList aux = doc_aux.SelectNodes("/rss/channel/item");
                Boolean insert = true;
                foreach(XmlNode mynode in aux)
                {
                    XmlNodeList childs = mynode.ChildNodes;
                    foreach(XmlNode mynode_2 in childs)
                    {
                        if (mynode_2.InnerText.Contains(findString))
                        {
                            foreach(XmlNode test in toprint)
                            {
                                if (test["title"].InnerText.Equals(mynode["title"].InnerText))
                                    insert = false;
                            }
                            if (insert)
                            {
                                toprint.Add(mynode);
                                //text_area.Value += ("\n" + mynode.OuterXml.ToString());
                            }
                        }
                            
                                
                    }
                }

            }
            String innerHtml = "";
            counter_news.Text = toprint.Count.ToString();
            foreach (XmlNode node__ in toprint)
            {
                String node_html = "<div class=\"col-xs-12 col-md-6 col-lg-4\"><div class=\"well\" style=\"min-height: 300px\"> <div class=\"media\"> <div class=\"media-body\"> <h4 class=\"media-heading\"><a style=\" color: #0f1011;text-decoration: none;font-weight: bold;\"target=\"_blank\" href=\"" + node__["link"].InnerText + "\">" + node__["title"].InnerText + "</a></h4> <div class=\"row\"><div class=\"col-md-6\"><small><i class=\"fa fa-tag\"></i> " + "" + "</small></div><div class=\"col-md-6\" style=\"text-align: right\"><small><i class=\"fa fa-calendar - check - o\"></i> " + node__["pubDate"].InnerText + "</small></div></div><p>" + node__["description"].InnerText + "</p></div></div></div></div>";
                innerHtml += node_html;
            }
            news.InnerHtml = innerHtml;
            
        }

        protected void DD_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = DD_Category.SelectedItem.Value;
            XmlDocument doc_1 = new XmlDocument();
            doc_1.Load(@"D:\Nuno Silva\Documents\UA\ano4\CV\opencv\aula1\WebApplication1\WebApplication1\App_Data\FeedsList.xml");
            XmlNodeList elemList = doc_1.GetElementsByTagName("feed");
            String[] feeds = new String[elemList.Count];
            for (int i = 0; i < elemList.Count; i++)
            {
                feeds[i] = elemList[i].Attributes["url"].Value;
            }
            feed_info.Visible = false;
            HashSet<XmlNode> toprint = new HashSet<XmlNode>();
            //var toprint = new List<XmlNode>();
            for (int i = 0; i < feeds.Length; i++)
            {
                XmlReader reader = XmlReader.Create(feeds[i]);
                XmlDocument doc_aux = new XmlDocument();
                doc_aux.Load(reader);
                reader.Close();
                XmlNodeList aux = doc_aux.SelectNodes("/rss/channel/item");
                foreach (XmlNode mynode in aux)
                {
                    try
                    {
                        if (mynode["category"].InnerText.Equals(cat))
                        {
                            toprint.Add(mynode);
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                }

            }
            String innerHtml = "";

            foreach (XmlNode node__ in toprint)
            {
                String node_html = "<div class=\"col-xs-12 col-md-6 col-lg-4\"><div class=\"well\" style=\"min-height: 300px\"> <div class=\"media\"> <div class=\"media-body\"> <h4 class=\"media-heading\"><a style=\" color: #0f1011;text-decoration: none;font-weight: bold;\" target=\"_blank\" href=\"" + node__["link"].InnerText + "\">" + node__["title"].InnerText + "</a></h4> <div class=\"row\"><div class=\"col-md-6\"><small><i class=\"fa fa-tag\"></i> " + node__["category"].InnerText + "</small></div><div class=\"col-md-6\" style=\"text-align: right\"><small><i class=\"fa fa-calendar - check - o\"></i> " + node__["pubDate"].InnerText + "</small></div></div><p>" + node__["description"].InnerText + "</p></div></div></div></div>";
                innerHtml += node_html;
            }
            news.InnerHtml = innerHtml;
        }

    }
}