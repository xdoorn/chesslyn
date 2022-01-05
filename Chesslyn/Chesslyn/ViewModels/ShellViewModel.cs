/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System.Collections.ObjectModel;

// Chesslyn
using Chesslyn.Application.Dialogs.Interfaces;
using Chesslyn.Application.Models;


namespace Chesslyn.ViewModels
{
  public class ShellViewModel : ModelBase
  {
    public ShellViewModel(IDialogHosting i_dialogHosting)
    {
      DialogHosting = i_dialogHosting;
    }


    public IDialogHosting DialogHosting 
    { 
      get => GetProperty<IDialogHosting>();
      set => SetProperty(value);
    }
  }
}