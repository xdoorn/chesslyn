/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.Linq;
using System.Windows;

// Prism
using Prism.Services.Dialogs;


namespace Chesslyn.Application.Dialogs.Models
{
  public static class DialogServiceExtensions
  {
    #region Public

    public static bool ShowOkInformationDialog(this IDialogService i_dialogService, string i_message, string i_caption = "Chesslyn")
    {
      return ProcessShowMessageBoxDialog(i_dialogService, i_message, MessageBoxButton.OK, MessageBoxImage.Information, i_caption) == true;
    }


    public static bool ShowYesNoQuestionDialog(this IDialogService i_dialogService, string i_message, string i_caption = "Chesslyn")
    {
      return ProcessShowMessageBoxDialog(i_dialogService, i_message, MessageBoxButton.YesNo, MessageBoxImage.Question, i_caption) == true;
    }


    public static bool ShowOpenFileDialog(this IDialogService i_dialogService, out string o_fileName, string i_title = "Chesslyn", string i_filter = "", string i_initialDirectory = "")
    {
      return ProcessShowOpenFileDialog(i_dialogService, out o_fileName, i_title, i_filter, i_initialDirectory);
    }

    #endregion

    #region Private


    private static bool? ProcessShowMessageBoxDialog(IDialogService i_dialogService, string i_message, MessageBoxButton i_messageBoxButton, MessageBoxImage i_messageBoxImage, string i_caption)
    {
      var dialogParameters = new DialogParameters();
      dialogParameters.Add("Message", i_message);
      dialogParameters.Add("MessageBoxButton", i_messageBoxButton);
      dialogParameters.Add("MessageBoxImage", i_messageBoxImage);
      dialogParameters.Add("Caption", i_caption);

      bool? dialogResult = null;
      Action<IDialogResult> completeAction = (result) =>
      {
        ButtonResult[] okOrYesButtonResults = { ButtonResult.OK, ButtonResult.Yes };
        ButtonResult[] cancelOrNoButtonResults = { ButtonResult.Cancel, ButtonResult.No };

        if (okOrYesButtonResults.Contains(result.Result))
        {
          dialogResult = true;
        }
        else if (cancelOrNoButtonResults.Contains(result.Result))
        {
          dialogResult = false;
        } // Else = null
      };

      i_dialogService.ShowDialog(DialogNames.MessageBoxDialog, dialogParameters, completeAction);
      return dialogResult;
    }

    private static bool ProcessShowOpenFileDialog(this IDialogService i_dialogService, out string o_fileName, string i_title, string i_filter, string i_initialDirectory)
    {
      o_fileName = string.Empty;

      var dialogParameters = new DialogParameters();
      dialogParameters.Add("Title", i_title);
      dialogParameters.Add("Filter", i_filter);
      dialogParameters.Add("InitialDirectory", i_initialDirectory);

      bool result = false;
      string fileName = string.Empty;
      Action<IDialogResult> completeAction = (dialogResult) =>
      {
        dialogResult.Parameters.TryGetValue("FileName", out fileName);

        ButtonResult[] okOrYesButtonResults = { ButtonResult.OK, ButtonResult.Yes };
        if (okOrYesButtonResults.Contains(dialogResult.Result))
        {
          result = true;
        }
      };

      i_dialogService.ShowDialog(DialogNames.OpenFileDialog, dialogParameters, completeAction);

      if (fileName != null)
      {
        o_fileName = fileName;
      }

      return result;
    }

    #endregion
  }
}