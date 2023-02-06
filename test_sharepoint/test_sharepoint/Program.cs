using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace test_sharepoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "test-sd@UF.UA";
            string password = "Daw61907";
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            using (var ctx = new ClientContext("https://yplanet.sharepoint.com/sites/CoExTeam886/Shared%20Documents/"))
            {
                ctx.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                Web web = ctx.Web;
                ctx.Load(web);
                ctx.ExecuteQuery();
                Folder folder = web.GetFolderByServerRelativeUrl("IT-systems/D365M");
                FileCreationInformation newFile = new FileCreationInformation();
                newFile.Content = System.IO.File.ReadAllBytes("C:\\Users\\shcho\\OneDrive\\Рабочий стол\\Работа\\test_file.xlsx");
                newFile.Url = @"test_file.xlsx";
                newFile.Overwrite = true;
                File fileToUpload = folder.Files.Add(newFile);
                ctx.Load(fileToUpload);
                ctx.ExecuteQuery();
                Console.WriteLine("done");
            }
        }
    }
}
