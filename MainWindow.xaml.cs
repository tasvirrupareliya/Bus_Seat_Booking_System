using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Assignment_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isSeatExistforBook = false;
        List<Seat> seatdata = new List<Seat>(25);

        private void InitializeSeat(List<Seat> seatdata)
        {
            for (int seat = 1; seat <= 25; seat++)
            {
                string nameofSeat = seat.ToString();
                seatdata.Add(new Seat()
                {
                    nameofSeat = nameofSeat,
                    isSelected = false,
                    isOccupied = false
                });
            }
        }

        public MainWindow()
        {            
            InitializeComponent();
            if (ReadData() != null)
            {
                seatdata = ReadData();
                for (int i = 0; i < seatdata.Count; i++)
                {
                    if (seatdata[i].isOccupied)
                    {
                        colorchange(seatdata[i], Brushes.OrangeRed, seatdata[i].nameofConsumer);
                    }
                }
                printList();
            }
            InitializeSeat(seatdata);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Customer_name.Text == string.Empty)
            {
                errormsg.Content = "Please Enter Your Name";
            }
            else if (isSeatExistforBook == false)
            {
                errormsg.Content = "Please Select available seats to book.";
            }
            else
            {
                foreach (var item in seatdata)
                {
                    if (item.isSelected == true)
                    {
                        item.isOccupied = true;
                        item.nameofConsumer = Customer_name.Text;
                        colorchange(item, Brushes.OrangeRed, item.nameofConsumer);
                        item.isSelected = false;
                        isSeatExistforBook = false;
                        errormsg.Content = string.Empty;
                    }
                }
                printList();
                allseatbooked();
            }
        }

        private void allseatbooked()
        {
            var IsAllSeatBooked = true;
            for (int i = 0; i < 25; i++)
            {
                if (!seatdata[i].isOccupied)
                {
                    IsAllSeatBooked = false;
                    break;
                }
            }

            if (IsAllSeatBooked)
            {
                errormsg.Content = "All Seat Are  Booked";
            }
            else
            {
                errormsg.Content = "";
            }
        }

        private void printList()
        {
            string finaldisplayData = "";
            finaldisplayData = "List of Seats : \n";
            foreach (var item in seatdata)
            {
                if (item.isOccupied == true)
                {
                    finaldisplayData += string.Format("{0}Customer Name |-> {1}{0}Seat No |-> {2}{0}",
                    Environment.NewLine, item.nameofConsumer, item.nameofSeat);
                }
            }
            textBox.Text = finaldisplayData;
        }
        private void colorchange(Seat item, Brush color, string content)
        {
            switch (item.nameofSeat)
            {
                case "1":
                    seatcontent1.Background = color;
                    seatcontent1.Content = content;
                    break;
                case "2":
                    seatcontent2.Background = color;
                    seatcontent2.Content = content;
                    break;
                case "3":
                    seatcontent3.Background = color;
                    seatcontent3.Content = content;
                    break;
                case "4":
                    seatcontent4.Background = color;
                    seatcontent4.Content = content;
                    break;
                case "5":
                    seatcontent5.Background = color;
                    seatcontent5.Content = content;
                    break;
                case "6":
                    seatcontent6.Background = color;
                    seatcontent6.Content = content;
                    break;
                case "7":
                    seatcontent7.Background = color;
                    seatcontent7.Content = content;
                    break;
                case "8":
                    seatcontent8.Background = color;
                    seatcontent8.Content = content;
                    break;
                case "9":
                    seatcontent9.Background = color;
                    seatcontent9.Content = content;
                    break;
                case "10":
                    seatcontent10.Background = color;
                    seatcontent10.Content = content;
                    break;
                case "11":
                    seatcontent11.Background = color;
                    seatcontent11.Content = content;
                    break;
                case "12":
                    seatcontent12.Background = color;
                    seatcontent12.Content = content;
                    break;
                case "13":
                    seatcontent13.Background = color;
                    seatcontent13.Content = content;
                    break;
                case "14":
                    seatcontent14.Background = color;
                    seatcontent14.Content = content;
                    break;
                case "15":
                    seatcontent15.Background = color;
                    seatcontent15.Content = content;
                    break;
                case "16":
                    seatcontent16.Background = color;
                    seatcontent16.Content = content;
                    break;
                case "17":
                    seatcontent17.Background = color;
                    seatcontent17.Content = content;
                    break;
                case "18":
                    seatcontent18.Background = color;
                    seatcontent18.Content = content;
                    break;
                case "19":
                    seatcontent19.Background = color;
                    seatcontent19.Content = content;
                    break;
                case "20":
                    seatcontent20.Background = color;
                    seatcontent20.Content = content;
                    break;
                case "21":
                    seatcontent21.Background = color;
                    seatcontent21.Content = content;
                    break;
                case "22":
                    seatcontent22.Background = color;
                    seatcontent22.Content = content;
                    break;
                case "23":
                    seatcontent23.Background = color;
                    seatcontent23.Content = content;
                    break;
                case "24":
                    seatcontent24.Background = color;
                    seatcontent24.Content = content;
                    break;
                case "25":
                    seatcontent25.Background = color;
                    seatcontent25.Content = content;
                    break;
            }
        }

        private void onClick(Button btn, int index)
        {
            try
            {
                if (seatdata[index].isOccupied == true)
                {
                    errormsg.Content = "This seat is already booked";
                }
                else
                {
                    btn.Background = Brushes.LightGreen;
                    foreach (var item in seatdata)
                    {
                        if (item.isSelected == true)
                        {
                            item.isSelected = false;
                        }
                    }
                    seatdata[index].isSelected = true;
                    isSeatExistforBook = true;
                }
            }
            catch (Exception)
            { }
        }

        private void seatcontent1_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 0);
        }

        private void seatcontent2_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 1);
        }

        private void seatcontent3_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 2);
        }

        private void seatcontent4_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 3);
        }

        private void seatcontent5_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 4);
        }

        private void seatcontent6_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 5);
        }

        private void seatcontent7_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 6);
        }

        private void seatcontent8_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 7);
        }

        private void seatcontent9_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 8);
        }

        private void seatcontent10_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 9);
        }

        private void seatcontent11_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 10);
        }

        private void seatcontent12_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 11);
        }

        private void seatcontent13_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 12);
        }

        private void seatcontent14_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 13);
        }

        private void seatcontent15_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 14);
        }

        private void seatcontent16_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 15);
        }

        private void seatcontent17_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 16);
        }

        private void seatcontent18_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 17);
        }

        private void seatcontent20_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 19);
        }

        private void seatcontent19_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 18);
        }

        private void seatcontent21_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 20);
        }

        private void seatcontent22_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 21);
        }

        private void seatcontent23_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 22);
        }

        private void seatcontent24_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 23);
        }

        private void seatcontent25_Click(object sender, RoutedEventArgs e)
        {
            onClick((Button)sender, 24);
        }

        private void Delete(Seat item)
        {
            /*var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFA4E5CF");*/

            item.isOccupied = false;
            item.isSelected = false;            
            colorchange(item, Brushes.CornflowerBlue, item.nameofSeat);
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            string searchedItem = Delete_item_text.Text;
            bool isItemFound = false;
            if (searchedItem != "")
            {
                foreach (var item in seatdata)
                {
                    if (item.isOccupied)
                    {
                        if (item.nameofConsumer == searchedItem || item.nameofSeat == searchedItem)
                        {

                            Delete(item);
                            isItemFound = true;
                            printList();
                            errormsg.Content = "";                            
                            return;
                        }
                    }
                    allseatbooked();
                }

                if (isItemFound == false)
                {
                    errormsg.Content = "Please Enter valid data";
                }
            }
            else
            {
                errormsg.Content = "Please Enter Consumer Name or Seat Number";
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < seatdata.Count; i++)
            {
                if (seatdata[i].isOccupied)
                {
                    colorchange(seatdata[i], Brushes.CornflowerBlue, seatdata[i].nameofSeat);                    
                    seatdata[i].isSelected = false;
                    seatdata[i].isOccupied = false;
                }
            }
            
            WriteData(seatdata);
            printList();
        }

        public static void WriteData(List<Seat> listinfo)
        {
            try
            {
                string file = "Person.json";
                FileStream fileStream = null;
                fileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                string json = JsonConvert.SerializeObject(listinfo);
                streamWriter.WriteLine(json);
                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong");
            }
        }
        public static List<Seat> ReadData()
        {
            try
            {
                string file = "Person.json";
                FileStream fileStream = null;
                fileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader streamReader = new StreamReader(fileStream);
                string s = "";
                while (streamReader.Peek() >= 0)
                {
                    s = s + streamReader.ReadLine();
                    Console.WriteLine(streamReader.ReadLine());
                }
                streamReader.Close();
                fileStream.Close();
                return JsonConvert.DeserializeObject<List<Seat>>(s);

            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong");
            }
            return new List<Seat>();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            WriteData(seatdata);
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            seatdata = ReadData();
            printList();
        }
    }
}