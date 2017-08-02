using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows;
using NV.DRF.Controls;
using NV.Infrastructure.UICommon;

namespace NV.DRF.Controls
{

    /// <summary>
    /// ID:窗口提示
    /// Describe:提示窗口
    /// Author:ybx
    /// Date:2017年1月4日11:04:46
    /// </summary>
    public static class CMessageBox
    {
        [SecurityCritical]
        public static MessageBoxResult Show(string messageBoxText)
        {
            MessageWindow win = new MessageWindow(messageBoxText);
            win.btnOK.Visibility = Visibility.Visible;
            win.ShowDialogEx();
            return MessageBoxResult.None;
        }

        [SecurityCritical]
        public static MessageBoxResult Show(string messageBoxText, string caption)
        {
            MessageWindow win = new MessageWindow(messageBoxText);
            win.PTitle = caption;
            win.btnOK.Visibility = Visibility.Visible;
            win.ShowDialogEx();
            return MessageBoxResult.None;
        }

        [SecurityCritical]
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            MessageWindow win = new MessageWindow(messageBoxText);
            win.PTitle = caption;
            switch (Convert.ToInt32(button))
            {
                case 0:
                    win.btnOK.Visibility = Visibility.Visible;
                    break;
                case 1:
                    win.btnOK.Visibility = Visibility.Visible;
                    win.btnCancel.Visibility = Visibility.Visible;
                    break;
                case 3:
                    win.btnYes.Visibility = Visibility.Visible;
                    win.btnNo.Visibility = Visibility.Visible;
                    win.btnCancel.Visibility = Visibility.Visible;
                    break;
                case 4:
                    win.btnYes.Visibility = Visibility.Visible;
                    win.btnNo.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
            win.ShowDialogEx();
            return win.Result;
        }
    }
}
