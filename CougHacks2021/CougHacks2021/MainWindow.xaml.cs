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
using System.Windows.Controls;

namespace CougHacks2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> buttons;
        private Dictionary<string, Button> selectedButtons = new Dictionary<string, Button>();
        private List<List<bool>> temp = new List<List<bool>>();

        public Arrival adam;
        public Arrival alex;
        public Arrival shawn;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button>();
            FillButtonList();

            for (int i = 0; i < 6; i++)
            {
                List<bool> listTemp = new List<bool>();

                for (int j = 0; j < 35; j++)
                {
                    listTemp.Add(false);
                }
                temp.Add(listTemp);
            }


            adam = new Arrival(temp, temp);            
            alex = new Arrival(temp, temp);            
            shawn = new Arrival(temp, temp);
        }
     
        public void ButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string name = button.Name.ToString();

            if (name == buttonSubmitSelectedTimes.Name)
            {
                submitSelectedTimes();
                draw();
                return;
            }
            if (!selectedButtons.ContainsKey(name))
            {
                button.Background = Brushes.CornflowerBlue;
                selectedButtons.Add(name, button);
            }
            else
            {
                button.Background = Brushes.LightGray;
                selectedButtons.Remove(name);
            }
        }
        

        //for planner
        private List<List<bool>> create2DArray(List<int> selectedDates)
        {
            List<bool> parks = new List<bool>();
            List<bool> gyms = new List<bool>();
            List<bool> malls = new List<bool>();
            List<bool> beaches = new List<bool>();
            List<bool> libraries = new List<bool>();
            List<bool> museums = new List<bool>();
            List<bool> pizza = new List<bool>();
            List<bool> highway = new List<bool>();
            List<bool> burger = new List<bool>();
            List<bool> clips = new List<bool>();
            List<bool> nails = new List<bool>();
            List<bool> mugu = new List<bool>();

            List<List<bool>> array = new List<List<bool>>();

            if (plannerTab.IsSelected)
            {
                array.Add(parks);
                array.Add(gyms);
                array.Add(malls);
                array.Add(beaches);
                array.Add(libraries);
                array.Add(museums);
            }
            else if(attendTab.IsSelected)
            {
                array.Add(pizza);
                array.Add(highway);
                array.Add(burger);
                array.Add(clips);
                array.Add(nails);
                array.Add(mugu);
            }

            foreach (List<bool> list in array)
            {
               for (int i = 0; i < buttons.Count; i++)
               {
                    list.Add(false);
               }
            }

            //for planner

            if(plannerTab.IsSelected)
            {
                if (checkBoxParks.IsChecked == true)
                {
                    processSelectedTimes(parks, selectedDates);
                }

                if (checkBoxGyms.IsChecked == true)
                {
                    processSelectedTimes(gyms, selectedDates);
                }

                if (checkBoxMalls.IsChecked == true)
                {
                    processSelectedTimes(malls, selectedDates);
                }

                if (checkBoxBeaches.IsChecked == true)
                {
                    processSelectedTimes(beaches, selectedDates);
                }

                if (checkBoxLibraries.IsChecked == true)
                {
                    processSelectedTimes(libraries, selectedDates);
                }

                if (checkBoxMuseums.IsChecked == true)
                {
                    processSelectedTimes(museums, selectedDates);
                }
            }
            else if(attendTab.IsSelected)
            {
                if (fandrbutton.IsChecked == true)
                {
                    if (lstboxlocations.SelectedIndex == 0)
                    {
                        processSelectedTimes(pizza, selectedDates);
                    }
                    else if (lstboxlocations.SelectedIndex == 1)
                    {
                        processSelectedTimes(highway, selectedDates);
                    }
                    else if (lstboxlocations.SelectedIndex == 2)
                    {
                        processSelectedTimes(burger, selectedDates);
                    }

                }

                if (bandsbutton.IsChecked == true)
                {
                    if (lstboxlocations.SelectedIndex == 0)
                    {
                        processSelectedTimes(clips, selectedDates);
                    }
                    else if (lstboxlocations.SelectedIndex == 1)
                    {
                        processSelectedTimes(nails, selectedDates);
                    }
                }

                if (storebutton.IsChecked == true)
                {
                    if (lstboxlocations.SelectedIndex == 0)
                    {
                        processSelectedTimes(mugu, selectedDates);
                    }
                    else if (lstboxlocations.SelectedIndex == 1)
                    {
                        //processSelectedTimes(comics, selectedDates);
                    }
                }
            }

            return array;

        }

        //making an list of all the indexes that are selected
        private List<bool> processSelectedTimes(List<bool> array, List<int> indexes)
        {
            for (int i = 0; i < array.Count; i++)
            {
                foreach(int num in indexes)
                {
                    if (num == i)
                    {
                        array[i] = true;
                    }
                }
            }
            return array;
        }
        
        private void submitSelectedTimes()
        {
            List<List<bool>> array = create2DArray(getSelectedTimes());
            if (adamButton.IsChecked == true)
            {
                if (plannerTab.IsSelected)
                    adam.desiredTime = array;
                else if (attendTab.IsSelected)
                    adam.desiredAttendanceTime = array;
            }
            else if (alexButton.IsChecked == true)
            {
                if (plannerTab.IsSelected)
                    alex.desiredTime = array;
                else if (attendTab.IsSelected)
                    alex.desiredAttendanceTime = array;
            }
            else if (shawnButton.IsChecked == true)
            {
                if (plannerTab.IsSelected)
                    shawn.desiredTime = array;
                else if (attendTab.IsSelected)
                    shawn.desiredAttendanceTime = array;
            }

            Source.Scheduler scheduler = new Source.Scheduler();

            scheduler.window = this;

            scheduler.addArrival(adam);
            scheduler.addArrival(alex);
            scheduler.addArrival(shawn);
            scheduler.getSchedule();



            Console.WriteLine();
            return;
        }

        private List<int> getSelectedTimes()
        {
            int index = 0;
            List<int> indexes = new List<int>();

            foreach(Button button in buttons)
            {
                string name = button.Name;

                foreach (KeyValuePair<string, Button> pair in selectedButtons)
                {
                    if (pair.Key == name)
                    {
                        indexes.Add(index);
                        break;
                    }
                }
                index++;
            }
            
            return indexes;
        }

        public void FillButtonList()
        {
            this.buttons.Add(this.button600am);
            this.buttons.Add(this.button630am);
            this.buttons.Add(this.button700am);
            this.buttons.Add(this.button730am);
            this.buttons.Add(this.button800am);
            this.buttons.Add(this.button830am);
            this.buttons.Add(this.button900am);
            this.buttons.Add(this.button930am);
            this.buttons.Add(this.button1000am);
            this.buttons.Add(this.button1030am);
            this.buttons.Add(this.button1100am);
            this.buttons.Add(this.button1130am);
            this.buttons.Add(this.button1200pm);
            this.buttons.Add(this.button1230pm);
            this.buttons.Add(this.button100pm);
            this.buttons.Add(this.button130pm);
            this.buttons.Add(this.button200pm);
            this.buttons.Add(this.button230pm);
            this.buttons.Add(this.button300pm);
            this.buttons.Add(this.button330pm);
            this.buttons.Add(this.button400pm);
            this.buttons.Add(this.button430pm);
            this.buttons.Add(this.button500pm);
            this.buttons.Add(this.button530pm);
            this.buttons.Add(this.button600pm);
            this.buttons.Add(this.button630pm);
            this.buttons.Add(this.button700pm);
            this.buttons.Add(this.button730pm);
            this.buttons.Add(this.button800pm);
            this.buttons.Add(this.button830pm);
            this.buttons.Add(this.button900pm);
            this.buttons.Add(this.button930pm);
            this.buttons.Add(this.button1000pm);
            this.buttons.Add(this.button1030pm);
            this.buttons.Add(this.button1100pm);

            foreach(Button button in buttons)
            {
                button.Background = Brushes.LightGray;
            }
        }

        //food radio button
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            lstboxlocations.Items.Clear();
            lstboxlocations.Items.Add("Enzo's Pizza");
            lstboxlocations.Items.Add("Highway Teriyaki");
            lstboxlocations.Items.Add("Nick Jr's Burgers");
        }

        //barbers
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            lstboxlocations.Items.Clear();
            lstboxlocations.Items.Add("Great Clips");
            lstboxlocations.Items.Add("Highway Nails");
        }

        //stores
        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            lstboxlocations.Items.Clear();
            lstboxlocations.Items.Add("Mugu Games");
        }

        public bool plannerTabSelected()
        {
            return plannerTab.IsSelected;
        }

        public void draw()
        {
            DrawTimeline drawer = new DrawTimeline(this);
            drawer.clearBoxes();

            if (adamButton.IsChecked == true)
            {
                if (plannerTabSelected())
                    drawer.drawPlannerBoxes(adam.desiredTime);
                else
                    drawer.drawAttendBoxes(adam.desiredAttendanceTime);
            }
            else if(alexButton.IsChecked == true)
            {
                if (plannerTabSelected())
                    drawer.drawPlannerBoxes(alex.desiredTime);
                else
                    drawer.drawAttendBoxes(alex.desiredAttendanceTime);
            }
            else if (shawnButton.IsChecked == true)
            {
                if (plannerTabSelected())
                    drawer.drawPlannerBoxes(shawn.desiredTime);
                else
                    drawer.drawAttendBoxes(shawn.desiredAttendanceTime);
            }
        }

        private void adamButton_Checked(object sender, RoutedEventArgs e)
        {
            clearMenuBoxes();

            if(adam != null)
                draw();

            List<bool> templist = new List<bool>();
            for (int i = 0; i < 35; i++)
            {
                templist.Add(false);
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    if (adam != null)
                    {
                        if (adam.desiredTime[i][j] == true)
                        {
                            templist[j] = true;
                        }
                    }

                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    if (adam != null)
                    {
                        if (adam.desiredAttendanceTime[i][j] == true)
                        {
                            templist[j] = true;
                        }
                    }

                }
            }


            int index = 0;
            foreach (bool val in templist)
            {
                if (val)
                {
                    this.buttons[index].Background = Brushes.CornflowerBlue;
                }

                index++;
            }


        }

        private void alexButton_Checked(object sender, RoutedEventArgs e)
        {
            clearMenuBoxes();


            draw();

            List<bool> templist = new List<bool>();
            for (int i = 0; i < 35; i++)
            {
                templist.Add(false);
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    if (alex.desiredTime[i][j] == true)
                    {
                        templist[j] = true;
                    }
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    if (alex.desiredAttendanceTime[i][j] == true)
                    {
                        templist[j] = true;
                    }
                }
            }

            int index = 0;
            foreach (bool val in templist)
            {
                if (val)
                {
                    this.buttons[index].Background = Brushes.CornflowerBlue;
                }

                index++;
            }
        }

        private void shawnButton_Checked(object sender, RoutedEventArgs e)
        {
            clearMenuBoxes();

            draw();

            List<bool> templist = new List<bool>();
            for (int i = 0; i < 35; i++)
            {
                templist.Add(false);
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    if (shawn.desiredTime[i][j] == true)
                    {
                        templist[j] = true;
                    }
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    if (shawn.desiredAttendanceTime[i][j] == true)
                    {
                        templist[j] = true;
                    }
                }
            }

            int index = 0;
            foreach (bool val in templist)
            {
                if (val)
                {
                    this.buttons[index].Background = Brushes.CornflowerBlue;
                }

                index++;
            }


        }

        private void clearMenuBoxes()
        {
            foreach (KeyValuePair<string, Button> pair in selectedButtons)
            {
                pair.Value.Background = Brushes.LightGray;
            }
        }
    }
}
