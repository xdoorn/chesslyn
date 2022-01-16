/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

// Prism
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

// Chesslyn
using Chesslyn.Application.ViewModels;
using Chesslyn.Application.Dialogs.Models;
using System.Collections.Generic;
using System.IO;

namespace Chesslyn.App.Database.ViewModels
{
  public class DatabaseAppViewModel : AppViewModelBase
  {
    public DatabaseAppViewModel(IRegionManager i_regionManager) : base(i_regionManager)
    {
    }
  }
}
