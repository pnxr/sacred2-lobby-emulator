using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace S2Lobby
{
    public sealed class Config
    {
        private static readonly Lazy<Config> lazy = new Lazy<Config>(() => new Config());
        private static Dictionary<string, string> customConfig = new Dictionary<string, string>();

        public static Config Instance
        {
            get { return lazy.Value; }
        }

        private void ParseNode(XmlNode node, string xmlPath) {
            string key = node.Attributes["key"]?.InnerText;
            string value = node.Attributes["value"]?.InnerText;
            if (key != null && value != null)
            {
                customConfig.Add(xmlPath + '/'+ key , value);
            }
            else
            {
                if (node.HasChildNodes)
                {
                    ParseSection(node.ChildNodes, xmlPath + (xmlPath.Length > 0 ? "/" : "") + node.Name);
                }
            }
        }

        private void ParseSection(XmlNodeList section, string xmlPath = "") {
            foreach (XmlNode node in section)
            {
                ParseNode(node, xmlPath);
            }
        }


        private Config()
        {
            try {
                if(File.Exists(Constants.ConfigFileName)) {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Constants.ConfigFileName);
                    ParseSection(doc.DocumentElement.ChildNodes);
                }
                else if (!(File.Exists(Constants.ConfigFileNameDefault))) {
                    Logger.Log("Error: No configuration file");
                    System.Environment.Exit(1);
                }
            } catch(System.Exception e) {
                Logger.Log("Invalid config file '"+Constants.ConfigFileName+"'- aborting!");
                Logger.Log("Error was: "+e.Message);
                System.Environment.Exit(1);
            }
        }

        private string _Get(string key) {
            if(customConfig.ContainsKey(key)) {
                return customConfig[key];
            }
            int splitPos = key.LastIndexOf('/'); 
            if(splitPos != -1) {
                try {
                    string path = "settings/" + key.Substring(0, splitPos);
                    string name = key.Substring(splitPos + 1);
                    return ((NameValueCollection)ConfigurationManager.GetSection(path))[name];
                } catch(System.Exception e) {
                    Logger.Log("Tried to fetch invalid key '"+key+"'");
                    Logger.Log("Error was: " + e.Message);
                    return null;
                }
            }
            Logger.Log("Tried to fetch '" +key+"' but could not find it");
            return null;
        }

        public static string Get(string key) => Config.Instance._Get(key);
        public static UInt32 GetInt(string key) => UInt32.Parse(Get(key));
    }
}