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
  public class DatabaseItemViewModel : ViewModelBase
  {
    public DatabaseItemViewModel(FileInfo i_fileInfo)
    {
      FileInfo = i_fileInfo;
    }


    public FileInfo FileInfo
    {
      get { return GetProperty<FileInfo>(); }
      set 
      { 
        if (SetProperty(value))
        {
          OnPropertyChanged(nameof(DisplayOrFileName));
        }
      }
    }


    public string DisplayName
    { 
      get { return GetProperty<string>(); }
      set
      {
        if (SetProperty(value))
        {
          OnPropertyChanged(nameof(DisplayOrFileName));
        }
      }
    }


    public string DisplayOrFileName
    {
      get { return DisplayName ?? FileInfo.Name; }
    }
  }
}
