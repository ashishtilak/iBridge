using System;
using System.Reflection;
using System.Windows.Forms;

namespace iBridge
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //get hash code of mac id from iSuraksha dll
            string macHashId = iSuraksha.FingerPrint.GetMacHash();

            //this is how dll is written containing key in dll file iKey:
            //CompilerParameters parameters = new CompilerParameters();
            //parameters.GenerateExecutable = false;
            //parameters.OutputAssembly = "iKey.dll";
            //CompilerResults r = CodeDomProvider.CreateProvider("CSharp")
            //        .CompileAssemblyFromSource(parameters, "public class iKey {public static string key="abcdefg";}");

            // retrive the key from dll

            try
            {
                // this will load dll from file
                Assembly ass = Assembly.LoadFrom("iKey.dll");

                // access the class property within the dll
                string strKey = ass.GetType("iKeyGen").GetField("key").GetValue(null).ToString();

                //got the key from dll, now decrypt it
                string decryptedKey = iKoot.KootRoop.Decrypt(strKey);

                if (macHashId == decryptedKey)
                {
                    //
                    // EVERYTHING IS OK.
                    // NOW SHOW LOGIN FORM...
                    //

                    FrmLogin fLogin = new FrmLogin();
                    fLogin.ShowDialog();

                    if (fLogin.LoginStatus)
                        Application.Run(new FrmHome());
                    else
                        Application.Exit();

                }
                else
                {
                    // KEY EXIST IN DLL, BUT IT DOES NOT MATCH WITH HASH CODE

                    MessageBox.Show("Registration dll is invalid. Contact support team");
                    FrmSecurityKey fSecurityKey = new FrmSecurityKey(macHashId);
                    Application.Run(fSecurityKey);

                    if (fSecurityKey.Result == false)
                    {
                        Application.Exit();
                    }
                }
            }
            catch (System.IO.FileNotFoundException exFileNotFound)
            {
                MessageBox.Show("Registration dll missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmSecurityKey fSecurityKey = new FrmSecurityKey(macHashId);
                Application.Run(fSecurityKey);
                if (fSecurityKey.Result == false)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem getting data from Registration dll." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmSecurityKey fSecurityKey = new FrmSecurityKey(macHashId);
                Application.Run(fSecurityKey);
                if (fSecurityKey.Result == false)
                {
                    Application.Exit();
                }
            }
        }
    }
}