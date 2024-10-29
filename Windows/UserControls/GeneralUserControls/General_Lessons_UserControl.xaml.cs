using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.Windows.UserControls.GeneralUserControls
{
    public partial class General_Lessons_UserControl : UserControl
    {
        private MainWindow window;
        private Person user;
        private DateTime weekBeginning;
        private List<string> week = [];

        Dictionary<string, string> freeDays = new() 
        {
            // Rozpoczęcie roku szkolnego
            {"02.09", "Uroczyste rozpoczęcie roku szkolnego"},
    
            // Zimowa przerwa świąteczna
            {"23.12", "Zimowa przerwa świąteczna"},
            {"24.12", "Zimowa przerwa świąteczna"},
            {"25.12", "Zimowa przerwa świąteczna"},
            {"26.12", "Zimowa przerwa świąteczna"},
            {"27.12", "Zimowa przerwa świąteczna"},
            {"28.12", "Zimowa przerwa świąteczna"},
            {"29.12", "Zimowa przerwa świąteczna"},
            {"30.12", "Zimowa przerwa świąteczna"},
            {"31.12", "Zimowa przerwa świąteczna"},

            // Ferie zimowe
            {"03.02", "Ferie zimowe"},
            {"04.02", "Ferie zimowe"},
            {"05.02", "Ferie zimowe"},
            {"06.02", "Ferie zimowe"},
            {"07.02", "Ferie zimowe"},
            {"08.02", "Ferie zimowe"},
            {"09.02", "Ferie zimowe"},
            {"10.02", "Ferie zimowe"},
            {"11.02", "Ferie zimowe"},
            {"12.02", "Ferie zimowe"},
            {"13.02", "Ferie zimowe"},
            {"14.02", "Ferie zimowe"},
            {"15.02", "Ferie zimowe"},
            {"16.02", "Ferie zimowe"},

            // Wiosenna przerwa świąteczna
            {"17.04", "Wiosenna przerwa świąteczna"},
            {"18.04", "Wiosenna przerwa świąteczna"},
            {"19.04", "Wiosenna przerwa świąteczna"},
            {"20.04", "Wiosenna przerwa świąteczna"},
            {"21.04", "Wiosenna przerwa świąteczna"},
            {"22.04", "Wiosenna przerwa świąteczna"},

            // Święta państwowe
            {"01.01", "Nowy Rok"},
            {"06.01", "Święto Trzech Króli (Epifania)"},
            {"01.05", "Święto Pracy"},
            {"03.05", "Święto Narodowe Trzeciego Maja"},
            {"15.08", "Wniebowzięcie Najświętszej Maryi Panny (Święto Matki Bożej Zielnej)"},
            {"01.11", "Dzień Wszystkich Świętych"},
            {"11.11", "Narodowe Święto Niepodległości"},
    
            // Dodatkowe dni wolne od zajęć dydaktycznych
            {"14.10", "Dzień Edukacji Narodowej"},
            {"02.01", "Dni wolne pomiędzy Nowym Rokiem a Świętem Trzech Króli"},
            {"03.01", "Dni wolne pomiędzy Nowym Rokiem a Świętem Trzech Króli"},
            {"02.05", "Święto Flagi"},
            {"05.05", "Egzamin maturalny - język polski"},
            {"06.05", "Egzamin maturalny - matematyka"},
            {"07.05", "Egzamin maturalny - język angielski (podstawowy)"},
            {"08.05", "Egzamin maturalny - język angielski (rozszerzony)"},
            {"14.05", "Egzamin maturalny - informatyka"},
            {"20.06", "Piątek po Bożym Ciele"}
        };

        public General_Lessons_UserControl(MainWindow window, Person user)
        {
            InitializeComponent();
            this.window = window;
            this.user = user;

            weekBeginning = DateTime.Today;
            while (weekBeginning.DayOfWeek != DayOfWeek.Monday)
                weekBeginning = weekBeginning.AddDays(-1);

            InitializeGrid();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                FillDates();
                FillGrid(GetLessons());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading: {ex.Message}");
            }
        }

        private void FillDates()
        {
            week.Clear();
            FillGrid(GetLessons());
            for (int i = 0; i < 5; i++)
            {
                week.Add(weekBeginning.AddDays(i).ToString("dd.MM", CultureInfo.InvariantCulture));
            }

            monday_date_TextBlock.Text = week[0];
            tuesday_date_TextBlock.Text = week[1];
            wednesday_date_TextBlock.Text = week[2];
            thursday_date_TextBlock.Text = week[3];
            friday_date_TextBlock.Text = week[4];
        }

        private void ChangeWeek(int direction)
        {
            weekBeginning = weekBeginning.AddDays(7 * direction);
            FillDates();
        }


        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.GoBack();
        }

        private void InitializeGrid()
        {
            for (int row = 2; row <= 11; row++)
            {
                for (int column = 1; column <= 5; column++)
                {
                    var textBlock = new TextBlock
                    {
                        TextWrapping = TextWrapping.Wrap
                    };

                    Grid.SetRow(textBlock, row);
                    Grid.SetColumn(textBlock, column);
                    main_Grid.Children.Add(textBlock);
                }
            }
        }

        private void FillGrid(List<Lesson> lessons)
        {
            ClearGrid();
            Dictionary<int, string> dayMapping = GetDayMapping();

            foreach (var child in main_Grid.Children)
            {
                if (child is TextBlock textBlock)
                {
                    int row = Grid.GetRow(textBlock);
                    int column = Grid.GetColumn(textBlock);

                    if (column >= 1 && column <= 5 && row >= 2 && row <= 11)
                    {

                        string dateKey = dayMapping[column].Length == 4
                            ? "0" + dayMapping[column]
                            : dayMapping[column];

                        Console.WriteLine($"Processing Row: {row}, Column: {column}, DateKey: {dateKey}");

                        textBlock.Text = freeDays.TryGetValue(dateKey, out var holiday)
                            ? holiday
                            : GetLessonText(row, column, lessons);
                    }
                }
            }
        }

        private string GetLessonText(int row, int column, List<Lesson> lessons)
        {
            foreach (var lesson in lessons)
            {
                if (row == lesson.Lesson_hour + 2 && column == lesson.Lesson_day)
                    return $"{lesson.Name} ({lesson.Classroom})\n{lesson.Classname}";
            }
            return string.Empty;
        }

        private Dictionary<int, string> GetDayMapping()
        {
            return new Dictionary<int, string>
            {
                { 1, weekBeginning.ToString("dd.MM") },
                { 2, weekBeginning.AddDays(1).ToString("dd.MM") },
                { 3, weekBeginning.AddDays(2).ToString("dd.MM") },
                { 4, weekBeginning.AddDays(3).ToString("dd.MM") },
                { 5, weekBeginning.AddDays(4).ToString("dd.MM") }
            };
        }

        private List<Lesson> GetLessons()
        {
            if (user is Teacher teacher)
                return DatabaseOperator.GetLessons(teacher.Id);
            if (user is Student student)
                return DatabaseOperator.GetLessons(student.Classname);
            if (user is Person parent)
            {
                string classname = DatabaseOperator.GetClassnameParent(parent.Id);
                return DatabaseOperator.GetLessons(classname);
            }
            return [];
        }

        private void ClearGrid()
        {
            foreach (var child in main_Grid.Children)
            {
                if (child is TextBlock textBlock)
                {
                    int row = Grid.GetRow(textBlock);
                    int column = Grid.GetColumn(textBlock);

                    if (column >= 1 && column <= 5 && row >= 2 && row <= 11)
                        textBlock.Text = string.Empty;
                }
            }
        }

        private void Week_Button_Click(object sender, RoutedEventArgs e)
        {
            int direction = ((Button)sender).Name == "previous_week_Button" ? -1 : 1;
            ChangeWeek(direction);
        }
    }
}
