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
        //Clear
        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearCalculator();
        }
        //Egale
        private void BTN_Egale_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
        }
        //Division
        private void BTN_Division_Click(object sender, RoutedEventArgs e)
        {
            SetOperation('/');
        }
        //Tan
        private void BTN_Tan_Click(object sender, RoutedEventArgs e)
        {
            N1 = double.Parse(TB_Display.Text);
            TB_Display.Text = "";
            operation = 't';
        }
        //Cos
        private void BTN_Cos_Click(object sender, RoutedEventArgs e)
        {
            N1 = double.Parse(TB_Display.Text);
            TB_Display.Text = "";
            operation = 'c';
        }
        //Racine
        private void BTN_Racine_Click(object sender, RoutedEventArgs e)
        {
            N1 = double.Parse(TB_Display.Text);
            TB_Display.Text = "";
            operation = 'r';
        }
        //Virgule
        private void BTN_Virgule_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToDisplay(",");
        }
        //Remise valeur a neutre
        private void AppendNumberToDisplay(string number)
        {
            TB_Display.Text += number;
        }

        private void SetOperation(char op)
        {
            // Récupère le nombre actuel dans le champ de texte (TB_Display) et le stocke dans la variable N1.
            N1 = double.Parse(TB_Display.Text);
            // Réinitialise le champ de texte (TB_Display) à "" pour commencer à saisir un nouveau nombre.
            TB_Display.Text = "";
            // Stocke le caractère '' dans la variable 'operation', indiquant que l'opération à effectuer.
            operation = op;
        }
        // Méthode pour effacer le calculateur
        private void ClearCalculator()
        {
            N1 = 0;
            N2 = 0;
            Result = 0;
            // Efface l'DTB_Display en mettant un espace vide
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
                    case 'r':
                        Result = Math.Sqrt(N1);//Calcul Racine
                        TB_Display.Text = Result.ToString();
                        break;
                    case 'c':
                        Result = Math.Cos(N1);//Calcul Cos
                        TB_Display.Text = Result.ToString();
                        break;
                    case 't':
                        Result = Math.Tan(N1);// Calcul Tan
                        TB_Display.Text = Result.ToString();
                        break;
                }
                // Affiche le résultat dans l'DTB_Display
                TB_Display.Text = Result.ToString();
            }
        }
    }
}
