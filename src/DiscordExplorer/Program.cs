using Sentry;
using System;
using System.Windows.Forms;

namespace DiscordExplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (SentrySdk.Init("https://e32d14bd656a4aa58b67e8902f5b60ba@o428565.ingest.sentry.io/5374124"))
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DiscordExplorerWindow());
            }
        }
    }
}
