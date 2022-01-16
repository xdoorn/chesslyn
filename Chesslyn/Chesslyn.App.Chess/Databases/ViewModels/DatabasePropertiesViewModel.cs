/**************************************\
 *                                     *
 *  Chesslyn © 2022, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.IO;

// Chesslyn
using Chesslyn.Application.ViewModels;


namespace Chesslyn.App.Database.Databases.ViewModels
{
  public class DatabasePropertiesViewModel : ViewModelBase
  {
    public DatabaseItemViewModel DatabaseItem 
    {
      get => GetProperty<DatabaseItemViewModel>();
      set => SetProperty(value);
    }
  }
}
