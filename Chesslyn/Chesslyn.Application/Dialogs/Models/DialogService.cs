/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Prism
using Prism.Ioc;
using Prism.Services.Dialogs;
using PrismDialogService = Prism.Services.Dialogs.DialogService;

// Chesslyn
using Chesslyn.Application.Models;
using Chesslyn.Application.Dialogs.Interfaces;
using System.Windows;
using Microsoft.Win32;

namespace Chesslyn.Application.Dialogs.Models
{
  public class DialogService : ModelBase, IDialogService, IDialogHosting
  {
    public DialogService(IContainerExtension i_containerExtension)
    {
      m_dialogService = new PrismDialogService(i_containerExtension);
    }


    public void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback)
    {
      IsHosting = true;
      m_dialogService?.Show(name, parameters, callback);
      IsHosting = false;
    }


    public void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName)
    {
      IsHosting = true;
      m_dialogService?.Show(name, parameters, callback, windowName);
      IsHosting = false;
    }


    public void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback)
    {
      ProcessShowDialog(name, parameters, callback, "Chesslyn");
    }


    public void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName)
    {
      ProcessShowDialog(name, parameters, callback, windowName);
    }


    public bool IsHosting
    {
      get => GetProperty<bool>();
      private set => SetProperty(value);
    }


    #region Private

    private void ProcessShowDialog(string i_dialogName, IDialogParameters i_dialogParameters, Action<IDialogResult> i_callback, string i_windowName)
    {
      IsHosting = true;

      if (i_dialogName.Equals(DialogNames.MessageBoxDialog))
      {
        ProcessMessageBoxDialog(i_dialogParameters, i_callback, i_windowName); 
      }
      else if (i_dialogName.Equals(DialogNames.OpenFileDialog))
      {
        ProcessOpenFileDialog(i_dialogParameters, i_callback, i_windowName);
      }
      else
      {
        m_dialogService?.ShowDialog(i_dialogName, i_dialogParameters, i_callback);
      }

      IsHosting = false;
    }


    private void ProcessMessageBoxDialog(IDialogParameters i_dialogParameters, Action<IDialogResult> i_callback, string i_windowName)
    {
      string message = string.Empty;
      var messageBoxButton = MessageBoxButton.OK;
      var messageBoxImage = MessageBoxImage.None;
      string caption = i_windowName;

      i_dialogParameters.TryGetValue("Message", out message);
      i_dialogParameters.TryGetValue("MessageBoxButton", out messageBoxButton);
      i_dialogParameters.TryGetValue("MessageBoxImage", out messageBoxImage);
      i_dialogParameters.TryGetValue("Caption", out caption);

      MessageBoxResult messageBoxResult = MessageBox.Show(message, caption, messageBoxButton, messageBoxImage);
      if (i_callback != null)
      {
        IDialogResult dialogResult = new DialogResult(ButtonResult.None);
        if (messageBoxResult == MessageBoxResult.OK)
        {
          dialogResult = new DialogResult(ButtonResult.OK);
        }
        else if (messageBoxResult == MessageBoxResult.Cancel)
        {
          dialogResult = new DialogResult(ButtonResult.Cancel);
        }
        else if (messageBoxResult == MessageBoxResult.Yes)
        {
          dialogResult = new DialogResult(ButtonResult.Yes);
        }
        else if (messageBoxResult == MessageBoxResult.No)
        {
          dialogResult = new DialogResult(ButtonResult.No);
        }

        i_callback(dialogResult);
      }
    }


    private void ProcessOpenFileDialog(IDialogParameters i_dialogParameters, Action<IDialogResult> i_callback, string i_windowName)
    {
      string title = i_windowName;
      string filter = "All (*.*)|*.*";
      string initialDirectory = string.Empty;

      i_dialogParameters.TryGetValue("Title", out title);
      i_dialogParameters.TryGetValue("Filter", out filter);
      i_dialogParameters.TryGetValue("InitialDirectory", out initialDirectory);

      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = title;
      openFileDialog.Filter = filter;
      openFileDialog.InitialDirectory = initialDirectory;

      bool? result = openFileDialog.ShowDialog();
      if (i_callback != null)
      {
        ButtonResult buttonResult = ButtonResult.None;
        if (result == true)
        {
          buttonResult = ButtonResult.OK;
        }

        DialogParameters dialogParameters = new DialogParameters($"FileName={openFileDialog.FileName}");
        IDialogResult dialogResult = new DialogResult(buttonResult, dialogParameters);
        i_callback.Invoke(dialogResult);
      }
    }


    private readonly PrismDialogService? m_dialogService = null;

    #endregion
  }
}
