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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()//создан автоматически видом приложения в окне создания проектов
        {
            InitializeComponent();

            SetUpGame();//(1)
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
                int index = random.Next(animalEmoji.Count); //Выбирает случайное число от 0 до количества эмодзи в списке и назначает ему имя index +
                string nextEmoji = animalEmoji[index]; //Использует случайное число с именем index для получения случайного эмодзи из списка +
                textBlock.Text = nextEmoji; //Обновляет TextBlock случайным эмодзи из списка +
                animalEmoji.RemoveAt(index); //Удаляет случайный эмодзи из списка +
            }
            
            //List - коллекция для хранения набора значений в определённом порядке. 
            //ключевое слово new - используется для создания списка List
            //панель эмодзи кнопка Windows + точка на английской раскладке
        }
    }
}
