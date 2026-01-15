using System;
using System.Collections.Generic;
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

namespace SfTimepicker_Like_Sample
{
    /// <summary>
    /// Interaction logic for CustomTimePicker.xaml
    /// </summary>
    public partial class CustomTimePicker : UserControl
    {
        #region Booleans

        public bool canSelect = true;
        public bool singleSelect = true;
        public bool largeMin = false;
        public bool singleSelectionLength = false;
        private bool hourSelect = true;

        #endregion

        public CustomTimePicker()
        {
            InitializeComponent();
            txBoxs.MaxLength = 5;
            txBoxs.SelectionChanged += TxBoxs_SelectionChanged;
            txBoxs.PreviewKeyDown += TxBoxs_PreviewKeyDown;


            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0); ;

            TextBox txt = new TextBox();
            txt.Text = time.ToShortTimeString();

            if (txt.Text[1] == ':')
            {
                txBoxs.Text = "0" + time.ToShortTimeString();
            }
            else
            {
                txBoxs.Text = time.ToShortTimeString();
            }

            string admin = "AM";
            string admin1 = "PM";

            if (txBoxs.Text.Contains(admin) || txBoxs.Text.Contains(admin1))
            {
                txBoxs.Text = txBoxs.Text.Remove(6, 2);
            }

        }

        private void TxBoxs_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                if ((sender as TextBox).SelectionStart == 0 && txBoxs.SelectionLength == 2)
                {
                    txBoxs.SelectionStart = txBoxs.SelectionStart + 3;
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (e.Key == Key.Left)
                {
                    if ((sender as TextBox).SelectionStart == 3 && txBoxs.SelectionLength == 2)
                    {
                        txBoxs.SelectionStart = txBoxs.SelectionStart - 3;
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }

            if (e.Key == Key.Back)
            {
                e.Handled = true;
            }
        }

        private void TxBoxs_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (txBoxs.SelectionStart > 2)
            {
                hourSelect = true;
            }
            else if (txBoxs.SelectionStart < 3 || txBoxs.SelectionStart >= 6)
            {
                canSelect = true;
            }

            if (canSelect)
            {
                if (txBoxs.SelectionStart == 3 && txBoxs.SelectionLength != 2)
                {
                    txBoxs.SelectionLength = 2;
                }
                else
                  if (txBoxs.SelectionStart == 4 && txBoxs.SelectionLength != 2)
                {
                    txBoxs.SelectionStart = 3;
                    txBoxs.SelectionLength = 2;
                }
                else
                  if (txBoxs.SelectionStart == 5 && txBoxs.SelectionLength != 2)
                {
                    txBoxs.SelectionStart = 3;
                    txBoxs.SelectionLength = 2;
                }
            }
            if (hourSelect)
            {
                if (txBoxs.SelectionStart == 0 && txBoxs.SelectionLength != 2)
                {
                    txBoxs.SelectionLength = 2;
                }
                else
                  if (txBoxs.SelectionStart == 2 && txBoxs.SelectionLength != 2)
                {
                    txBoxs.SelectionStart = 0;
                    txBoxs.SelectionLength = 2;
                }
                else
                  if (txBoxs.SelectionStart == 1 && txBoxs.SelectionLength != 2)
                {
                    txBoxs.SelectionStart = 0;
                    txBoxs.SelectionLength = 2;
                }
            }


            if (txBoxs.SelectionStart == 2)
            {
                txBoxs.SelectionStart++;
            }
            else
                if (txBoxs.SelectionStart == 5)
            {
                txBoxs.SelectionStart = 0;
            }

        }

