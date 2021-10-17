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

namespace Costin_Adrian_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoughnutMachine myDoughnutMachine;

        private int mRaisedGlezed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtGlazedRaised_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += new DoughnutMachine.DoughnutCompleteDelagate(DoughnutCompleteHandler);
        }

        private void glazedMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedMenuItem.IsChecked = true;
            sugarMenuItem.IsChecked = false;

            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }

        private void sugarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedMenuItem.IsChecked = false;
            sugarMenuItem.IsChecked = true;

            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void DoughnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlezed++;
                    txtGlazedRaised.Text = mRaisedGlezed.ToString();
                    break;

                case DoughnutType.Sugar:
                    mRaisedSugar++;
                    txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;

            }

            
        }

        private void mnuStop_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Puteti introduce doar cifre!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}