using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
namespace MSJD
{
    class PaperMCDownloader
    {

        string project;
        string version;
        string build;
        MainForm form;

        public PaperMCDownloader(string project, string version, string build, MainForm form)
        {
            this.project = project;
            this.version = version;
            this.build = build;
            this.form = form;
        }

        public void downloadPaper(string path)
        {
            string downloadString = String.Format("https://papermc.io/api/v1/paper/{0}/{1}/download",version,build);
            using (WebClient wc=  new WebClient())
            {
                Console.WriteLine("Start Downloading");
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                this.form.isDownloading = true;
                wc.DownloadFileAsync(
                    new System.Uri(downloadString),
                    path);
                wc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wc_DownloadFileCompleted);

            }
            Console.WriteLine("Download Finished");
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.form.changeProgressValue(e.ProgressPercentage);
        }

        void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (this.form.getProgressValue() == 100)
            {
                MessageBox.Show("Download Finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.form.changeProgressValue(0);
            }
        }

    }
}
