using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Documents;
using System;
using System.Reflection;
using System.Threading.Tasks;
using WinUIEx;

namespace VMsApp
{
    public sealed partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            this.InitializeComponent();
            this.SetWindowSize(550, 300);
            this.ExtendsContentIntoTitleBar = true;
            this.SetIsMinimizable(false);
            this.SetIsResizable(false);
            this.SetIsMaximizable(false);
            this.CenterOnScreen();
            this.SetIsAlwaysOnTop(true);
            //this.BringToFront();
            //WindowHelper.RemoveIcon(this);
            this.AppWindow.TitleBar.PreferredHeightOption = Microsoft.UI.Windowing.TitleBarHeightOption.Collapsed;
            try
            {
                this.AppWindow.SetIcon($"{AppContext.BaseDirectory}/Assets/AppIcons/AppIcon.png");
            }
            catch
            {

            }
            this.Title = "Loading...";

            CompilationText.Text = "Compilation date " + GetBuildDate(Assembly.GetExecutingAssembly());

            Run();
        }

        private static DateTime GetBuildDate(Assembly assembly)
        {
            //var attribute = assembly.GetCustomAttribute<BuildDateAttribute>();
            //return attribute != null ? attribute.DateTime : default(DateTime);
            return DateTime.Now;
        }

        public async void Run()
        {
            await Task.Delay(1000);

            this.Close();
        }
    }
}
