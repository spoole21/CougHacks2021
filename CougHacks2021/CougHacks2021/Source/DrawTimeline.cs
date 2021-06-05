using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CougHacks2021
{
    class DrawTimeline
    {
        MainWindow window;
        private List<Rectangle> _rects = new List<Rectangle>();

        public DrawTimeline(MainWindow newWindow)
        {
            window = newWindow;
        }

        public void drawAttendBoxes(List<List<bool>> array)
        {
            clearBoxes();
            drawkMarkers();
            _rects.Clear();

            for (int i = 0; i < 35; i++)
            {
                if(array[0][i] == true)
                {
                    Rectangle rect;
                    rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Black);
                    rect.Fill = new SolidColorBrush(Colors.Black);
                    rect.Width = 15;
                    rect.Height = 20;
                    rect.Name = "box" + i.ToString();

                    Canvas.SetLeft(rect, i*14);
                    Canvas.SetTop(rect, window.timeCanvas.Height / 2);

                    _rects.Add(rect);
                }
            }
            foreach (var rects in _rects)
            {
                window.timeCanvas.Children.Add(rects);
            }
        }

        public void drawPlannerBoxes(List<List<bool>> array)
        {
            clearBoxes();
            drawkMarkers();
            drawColoredBox(array[4], Colors.Gray, 20);
            drawColoredBox(array[3], Colors.Yellow, 15);
            drawColoredBox(array[2], Colors.Red, 10);
            drawColoredBox(array[1], Colors.Blue, 5);
            drawColoredBox(array[0], Colors.Green, 0);
            //drawColoredBox(array[5], Colors.Orange, 25);
            
        }

        public void drawColoredBox(List<bool> array, Color color, int offset)
        {

            _rects.Clear();

            for (int i = 0; i < 35; i++)
            {
                if (array[i] == true)
                {
                    Rectangle rect;
                    rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(color);
                    rect.Fill = new SolidColorBrush(color);
                    rect.Width = 15;
                    rect.Height = 20;
                    rect.Name = "box" + i.ToString();

                    Canvas.SetLeft(rect, i * 14);
                    Canvas.SetTop(rect, (window.timeCanvas.Height / 2) - offset);

                    _rects.Add(rect);
                }
            }
            foreach (var rects in _rects)
            {
                window.timeCanvas.Children.Add(rects);
            }
        }

        public void clearBoxes()
        {
            window.timeCanvas.Children.Clear();
        }

        public void drawkMarkers()
        {
            for (int i = 0; i < 36; i++)
            {
                    Rectangle rect;
                    rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Black);
                    rect.Fill = new SolidColorBrush(Colors.Black);
                    rect.Width = 2;
                    rect.Height = 40;
                    rect.Name = "box" + i.ToString();
                    

                    Canvas.SetLeft(rect, i * 14);
                    Canvas.SetTop(rect, window.timeCanvas.Height / 2);

                    _rects.Add(rect);
            }
            foreach (var rects in _rects)
            {
                window.timeCanvas.Children.Add(rects);
            }

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "6AM";
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBlock, 0);
            Canvas.SetTop(textBlock, (window.timeCanvas.Height / 2) + 40);
            window.timeCanvas.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "9AM";
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBlock, 80);
            Canvas.SetTop(textBlock, (window.timeCanvas.Height / 2) + 40);
            window.timeCanvas.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "12PM";
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBlock, 165);
            Canvas.SetTop(textBlock, (window.timeCanvas.Height / 2) + 40);
            window.timeCanvas.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "3PM";
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBlock, 250);
            Canvas.SetTop(textBlock, (window.timeCanvas.Height / 2) + 40);
            window.timeCanvas.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "6PM";
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBlock, 335);
            Canvas.SetTop(textBlock, (window.timeCanvas.Height / 2) + 40);
            window.timeCanvas.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = "9PM";
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBlock, 415);
            Canvas.SetTop(textBlock, (window.timeCanvas.Height / 2) + 40);
            window.timeCanvas.Children.Add(textBlock);


            textBlock = new TextBlock();
            textBlock.Text = "11PM";
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBlock, 480);
            Canvas.SetTop(textBlock, (window.timeCanvas.Height / 2) + 40);
            window.timeCanvas.Children.Add(textBlock);
        }
    }
}
