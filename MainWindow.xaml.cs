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

namespace Piatnashky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] buttons = new Button[4, 4];
        SolidColorBrush defColor = new SolidColorBrush(Colors.White);
        SolidColorBrush empColor = new SolidColorBrush(Colors.Black);
        int ie = 3;
        int je = 3;
        Random random = new Random();
        bool isGenerating;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button a = new Button();
                    MainGrid.Children.Add(a);
                    Grid.SetRow(a, i);
                    Grid.SetColumn(a, j);
                    a.Content = i * 4 + j + 1;
                    if (a.Content.ToString()=="16")
                    {
                        a.Background = empColor;
                        a.Content = null;
                    }
                    else
                    {
                        a.Background = defColor;
                    }
                    a.Click += A_Click;
                   
                    buttons[i, j] = a;

                }
            }
            GenerateMatrix();
        }

        

        private void A_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            int i = Grid.GetRow(a);
            int j = Grid.GetColumn(a);
            if (i!=0)
            {
                if (buttons[i-1,j].Content==null)
                {
                    buttons[i - 1, j].Content = a.Content;
                    buttons[i - 1, j].Background = defColor;
                    a.Content = null;
                    a.Background = empColor;
                    
                    
                }
            }
            if (j != 3)
            {
                if (buttons[i, j+1].Content == null)
                {
                    buttons[i, j+1].Content = a.Content;
                    buttons[i, j+1].Background = defColor;
                    a.Content = null;
                    a.Background = empColor;
                    
                    
                }
            }
            if (i != 3)
            {
                if (buttons[i + 1, j].Content == null)
                {
                    buttons[i + 1, j].Content = a.Content;
                    buttons[i + 1, j].Background = defColor;
                    a.Content = null;
                    a.Background = empColor;
                    
                    
                }
            }
            if (j != 0)
            {
                if (buttons[i, j-1].Content == null)
                {
                    buttons[i, j-1].Content = a.Content;
                    buttons[i, j-1].Background = defColor;
                    a.Content = null;
                    a.Background = empColor;
                    
                    
                }
            }
            if (!isGenerating)
            {
                if (CheckWin())
                {
                    MessageBox.Show("Win");
                    GenerateMatrix();
                }
            }

        }
        private void GenerateMatrix()
        {
            ie = 3;
            je = 3;
            isGenerating = true;
            for (Int64 i = 0; i <200; i++)
            {
                int vector = random.Next(4);
              
                if (vector==0 && ie!=0)
                {
                    A_Click(buttons[ie - 1, je],new RoutedEventArgs());
                    ie--;
                }
                else if (vector==1 && je!=3)
                {
                    A_Click(buttons[ie, je+1], new RoutedEventArgs());
                    je++;
                }
                else if (vector == 2 && ie != 3)
                {
                    A_Click(buttons[ie+1, je], new RoutedEventArgs());
                    ie++;
                }
                else if (vector == 3 && je != 0)
                {
                    A_Click(buttons[ie, je - 1], new RoutedEventArgs());
                    je--;
                }
            }
            isGenerating = false;
        }
        private bool CheckWin()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (buttons[i,j].Content!=null)
                    {
                        if (buttons[i, j].Content.ToString() != (i * 4 + j + 1).ToString())
                        {
                            return false;
                        }
                    }
                      
                }
            }
            return true;
        }
    }
}
