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

namespace zd3_PavlovMaksim
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<RoadWork> roads = new List<RoadWork>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateList();
        }

        // Добавить базовый
        private void AddBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoadWork road = new RoadWork(
                    txtName.Text,
                    double.Parse(txtWidth.Text),
                    double.Parse(txtLength.Text),
                    double.Parse(txtMass.Text),
                    txtSurface.Text,
                    int.Parse(txtYear.Text)
                );
                roads.Add(road);
                UpdateList(); 
                ClearInputs();
                txtInfo.Text = "Добавлен базовый объект";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message}");
            }
        }

        // Добавить потомка
        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChildRoadWork road = new ChildRoadWork(
                    txtName.Text,
                    double.Parse(txtWidth.Text),
                    double.Parse(txtLength.Text),
                    double.Parse(txtMass.Text),
                    txtSurface.Text,
                    int.Parse(txtYear.Text),
                    int.Parse(txtP.Text),
                    txtWeather.Text
                );
                roads.Add(road);
                UpdateList();
                ClearInputs();
                txtInfo.Text = "Добавлен объект-потомок";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message}");
            }
        }

        // Удалить
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (lbRoads.SelectedItem == null)
            {
                MessageBox.Show("Выберите объект!");
                return;
            }
            roads.Remove((RoadWork)lbRoads.SelectedItem);
            UpdateList(); 
            txtInfo.Text = "Объект удален";
        }

      
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            roads.Clear();
            UpdateList();
            txtInfo.Text = "Все объекты удалены";
        }

        
        private void LINQ_Click(object sender, RoutedEventArgs e)
        {
            if (roads.Count == 0)
            {
                txtInfo.Text = "Список пуст!";
                return;
            }

            var result = roads.Where(r => r.Quality() > 1000).ToList();

            string info = $"Объектов с Q > 1000: {result.Count}\n\n";
            foreach (var r in result)
            {
                info += r.GetInfo() + "\n";
            }

            txtInfo.Text = info;
        }

       
        private void LbRoads_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbRoads.SelectedItem != null)
            {
                txtInfo.Text = ((RoadWork)lbRoads.SelectedItem).GetInfo();
            }
        }

        // Обновить список 
        private void UpdateList()
        {
            lbRoads.ItemsSource = null;        
            lbRoads.ItemsSource = roads;          
            lbRoads.Items.Refresh();             
        }

        // Очистить поля
        private void ClearInputs()
        {
            txtName.Clear();
            txtWidth.Clear();
            txtLength.Clear();
            txtMass.Clear();
            txtSurface.Clear();
            txtYear.Clear();
            txtP.Clear();
            txtWeather.Clear();
        }
    }
}