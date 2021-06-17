using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MSJD
{
    public partial class MainForm : Form
    {

        static string[] ServerTypes = {"Paper","Spigot","Bukkit ( Not Supported )"};
        public bool isDownloading = false;
        public MainForm()
        {
            InitializeComponent();
            foreach (string st in ServerTypes)
            {
                ServerTypeCombo.Items.Add(st);
            }
            addVersionCombo();
            ServerTypeCombo.SelectedIndex = 0;
            VersionCombo.SelectedIndex = 0;
            addPaperBuildCombo();
            BuildCombo.SelectedIndex = 0;
        }

        public void changeProgressValue(int pct)
        {
            downloadProgress.Value = pct;
        }

        public int getProgressValue()
        {
            return downloadProgress.Value;
        }

        void addVersionCombo()
        {
            string paperGetUrl = "https://papermc.io/api/v1/paper";
            string versionText = string.Empty;
            WebRequest request = WebRequest.Create(paperGetUrl);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            versionText = reader.ReadToEnd();
            PaperVersionGet pvg = JsonConvert.DeserializeObject<PaperVersionGet>(versionText);
            foreach (var version in pvg.versions)
            {
                VersionCombo.Items.Add(version);
            }

        }

        void addPaperBuildCombo()
        {
            string paperBuildGetUrl = String.Format("https://papermc.io/api/v1/paper/{0}", VersionCombo.SelectedItem);
            string buildText = string.Empty;
            Console.WriteLine(paperBuildGetUrl);
            WebRequest request = WebRequest.Create(paperBuildGetUrl);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            buildText = reader.ReadToEnd();
            PaperBuildGet pbg = JsonConvert.DeserializeObject<PaperBuildGet>(buildText);
            foreach (var build in pbg.builds.all)
            {
                BuildCombo.Items.Add(build);
            }
        }



        private void ServerTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ServerTypeCombo.Text)
            {
                case "Paper":
                    VersionCombo.Items.Clear();
                    BuildCombo.Items.Clear();
                    addVersionCombo();
                    VersionCombo.SelectedIndex = 0;
                    addPaperBuildCombo();
                    break;
                case "Spigot":
                    addSpigotVersion();
                    break;
                case "Bukkit ( Not Supported )":
                    VersionCombo.Items.Clear();
                    BuildCombo.Items.Clear();
                    break;
                default:
                    break;
            }
            
        }

        void addSpigotVersion()
        {
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var option = new ChromeOptions();
            option.AddArgument("headless");
            
        
            using (IWebDriver driver = new ChromeDriver(service,option))
            {
                
                driver.Url = "https://getbukkit.org/download/spigot";
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                var elements = driver.FindElements(By.CssSelector("div.download-pane"));
                VersionCombo.Items.Clear();
                BuildCombo.Items.Clear();
                foreach (var element in elements)
                {
                    var elem = element.FindElement(By.CssSelector("div")).FindElement(By.CssSelector("div")).FindElement(By.CssSelector("h2"));
                    VersionCombo.Items.Add(elem.Text);
                }
                VersionCombo.SelectedIndex = 0;
            }
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                MessageBox.Show("Downloading!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (ServerTypeCombo.Text == "Paper")
            {
                PaperMCDownloader pmcd = new PaperMCDownloader(ServerTypeCombo.Text.ToLower(), VersionCombo.Text, BuildCombo.Text, this);
                using (var fbd = new SaveFileDialog())
                {
                    fbd.InitialDirectory = @"C:\";
                    fbd.RestoreDirectory = true;
                    fbd.Title = "Select Path For Download";
                    fbd.DefaultExt = "paper.jar";
                    fbd.Filter = "jar files (*.jar)|*.jar|All files (*.*)|*.*";
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                    {
                        var filename = fbd.FileName;
                        if (!filename.EndsWith(".jar"))
                        {
                            filename += ".jar";
                        }
                        Console.WriteLine(filename);
                        pmcd.downloadPaper(filename);
                    }
                    else
                    {
                        return;
                    }
                }  

            }
            else if (ServerTypeCombo.Text == "Spigot")
            {
                GetBukkitDownloader gbd = new GetBukkitDownloader(ServerTypeCombo.Text.ToLower(),VersionCombo.Text,this);
                using (var fbd = new SaveFileDialog())
                {
                    fbd.InitialDirectory = @"C:\";
                    fbd.RestoreDirectory = true;
                    fbd.Title = "Select Path For Download";
                    fbd.DefaultExt = "spigot.jar";
                    fbd.Filter = "jar files (*.jar)|*.jar|All files (*.*)|*.*";
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                    {
                        var filename = fbd.FileName;
                        if (!filename.EndsWith(".jar"))
                        {
                            filename += ".jar";
                        }
                        Console.WriteLine(filename);
                        gbd.downloadSpigot(filename);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (ServerTypeCombo.Text == "Bukkit ( Not Supported )")
            { 
                MessageBox.Show("Can't Download Bukkit", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

            }
        }

        private void BuildCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VersionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ServerTypeCombo.Text == "Paper")
            {
                BuildCombo.Items.Clear();
                addPaperBuildCombo();
                BuildCombo.SelectedIndex = 0;
            }
        }
    }

    class PaperVersionGet
    {
        public string project;
        public string[] versions;
    }

    class PaperBuildGet
    {
        public string project;
        public string version;
        public PaperBuildsGet builds;
    }

    class PaperBuildsGet
    {
        public string latest;
        public string[] all;
    }
}
