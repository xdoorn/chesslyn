/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System.Globalization;
using System.Threading;
using System.Windows;

// Prism
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

// Chesslyn
using Chesslyn.Views;


namespace Chesslyn
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : PrismApplication
  {
    public App()
    {
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
    }

    protected override Window CreateShell()
    {
      return Container.Resolve<Shell>();
    }


    protected override void RegisterTypes(IContainerRegistry i_containerRegistry)
    {
    }


    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new ConfigurationModuleCatalog();
    }
  }
}
