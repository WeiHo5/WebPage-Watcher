﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebPageWatcher.UI
{
    /// <summary>
    /// Dialog.xaml 的交互逻辑
    /// </summary>
    public partial class Dialog : UserControl
    {
        public Dialog()
        {
            InitializeComponent();
        }
        public async Task ShowErrorAsync(string message, string title = "错误")
        {
            btnOk.Visibility = Visibility.Visible;
            btnYes.Visibility = Visibility.Collapsed;
            btnNo.Visibility = Visibility.Collapsed;

            iconError.Visibility = Visibility.Visible;
            iconQuestion.Visibility = Visibility.Collapsed;

            tbkDialogMessage.Text = message;
            tbkDialogTitle.Text = title;
            await dialog.ShowDialog(dialog.DialogContent);
        }
        public async Task<bool> ShowYesNoAsync(string message, string title)
        {
            btnOk.Visibility = Visibility.Collapsed;
            btnYes.Visibility = Visibility.Visible;
            btnNo.Visibility = Visibility.Visible;

            iconError.Visibility = Visibility.Collapsed;
            iconQuestion.Visibility = Visibility.Visible;

            tbkDialogMessage.Text = message;
            tbkDialogTitle.Text = title;
            await dialog.ShowDialog(dialog.DialogContent);
            return result;
        }
        bool result;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sender == btnOk)
            {
            }
            else if (sender == btnYes)
            {
                result = true;
            }
            else if (sender == btnNo)
            {
                result = false;
            }

            dialog.CurrentSession.Close();
        }
    }


    public class ValueMinusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value - double.Parse(parameter as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
