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
using Prism.Services.Dialogs;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

// Chesslyn
using Chesslyn.Views;
using Chesslyn.ViewModels;
using Chesslyn.Application.Dialogs.Interfaces;
using ChesslynDialogService = Chesslyn.Application.Dialogs.Models.DialogService;


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
      i_containerRegistry.RegisterManySingleton<ChesslynDialogService>(typeof(IDialogService), typeof(IDialogHosting));
      i_containerRegistry.RegisterDialog<MessageBoxDialog, MessageBoxDialogViewModel>();
    }


    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new ConfigurationModuleCatalog();
    }
  }
}
