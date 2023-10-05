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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ANDRIANASOLOHARISON_Tsiory_Calculatrice
{
   //Definition des valeurs
    public partial class MainWindow : Window
    {
        double N1 = 0;// Première valeur de l'opération
        double N2 = 0;// Deuxiéme valeur de l'opération
        double Result = 0;// Résultat de l'opération
        char operation = ' '; //Les opérateurs

        public MainWindow()
        {
            InitializeComponent();
        }
        // Méthode appelée lorsque le bouton "1" est cliqué
        private void BTN_1_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("1");
        }
        // Méthode appelée lorsque le bouton "+" est cliqué
        private void BTN_2_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("2");
        }

        private void BTN_3_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("3");
        }

        private void BTN_Plus_Click(object sender, RoutedEventArgs e)
        {
            SetOperation('+');
        }

        private void BTN_4_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("4");
        }

        private void BTN_5_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("5");
        }

        private void BTN_6_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("6");
        }

        private void BTN_Moins_Click(object sender, RoutedEventArgs e)
        {
            SetOperation('-');
        }

        private void BTN_7_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("7");
        }

        private void BTN_8_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("8");
        }

        private void BTN_9_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("9");
        }

        private void BTN_Fois_Click(object sender, RoutedEventArgs e)
        {
            SetOperation('*');
        }

        private void BTN_0_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay("0");
        }

        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearCalculator();
        }

        private void BTN_Egale_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
        }

        private void BTN_Division_Click(object sender, RoutedEventArgs e)
        {
            SetOperation('/');
        }
        
        private void AppendNumberToDisplay(string number)
        {
            TB_Display.Text += number;
        }

        private void SetOperation(char op)
        {
            N1 = double.Parse(TB_Display.Text);
            TB_Display.Text = "";
            operation = op;
        }
        // Méthode pour effacer le calculateur
        private void ClearCalculator()
        {
            N1 = 0;
            N2 = 0;
            Result = 0;
            // Efface l'affichage en mettant un espace vide
            TB_Display.Text = " ";
        }
        //Methode de calcul
        private void CalculateResult()
        {
            // Le code à exécuter lorsque TB_Display.Text n'est pas vide ou nul
            if (!string.IsNullOrEmpty(TB_Display.Text))
            {
                // Convertit le texte en double et le stocke dans N2
                N2 = double.Parse(TB_Display.Text);
                switch (operation)
                {
                    case '+':
                        Result = N1 + N2;//calcul addition
                        break;
                    case '-':
                        Result = N1 - N2;//calcul soustraction
                        break;
                    case '*':
                        Result = N1 * N2; //Calcul multiplication
                        break;
                    case '/':
                        if (N2 > 0)
                        {
                            Result = N1 / N2;// Effectue une division si le dénominateur n'est pas zéro
                        }
                        else
                        {
                            MessageBox.Show("Division par zéro impossible.");// Affiche un message d'erreur en cas de division par zéro
                            ClearCalculator(); // Réinitialise le calculateur
                            return;
                        }
                        break;
                }
                // Affiche le résultat dans l'affichage
                TB_Display.Text = Result.ToString();
            }
        }
    }
}

