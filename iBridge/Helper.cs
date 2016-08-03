using System;
using System.Xml;
using System.Data;

namespace iBridge
{
    public static class Globals
    {
        public static string ConnectionString = "";
        public static string GUserId = "";
        public static string GUserName = "";
    }

    public class Helper
    {
        public static string GetConnectionString()
        {
            string result = string.Empty;

            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(
                    System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
                    + "\\iBridge.config");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }

            XmlNode node = xmlDoc.SelectSingleNode("configuration/userSettings/iBridge.Properties.Settings/setting[@name='cnStr']/value");
            if (node != null)
            {
                string str = node.InnerText;

                //check if something is there in the node
                if (str != string.Empty)
                {
                    //connection string exist...
                }

                string[] conn = str.Split(';');

                string server = conn[0].Substring(7, conn[0].Length - 7).Trim();
                string port = conn[1].Substring(5, conn[1].Length - 5).Trim();
                string userId = conn[2].Substring(7, conn[2].Length - 7).Trim();
                string password = conn[3].Substring(9, conn[3].Length - 9).Trim();

                try
                {
                    password = iKoot.KootRoop.Decrypt(password);
                }
                catch (Exception exP)
                {
                    throw exP;
                }

                str = "server= " + server + ";" +
                        "port= " + port + ";" +
                        "userid= " + userId + ";" +
                        "password= " + password + ";" +
                        "persistsecurityinfo=True;database=iBridge;allowuservariables=True";
                Globals.ConnectionString = str;
            }

            return result;
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            return ds;
        }

        /// <summary>
        /// Anand Acharya 02/08/2016
        /// used for prevent multiple form open in mdi environment
        /// </summary>
        /// <param name="formType">Type formType</param>
        /// <returns>boolen if already opened returns true else false</returns>
        public static bool IsFrmAlreadyOpen(Type formType)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {

                if (f.GetType() == formType)
                {

                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized;
                    isOpen = true;
                }

            }
            return isOpen;
        }

    }
}