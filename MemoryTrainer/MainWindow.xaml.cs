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
using System.Windows.Threading;
using System.IO;
using System.ComponentModel;

namespace MemoryTrainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BitmapImage> images = new List<BitmapImage>();
        List<BitmapImage> imagesToShow = new List<BitmapImage>();
        List<string> words = new List<string>();
        List<string> wordsToShow = new List<string>();
        List<int> numbersToShow = new List<int>();
        Random random = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        int amountToShow;
        int ticks;
        int matches;
        long span;
        BitmapImage image1 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/1.jpg"));
        BitmapImage image2 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/2.jpg"));
        BitmapImage image3 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/3.jpg"));
        BitmapImage image4 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/4.jpg"));
        BitmapImage image5 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/5.jpg"));
        BitmapImage image6 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/6.jpg"));
        BitmapImage image7 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/7.jpg"));
        BitmapImage image8 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/8.jpg"));
        BitmapImage image9 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/9.jpg"));
        BitmapImage image10 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/10.jpg"));
        BitmapImage image11 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/11.jpg"));
        BitmapImage image12 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/12.jpg"));
        BitmapImage image13 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/13.jpg"));
        BitmapImage image14 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/14.jpg"));
        BitmapImage image15 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/15.jpg"));
        BitmapImage image16 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/16.jpg"));
        BitmapImage image17 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/17.jpg"));
        BitmapImage image18 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/18.jpg"));
        BitmapImage image19 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/19.jpg"));
        BitmapImage image20 = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "../../../Images/20.jpg"));
        string word1 = "Яблоко";
        string word2 = "Табурет";
        string word3 = "Автомобиль";
        string word4 = "Гитара";
        string word5 = "Дерево";
        string word6 = "Кокос";
        string word7 = "Кружка";
        string word8 = "Кот";
        string word9 = "Сапог";
        string word10 = "Телевизор";
        string word11 = "Зонт";
        string word12 = "Пылесос";
        string word13 = "Часы";
        string word14 = "Ромашка";
        string word15 = "Молоток";
        string word16 = "Мяч";
        string word17 = "Лампочка";
        string word18 = "Голубь";
        string word19 = "Банан";
        string word20 = "Рубашка";
        public MainWindow()
        {
            InitializeComponent();
            InitializeLists();
            timer.Tick += new EventHandler(TimerTick);
            RadioButton_Pictures.IsChecked = true;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            InitializeLists();
            SetObjectsToShow();
            SetSpeed();
            timer.Start();
            Button_Start.IsEnabled = false;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (RadioButton_Pictures.IsChecked == true)
            {
                if (ticks < amountToShow)
                {
                    ImageBox.Source = imagesToShow.ElementAt(ticks);
                }
                else
                {
                    ImageBox.Source = null;
                    timer.Stop();
                    for (int i = 0; i < amountToShow; i++)
                    {
                        ListBox_ToChoose.Items.Add(wordsToShow.ElementAt(i));
                    }
                    ListBox_ToChoose.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
                    Button_Start.IsEnabled = true;
                }
            }
            else
            {
                if (ticks < amountToShow)
                {
                    TextBlock_Numbers.Text = numbersToShow.ElementAt(ticks).ToString();
                }
                else
                {
                    TextBlock_Numbers.Text = "";
                    timer.Stop();
                    Button_Start.IsEnabled = true;
                    for (int i = 0; i < amountToShow; i++)
                    {
                        ListBox_ToChoose.Items.Add(numbersToShow.ElementAt(i));
                    }
                    ListBox_ToChoose.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
                }
            }
            ticks++;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_ToChoose.SelectedIndex != -1)
            {
                if (ListBox_ToChoose.SelectedIndex != 0 && ListBox_ToChoose.SelectedItem.Equals(ListBox_ToChoose.Items[ListBox_ToChoose.SelectedIndex - 1]))
                {
                    int selectedIndex = ListBox_ToChoose.SelectedIndex;
                    ListBox_ToChoose.SelectedIndex = -1;
                    ListBox_ToCheck.Items.Add(ListBox_ToChoose.Items[selectedIndex - 1]);
                    ListBox_ToChoose.Items.Remove(ListBox_ToChoose.Items[selectedIndex - 1]);
                }
                else
                {
                    ListBox_ToCheck.Items.Add(ListBox_ToChoose.SelectedItem);
                    ListBox_ToChoose.Items.Remove(ListBox_ToChoose.SelectedItem);
                }
                if (ListBox_ToCheck.Items.Count == amountToShow)
                {
                    Button_Check.IsEnabled = true;
                }
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_ToCheck.SelectedIndex != -1)
            {
                ListBox_ToChoose.Items.Add(ListBox_ToCheck.SelectedItem);
                ListBox_ToCheck.Items.Remove(ListBox_ToCheck.SelectedItem);
                ListBox_ToChoose.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
                Button_Check.IsEnabled = false;
            }
        }

        private void Button_Check_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_ToCheck.Items.Count == amountToShow)
            {
                Label_ToChoose.Content = "Верный порядок:";
                for (int i = 0; i < amountToShow; i++)
                {
                    if (RadioButton_Pictures.IsChecked == true)
                    {
                        if (wordsToShow.ElementAt(i) == ListBox_ToCheck.Items[i].ToString())
                        {
                            matches++;
                        }
                        ListBox_ToChoose.Items.Add(wordsToShow.ElementAt(i));
                    }
                    else
                    {
                        if (numbersToShow.ElementAt(i).Equals(ListBox_ToCheck.Items[i]))
                        {
                            matches++;
                        }
                        ListBox_ToChoose.Items.Add(numbersToShow.ElementAt(i));
                    }
                }
                Button_Check.IsEnabled = false;
                if (matches == amountToShow)
                {
                    MessageBox.Show("Всё верно!");
                }
                else
                {
                    MessageBox.Show(String.Format("Неверно!\nСовпадений: {0} из {1}", matches, amountToShow));
                }
                ListBox_ToChoose.Items.Clear();
                ListBox_ToCheck.Items.Clear();
                if (RadioButton_Pictures.IsChecked == true)
                {
                    Label_ToChoose.Content = "Картинки на выбор:";
                }
                else
                {
                    Label_ToChoose.Content = "Числа на выбор:";
                }
            }
        }

        private void RadioButton_Numbers_Checked(object sender, RoutedEventArgs e)
        {
            ComboBox_Digits.Visibility = Visibility.Visible;
            Label_Digits.Visibility = Visibility.Visible;
            TextBlock_Numbers.Visibility = Visibility.Visible;
            Label_Count.Content = "Количество чисел:";
            Label_ToChoose.Content = "Числа на выбор:";
        }

        private void RadioButton_Pictures_Checked(object sender, RoutedEventArgs e)
        {
            ComboBox_Digits.Visibility = Visibility.Hidden;
            Label_Digits.Visibility = Visibility.Hidden;
            Label_Count.Content = "Количество картинок:";
            Label_ToChoose.Content = "Картинки на выбор:";
        }

        private void ListBox_ToChoose_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBox_ToChoose.SelectedIndex != -1)
            {
                if (ListBox_ToChoose.SelectedIndex != 0 && ListBox_ToChoose.SelectedItem.Equals(ListBox_ToChoose.Items[ListBox_ToChoose.SelectedIndex - 1]))
                {
                    int selectedIndex = ListBox_ToChoose.SelectedIndex;
                    ListBox_ToChoose.SelectedIndex = -1;
                    ListBox_ToCheck.Items.Add(ListBox_ToChoose.Items[selectedIndex - 1]);
                    ListBox_ToChoose.Items.Remove(ListBox_ToChoose.Items[selectedIndex - 1]);
                }
                else
                {
                    ListBox_ToCheck.Items.Add(ListBox_ToChoose.SelectedItem);
                    ListBox_ToChoose.Items.Remove(ListBox_ToChoose.SelectedItem);
                }
                if (ListBox_ToCheck.Items.Count == amountToShow)
                {
                    Button_Check.IsEnabled = true;
                }
            }
        }

        private void ListBox_ToCheck_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBox_ToCheck.SelectedIndex != -1)
            {
                ListBox_ToChoose.Items.Add(ListBox_ToCheck.SelectedItem);
                ListBox_ToCheck.Items.Remove(ListBox_ToCheck.SelectedItem);
                ListBox_ToChoose.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
                Button_Check.IsEnabled = false;
            }
        }

        private void ListBox_ToChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox_ToChoose.SelectedIndex != -1)
            {
                Button_Add.IsEnabled = true;
            }
            else
            {
                Button_Add.IsEnabled = false;
            }
        }

        private void ListBox_ToCheck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox_ToCheck.SelectedIndex != -1)
            {
                Button_Delete.IsEnabled = true;
            }
            else
            {
                Button_Delete.IsEnabled = false;
            }
        }

        private void InitializeLists()
        {
            images.Clear();
            images.Add(image1);
            images.Add(image2);
            images.Add(image3);
            images.Add(image4);
            images.Add(image5);
            images.Add(image6);
            images.Add(image7);
            images.Add(image8);
            images.Add(image9);
            images.Add(image10);
            images.Add(image11);
            images.Add(image12);
            images.Add(image13);
            images.Add(image14);
            images.Add(image15);
            images.Add(image16);
            images.Add(image17);
            images.Add(image18);
            images.Add(image19);
            images.Add(image20);

            words.Clear();
            words.Add(word1);
            words.Add(word2);
            words.Add(word3);
            words.Add(word4);
            words.Add(word5);
            words.Add(word6);
            words.Add(word7);
            words.Add(word8);
            words.Add(word9);
            words.Add(word10);
            words.Add(word11);
            words.Add(word12);
            words.Add(word13);
            words.Add(word14);
            words.Add(word15);
            words.Add(word16);
            words.Add(word17);
            words.Add(word18);
            words.Add(word19);
            words.Add(word20);
        }

        private void Reset()
        {
            ticks = 0;
            matches = 0;
            imagesToShow.Clear();
            wordsToShow.Clear();
            numbersToShow.Clear();
            ListBox_ToChoose.Items.Clear();
            ListBox_ToCheck.Items.Clear();
        }

        private void SetObjectsToShow()
        {
            amountToShow = ComboBox_Count.SelectedIndex + 1;
            int previousIndex = 0;
            for (int i = 0; i < amountToShow; i++)
            {
                if (RadioButton_Pictures.IsChecked == true)
                {
                    int index = random.Next(images.Count);
                    imagesToShow.Add(images.ElementAt(index));
                    images.RemoveAt(index);
                    wordsToShow.Add(words.ElementAt(index));
                    words.RemoveAt(index);
                }
                else
                {
                    int index = 0;
                    if (ComboBox_Digits.SelectedIndex == 0)
                    {
                        index = random.Next(10);
                        while (index == previousIndex)
                        {
                            index = random.Next(10);
                        }
                    }
                    if (ComboBox_Digits.SelectedIndex == 1)
                    {
                        index = random.Next(10, 99);
                        while (index == previousIndex)
                        {
                            index = random.Next(10, 99);
                        }
                    }
                    if (ComboBox_Digits.SelectedIndex == 2)
                    {
                        index = random.Next(100, 999);
                        while (index == previousIndex)
                        {
                            index = random.Next(100, 999);
                        }
                    }
                    previousIndex = index;
                    numbersToShow.Add(index);
                }
            }
        }

        private void SetSpeed()
        {
            switch (ComboBox_Speed.SelectedIndex)
            {
                case 0:
                    span = 17500000;
                    break;
                case 1:
                    span = 10000000;
                    break;
                case 2:
                    span = 5000000;
                    break;
                case 3:
                    span = 3000000;
                    break;
                default:
                    break;
            }
            timer.Interval = new TimeSpan(span);
        }
    }
}
