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

namespace BlackJack
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    /// escrever blackjack quando este e atingido
    /// escrever busted quando passa dos 21
    public partial class MainWindow : Window
    {
        public int counter = 0;
        public int curr_bet = 0;
        public List<Carta> curr_jogador;
        public List<Carta> curr_casa;
        public int pontosC;
        public int pontosJ;
        public int[] coordsP = { 200, 120 };
        public int[] coordsC = { 200, 22 };
        public Cartas cartas = new Cartas();
        public Image im;
        
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Bet_Click(object sender, RoutedEventArgs e)
        {
            vitoria.Visibility = Visibility.Hidden;
            curr_bet = (int)Slider.Value;
            carvas.Children.Clear();
            coordsC[0] = 200;
            coordsC[1] = 22;
            coordsP[0] = 200;
            coordsP[1] = 120;
            if (curr_bet != 0)
            {
                Slider.IsEnabled = false;
                curr_jogador = new List<Carta>();
                curr_casa = new List<Carta>();
                pontosJ = 0;
                pontosC = 0;
                for(int i = 0; i < 4; i++)
                {
                    Carta c = cartas.proxima();
                    if(i == 0 || i == 3)
                    {
                        pontosJ += c.numero;
                        curr_jogador.Add(c);
                        carvas.Children.Add(c.newImage(new Thickness(coordsP[0], coordsP[1], 0, 0)));
                        coordsP[0] += 20;
                        coordsP[1] += 20;
                    }
                    else
                    {
                        pontosC += c.numero;
                        curr_casa.Add(c);
                        im = i == 1 ? c.newImage(new Thickness(coordsC[0], coordsC[1], 0, 0)) : c.newImage(new Thickness(coordsC[0], coordsC[1], 0, 0), true);
                        carvas.Children.Add(im);
                        coordsC[0] += 15;
                        coordsC[1] += 20;

                    }
                }
                pJogador.Text = pontosJ.ToString();
                pCasa.Text = (pontosC - curr_casa.ElementAt(1).numero).ToString();
                if (pontosJ != 21)
                { 
                    bet.IsEnabled = false;
                    hit.IsEnabled = true;
                    stand.IsEnabled = true;
                }
                else
                {
                    vitoria.Text = "Ganhou Jogador";
                    vitoria.Visibility = Visibility;
                }

            } else
            {
                MessageBox.Show("A aposta tem que ser superior a 0");
            }

        }

        private void hit_Click(object sender, RoutedEventArgs e)
        {
            Carta ca = cartas.proxima();
            if (ca.numero == 11 && pontosJ + ca.numero > 21)
            {
                ca.changeVal();
            }
            pontosJ += ca.numero;
            if (curr_casa.ElementAt(1).onBack())
            {
                carvas.Children.Remove(im);
                
                carvas.Children.Add(curr_casa.ElementAt(1).turn());
            }
            carvas.Children.Add(ca.newImage(new Thickness(coordsP[0], coordsP[1], 0, 0)));
            coordsP[0] += 20;
            coordsP[1] += 20;
            if (pontosJ > 21 || pontosC == 21)
            {
                vitoria.Text = "Ganhou Casa";
                vitoria.Visibility = Visibility;
                bet.IsEnabled = true;
                hit.IsEnabled = false;
                stand.IsEnabled = false;
            } else if(pontosJ == 21 || pontosC > 21)
            {
                vitoria.Text = "Ganhou Jogador";
                vitoria.Visibility = Visibility;
                bet.IsEnabled = true;
                hit.IsEnabled = false;
                stand.IsEnabled = false;
            }
            pJogador.Text = pontosJ.ToString();
            pCasa.Text = pontosC.ToString();
        }

        private void stand_Click(object sender, RoutedEventArgs e)
        {
            if (curr_casa.ElementAt(1).onBack())
            {
                carvas.Children.Remove(im);
                carvas.Children.Add(curr_casa.ElementAt(1).turn());
            }
            while (pontosC < 17 && pontosC < pontosJ)            
            {
                Carta ca = cartas.proxima();
                carvas.Children.Add(ca.newImage(new Thickness(coordsC[0], coordsC[1], 0, 0)));
                coordsP[0] += 20;
                coordsP[1] += 20;
                if (ca.numero == 11 && pontosC + ca.numero > 21)
                {
                    ca.changeVal();
                }
                pontosC += ca.numero;
            }
            if (pontosC > pontosJ && pontosC <= 21)
            {
                vitoria.Text = "Ganhou Casa";
                vitoria.Visibility = Visibility;
                bet.IsEnabled = true;
                hit.IsEnabled = false;
                stand.IsEnabled = false;
            }
            else if(pontosC == pontosJ)
            {
                vitoria.Text = "Empate";
                vitoria.Visibility = Visibility;
                bet.IsEnabled = true;
                hit.IsEnabled = false;
                stand.IsEnabled = false;
            }
            else
            {
                vitoria.Text = "Ganhou Jogador";
                vitoria.Visibility = Visibility;
                bet.IsEnabled = true;
                hit.IsEnabled = false;
                stand.IsEnabled = false;
            }
            pJogador.Text = pontosJ.ToString();
            pCasa.Text = pontosC.ToString();

        }
    }

    public class Cartas
    {
        private List<Carta> cartas;

        public Cartas()
        {
            newDeck();
        }

        private void newDeck()
        {
            cartas = new List<Carta>();
            Carta c;
            string[] figuras = {"Ace_of_Clubs.jpg", "2_of_clubs.jpg", "3_of_clubs.jpg", "4_of_Clubs.jpg", "5_of_Clubs.jpg", "6_of_Clubs.jpg",
                                "7_of_Clubs.jpg", "8_of_Clubs.jpg", "9_of_Clubs.jpg" ,"10_of_Clubs.jpg", "Jack_of_Clubs.jpg", "Queen_of_Clubs.jpg", "King_of_Clubs.jpg"};
            cartas.Add(new Carta(11, figuras[0]));
            for (int i = 1; i < figuras.Length; i++)
            {
                if (i < 10)
                {
                    c = new Carta(i + 1, figuras[i]);
                }
                else
                {
                    c = new Carta(10, figuras[i]);
                }
                cartas.Add(c);
            }
        }

        public Carta proxima()
        {
            Random rnd = new Random();
            if (cartas.Count == 0)
            {
                newDeck();
            }
            int carta = rnd.Next(cartas.Count);
            Carta c = cartas.ElementAt(carta);
            cartas.Remove(c);
            return c;
        }
    }
    public class Carta
    {

        public int numero;
        private Image img;
        private string figura;
        private Boolean back;

        public Carta(int numero, string figura)
        {
            this.numero = numero;
            this.figura = figura;
            this.img = new Image()
            {
                Source = new BitmapImage(new Uri(@"/Imagens/" + figura, UriKind.Relative)),
                Width = 43,
                Height = 69,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };

        }

        public Boolean onBack()
        {
            return back;
        }

        public Image turn()
        {
            if (back)
            {
                back = false;
                img.Source = new BitmapImage(new Uri(@"/Imagens/" + figura, UriKind.Relative));
                return img;
            }
            back = true;
            img.Source = new BitmapImage(new Uri(@"/Imagens/back.jpg", UriKind.Relative));
            return img;
        }

        public Image newImage(Thickness thk, Boolean back = false)
        {
            img.Margin = thk;
            return back ? turn() : img;
        }


        public void changeVal()
        {
            if (numero == 11) numero = 1;
        }
    }
}
