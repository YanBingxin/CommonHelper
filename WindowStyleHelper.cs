using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace NV.DRF.Controls
{
    /// <summary>
    /// ID:风格辅助类
    /// Describe:辅助风格控制
    /// Author:ybx
    /// Date:2017-01-10 11:47:44
    /// </summary>
    public class WindowStyleHelper
    {

        /// <summary>
        /// 是否父类窗口支持拖到
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetCanDragMove(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanDragMoveProperty);
        }

        public static void SetCanDragMove(DependencyObject obj, bool value)
        {
            obj.SetValue(CanDragMoveProperty, value);
        }

        /// <summary>
        /// 是否启用关闭窗口功能
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetIsCloseActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCloseActiveProperty);
        }

        public static void SetIsCloseActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCloseActiveProperty, value);
        }

        public static readonly DependencyProperty IsCloseActiveProperty =
            DependencyProperty.RegisterAttached("IsCloseActive", typeof(bool), typeof(WindowStyleHelper), new PropertyMetadata(false, IsCloseActiveChanged));

        public static readonly DependencyProperty CanDragMoveProperty =
            DependencyProperty.RegisterAttached("CanDragMove", typeof(bool), typeof(WindowStyleHelper), new PropertyMetadata(false, CanDragMoveChanged));

        private static void CanDragMoveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement ele = d as FrameworkElement;
            if (e.NewValue != e.OldValue)
            {
                ele.MouseDown -= Drag;
                if ((bool)e.NewValue)
                    ele.MouseDown += Drag;
            }
        }

        private static void IsCloseActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement ele = d as FrameworkElement;
            if (e.NewValue != e.OldValue)
            {
                ele.MouseLeftButtonUp -= Close;
                if ((bool)e.NewValue)
                    ele.MouseLeftButtonUp += Close;
            }
        }

        /// <summary>
        /// 窗口拖动实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement ele = sender as FrameworkElement;
            var parent = VisualTreeHelper.GetParent(ele);
            while (parent != null && !(parent is Window))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent != null && parent is Window)
                (parent as Window).DragMove();
        }
        /// <summary>
        /// 窗口关闭功能实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Close(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement ele = sender as FrameworkElement;
            var parent = VisualTreeHelper.GetParent(ele);
            while (parent != null && !(parent is Window))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent != null && parent is Window)
                (parent as Window).Close();
        }

    }
}
