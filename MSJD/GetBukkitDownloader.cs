using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Windows.Forms;



namespace MSJD
{
    class GetBukkitDownloader
    {

        string project;
        string version;
        MainForm form;
        public GetBukkitDownloader(string project, string version, MainForm form)
        {
            this.project = project;
            this.version = version;
            this.form = form;
        }

        public void downloadSpigot(string path)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                this.form.isDownloading = true;
                wc.DownloadFileAsync(
                    new System.Uri(String.Format("https://cdn.getbukkit.org/spigot/spigot-{0}.jar", version)),
                    path);
                wc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            }


        }

        void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (this.form.getProgressValue() == 100)
            {
                MessageBox.Show("Download Finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.form.changeProgressValue(0);
                this.form.isDownloading = false;
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.form.changeProgressValue(e.ProgressPercentage);
        }
    }
}