        private void upArrow_Click(object sender, RoutedEventArgs e)
        {
            if (txBoxs.SelectionStart == 3 && txBoxs.SelectionLength == 2)
            {
                if ((sender as Button).Name == "upArrow")
                {
                    int txt = Int32.Parse(txBoxs.SelectedText);
                    if (txt < 59)
                    {
                        txt++;
                    }
                    else
                    {
                        txt = 00;
                    }
                    txBoxs.SelectedText = txt.ToString("00");
                }
                else
                if ((sender as Button).Name == "downArrow")
                {
                    int txt = Int32.Parse(txBoxs.SelectedText);
                    if (txt > 0)
                    {
                        txt--;
                    }
                    else
                    {
                        if (txt == 0)
                        {
                            txt = 59;
                        }
                        else
                            txt = 00;
                    }
                    txBoxs.SelectedText = txt.ToString("00");
                }

                txBoxs.Focus();
                txBoxs.SelectedText = txBoxs.SelectedText;
            }
            else if (txBoxs.SelectionStart == 0 && txBoxs.SelectionLength == 2)
            {
                if ((sender as Button).Name == "upArrow")
                {
                    int txt = Int32.Parse(txBoxs.SelectedText);
                    if (txt <= 22)
                    {
                        txt++;
                    }
                    else
                    {
                        if (txt != 0)
                            txt = 0;
                        else
                            txt = 1;
                    }
                    txBoxs.SelectedText = txt.ToString("00");
                }
                else
                if ((sender as Button).Name == "downArrow")
                {
                    int txt = Int32.Parse(txBoxs.SelectedText);
                    if (txt >= 1)
                    {
                        txt--;
                    }
                    else
                    {
                        if (txt == 0)
                        {
                            txt = 23;
                        }

                    }
                    txBoxs.SelectedText = txt.ToString("00");
                }

                txBoxs.Focus();
                txBoxs.SelectedText = txBoxs.SelectedText;
            }

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key != Key.Back)
                {
                    e.Handled = true;
                }
            }

            #region DateValidation

            #region Minute validation
            if (e.Key > Key.D0 || e.Key < Key.D9)
            {
                int keyValue = KeyInterop.VirtualKeyFromKey(e.Key);
                canSelect = false;
                if (txBoxs.SelectionStart >= 3 && keyValue >= 48 && keyValue <= 57)
                {
                    if ((keyValue - 48) >= 6 && txBoxs.SelectionStart == 3)
                    {
                        singleSelectionLength = true;
                        txBoxs.SelectedText = "0" + (keyValue - 48).ToString();
                        txBoxs.SelectionLength = 0;
                        txBoxs.SelectionStart = txBoxs.SelectionStart + 2;
                        e.Handled = true;
                    }

                    else
                    {
                        if (keyValue >= 48 && keyValue <= 57 && txBoxs.SelectionStart == 4)
                        {
                            txBoxs.SelectionLength = 1;
                            txBoxs.SelectedText = (keyValue - 48).ToString();
                            singleSelectionLength = true;
                            txBoxs.SelectionLength = 0;
                            txBoxs.SelectionStart++;
                            e.Handled = true;
                        }
                        else
                            if ((keyValue - 48) <= 6 && txBoxs.SelectionStart == 3)
                        {

                            txBoxs.SelectionLength = 1;
                            txBoxs.SelectedText = (keyValue - 48).ToString();
                            txBoxs.SelectionLength = 0;
                            txBoxs.SelectionStart++;
                            e.Handled = true;
                        }

                    }

                }
                #endregion

                #region Hour validation

                else
                 if (txBoxs.SelectionStart < 3)
                {
                    hourSelect = false;

                    if (keyValue >= 48 && keyValue <= 57 && txBoxs.SelectionStart == 0)
                    {
                        if ((keyValue - 48) <= 2)
                        {
                            txBoxs.SelectionLength = 1;
                            txBoxs.SelectedText = (keyValue - 48).ToString();
                            txBoxs.SelectionLength = 0;
                            e.Handled = true;
                            txBoxs.SelectionStart++;

                        }
                        else
                        {
                            if ((keyValue - 48) >= 3)
                            {
                                //txBoxs.SelectionLength = 1;
                                txBoxs.SelectedText = "0" + (keyValue - 48).ToString();
                                txBoxs.SelectionLength = 0;
                                txBoxs.SelectionStart = txBoxs.SelectionStart + 2;
                                e.Handled = true;
                            }
                        }
                    }
                    else
                    {
                        if (((txBoxs.Text[0] == '1' || txBoxs.Text[0] == '0') || (txBoxs.Text[0] == '2' && (keyValue - 48) <= 3)) && txBoxs.SelectionStart == 1)
                        {

                            txBoxs.SelectionLength = 1;
                            txBoxs.SelectedText = (keyValue - 48).ToString();
                            e.Handled = true;
                            txBoxs.SelectionLength = 0;
                            txBoxs.SelectionStart++;
                            singleSelectionLength = true;
                            e.Handled = true;
                        }
                        else
                        {
                            if (txBoxs.Text[0] == '2' && txBoxs.SelectionStart == 1)
                            {

                                txBoxs.SelectionLength = 2;
                                txBoxs.SelectionStart--;

                                txBoxs.SelectedText = "0" + (keyValue - 48).ToString();
                                e.Handled = true;
                                txBoxs.SelectionLength = 0;
                                txBoxs.SelectionStart = txBoxs.SelectionStart + 2;
                                singleSelectionLength = true;
                                e.Handled = true;
                            }
                        }

                        canSelect = false;
                        singleSelect = true;
                        singleSelectionLength = false;
                    }
                }

                #endregion 
            }
            #endregion

        }
        
    }
}
