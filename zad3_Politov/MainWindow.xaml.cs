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

namespace zad3_Politov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FoodManager manager = new FoodManager();

        public MainWindow()
        {
            InitializeComponent();
            manager.Add(new Food("Яблоко", 0.4, 9.8, 0.4, "Фрукты"));
            manager.Add(new DetailFood("Филе", 23, 0, 2, "Мясо", 110, "Мираторг"));
            UpdateUi();
        }
        //Перезаполнение списка(очистка нынешнего и добавление обновленного)
        private void UpdateUi()
        {
            MainList.Items.Clear();
            foreach (Food item in manager.FoodList)
            {
                MainList.Items.Add(item.GetInfo());
            }
            LblStatus.Text = $"Среднее качество всей коллекции: {manager.GetAvgQ():F2}";
        }
        //Изменение панели видимости дополнительных полей при нажатии на CheckBox
        private void Chk_Changed(object sender, RoutedEventArgs e)
        {
            if (PanelChild == null) return;

            if (ChkIsChild.IsChecked == true)
                PanelChild.Visibility = Visibility.Visible;
            else
                PanelChild.Visibility = Visibility.Collapsed;
        }
        
        //Добавление продукта через объект в случае if и по полям в случе else
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TxtName.Text;
                double belok = Convert.ToDouble(TxtBelok.Text);
                double ugl = Convert.ToDouble(TxtUgl.Text);
                double fats = Convert.ToDouble(TxtFats.Text);
                string kat = TxtKat.Text;
                if (ChkIsChild.IsChecked == true)
                {
                    double p = Convert.ToDouble(TxtP.Text);
                    string firm = TxtFirm.Text;
                    manager.Add(new DetailFood(name, belok, ugl, fats, kat, p, firm));
                }
                else
                {
                    manager.Add(name, belok, ugl, fats, kat);
                }

                UpdateUi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введено неверное значение" + ex.Message);
            }
        }
        //Удаление выделенного элемента
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MainList.SelectedIndex >= 0)
            {
                manager.Remove(MainList.SelectedIndex);
                UpdateUi();
            }
            else
            {
                MessageBox.Show("Выберите элемент из списка для удаления");
            }
        }
        //Перезаполнение списка
        private void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            UpdateUi();
        }
        //отображение продуктов со значением белка > 15
        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            MainList.Items.Clear();
            List<string> filteredList = manager.Filter();
            foreach (string info in filteredList)
            {
                MainList.Items.Add("Фильтр " + info);
            }
        }
        //Удаление продукта по его названию
        private void BtnRemove2_Click(object sender, RoutedEventArgs e)
        {
            if (TxtName.Text != "")
            {
                manager.Remove(TxtName.Text);
                UpdateUi();
            }
            else
            {
                MessageBox.Show("Поле названия ничего не содержит");
            }
        }
    }
}
