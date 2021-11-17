/************************************\
 *                                   *
 *  Chesslyn 2021, Xander van Doorn  *
 *                                   *
\************************************/

// .NET
using System.Windows;

// Prism
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

// Chesslyn
using Chesslyn.Views;
using Chesslyn.Application.Interfaces;
using Chesslyn.Application.Commands;


namespace Chesslyn
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : PrismApplication
  {
    protected override Window CreateShell()
    {
      return Container.Resolve<Shell>();
    }


    protected override void RegisterTypes(IContainerRegistry i_containerRegistry)
    {
      i_containerRegistry.Register<IApplicationCommands, ApplicationCommands>();
    }


    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new ConfigurationModuleCatalog();
    }
  }
}
