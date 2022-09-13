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

namespace MathcGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;
        public MainWindow()//создан автоматически видом приложения в окне создания проектов
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick; //timer.Tick += - создаёт метод Timer_Tick
            SetUpGame();//(1)
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed / 10f).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()//вызван автоматически после введения (1) и нажатия на "лампочку". "Лампочка" сама предложила построить метод и сделала его таким. throw new
                                //NotImplentedException();
                                //Это называется быстрое действие
        {
            List<string> animalEmoji = new List<string>() //Создаёт список из восьми пар эмодзи
            {
                "🐵", "🐵",
                "🐶", "🐶",
                "🐺", "🐺",
                "🐱", "🐱",
                "🦁", "🦁",
                "🐯", "🐯",
                "🦒", "🦒",
                "🦊", "🦊"
            };
            Random random = new Random(); //Создаёт новый генератор случайных чисел +

            foreach (TextBlock textBlock in //Находит каждый элемент TextBlock в сетке и повторяет следующие команды для каждого элемента +
                MainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count); //Выбирает случайное число от 0 до количества эмодзи в списке и назначает ему имя index +
                    string nextEmoji = animalEmoji[index]; //Использует случайное число с именем index для получения случайного эмодзи из списка +
                    textBlock.Text = nextEmoji; //Обновляет TextBlock случайным эмодзи из списка +
                    animalEmoji.RemoveAt(index); //Удаляет случайный эмодзи из списка +
                }
            }
            timer.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound = 0; //запускает таймер и сбрасывает содержимое полей
            //List - коллекция для хранения набора значений в определённом порядке. 
            //ключевое слово new - используется для создания списка List
            //панель эмодзи кнопка Windows + точка на английской раскладке
        }


        //Если щелчок сделан на первом животном в паре, сохранить информацию о том, на каком элементе TextBlock щёлкнул пользователь, и убрать животное. Если это второе
        //животное в паре, либо убрать его с экрана(если животное составляет пару), либо вернуть на экран первое животное(если животные разные)
        TextBlock lastTextBlockClicker;
        bool findingMatch = false; //Определяет щёлкнул ли пользователь по на первом животном в паре, и теперь пытается найти для него пару

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)  //Создаёт условия, согласно которым, если пользователь щёлкнул - объект становиться невидимым и сохраняется на случай,
                //если его придётся делать видимым снова, при неудачном подборе пары
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicker = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicker.Text) //если следующий TextBlock равен сохранённому TextBlock (игрок нашёл пару), то второй объект становиться
                                                                  //невидимым при дальнейших щелчках на него ничего не происходит. Переключатель сбрасывается, чтобы следующий
                                                                  //объект считался первым

            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else //В остальных случаях (если пользователь не сохранил нашёл пару) последний сохранённый объект становиться видимым и счётчик сбрасывается,
                 //чтобы снова выбранный объект считался первым
            {
                lastTextBlockClicker.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8) //Сбрасывает игру, если было найдено все 8 пар
            {
                SetUpGame();
            }
        }
    }
}
