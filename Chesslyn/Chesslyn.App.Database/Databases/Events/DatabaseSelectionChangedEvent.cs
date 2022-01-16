/**************************************\
 *                                     *
 *  Chesslyn © 2022, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Prism
using Prism.Events;

// Chesslyn
using Chesslyn.App.Database.Databases.ViewModels;


namespace Chesslyn.App.Database.Databases.Events
{
  public class DatabaseSelectionChangedEvent : PubSubEvent<DatabaseItemViewModel>
  {
  }
}