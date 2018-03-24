using System;
using System.Collections;
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

namespace SortApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //print original array
            RecordArray originalArray = new RecordArray();
            originalArray.GenExampleNumbers();
            LVBefore.ItemsSource = originalArray.Recs;
        }

        private void CBSortTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //clear sorted array field
            LVAfter.ItemsSource = null;
                       
            int cbItem = (sender as ComboBox).SelectedIndex;
            if (cbItem > -1)
            {
                dynamic sortType = 0;
                switch (cbItem)
                {
                    //select sorting method
                    case 0:
                        {
                            sortType = new BubbleSort();
                        }
                        break;
                    case 1:
                        {
                            sortType = new SelectionSort();
                        }
                        break;
                    case 2:
                        {
                            sortType = new QuickSort();
                        }
                        break;
                    case 3:
                        {
                            sortType = new CountOfComparisons();
                        }
                        break;
                    case 4:
                        {
                            sortType = new ShellSort();
                        }
                        break;
                    case 5:
                        {
                            sortType = new ShakerSort();
                        }
                        break;
                    case 6:
                        {
                            sortType = new InsertionSort();
                        }
                        break;
                }
                //sort
                sortType.GenExampleNumbers();
                sortType.Sort();
                LVAfter.ItemsSource = sortType.Recs;
            }
        }
    }
}