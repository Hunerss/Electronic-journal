

using Electronic_journal.Classes.DataClasses;
using MySqlConnector;
using SHA3.Net;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Electronic_journal.Classes
{
    public class DatabaseOperator
    {
        private static readonly string db_adress = "SERVER=localhost;DATABASE=electronic_journal;UID=root;PASSWORD=;ConvertZeroDateTime=True;";
        private static readonly MySqlConnection connector = new(db_adress);

        #region Removers

        public static bool RemoveUser(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                connector.Open();
                string query = "DELETE FROM users WHERE email=@Email";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - RemoveUser - succes log - User addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - RemoveUser - error log - Failed to remove user");
                Console.WriteLine("DatabaseOperator - RemoveUser - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool RemoveUser(string email, int id)
        {
            if (string.IsNullOrEmpty(email) || id < 0)
                return false;

            try
            {
                connector.Open();
                string query = "DELETE FROM users WHERE email=@Email AND school_role_id=@Id";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - RemoveUser - succes log - User removed successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - RemoveUser - error log - Failed to remove user");
                Console.WriteLine("DatabaseOperator - RemoveUser - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool RemoveStudent(int id)
        {
            if (id < 0)
                return false;

            try
            {
                connector.Open();
                string query = "DELETE FROM students WHERE id=@Id";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - RemoveStudent - succes log - Student removed successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - RemoveStudent - error log - Failed to remove student");
                Console.WriteLine("DatabaseOperator - RemoveStudent - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool RemoveTeacher(int id)
        {
            if (id < 0)
                return false;

            try
            {
                connector.Open();
                string query = "DELETE FROM teachers WHERE id=@Id";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - RemoveTeacher - succes log - Teacher removed successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - RemoveTeacher - error log - Failed to remove teacher");
                Console.WriteLine("DatabaseOperator - RemoveTeacher - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool RemoveParent(int id)
        {
            if (id < 0)
                return false;

            try
            {
                connector.Open();
                string query = "DELETE FROM parents WHERE id=@Id";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - RemoveParent - succes log - Parent removed successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - RemoveParent - error log - Failed to remove parent");
                Console.WriteLine("DatabaseOperator - RemoveParent - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool RemoveLessonsByClass(string classname)
        {
            if (string.IsNullOrEmpty(classname))
                return false;

            try
            {
                connector.Open();
                string query = "DELETE FROM lessons WHERE class = @Classname";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Classname", classname);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - RemoveParent - succes log - Lessons removed successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - RemoveParent - error log - Failed to remove lessons");
                Console.WriteLine("DatabaseOperator - RemoveParent - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        #endregion

        #region Adders

        #region User

        public static bool AddUser(int school_role, int school_role_id, string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;

            try
            {
                connector.Open();
                string query = "INSERT INTO users(school_role, school_role_id, email, password) VALUES (@School_role, @School_role_id, @Email, @Password)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@School_role", school_role);
                command.Parameters.AddWithValue("@School_role_id", school_role_id);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", HashPassword(password));
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddUser - 1 - succes log - User addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddUser - error log - Failed to add user");
                Console.WriteLine("DatabaseOperator - AddUser - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool AddUser(int school_role, int school_role_id, string email, string password, MySqlConnection connector)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;

            try
            {
                string query = "INSERT INTO users(school_role, school_role_id, email, password) VALUES (@School_role, @School_role_id, @Email, @Password)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@School_role", school_role);
                command.Parameters.AddWithValue("@School_role_id", school_role_id);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", HashPassword(password));
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddUser - 2 - succes log - User addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddUser - error log - Failed to add user");
                Console.WriteLine("DatabaseOperator - AddUser - exception message - " + ex.Message);
                return false;
            }
        }

        public static bool AddUser(Admin admin)
        {
            try
            {
                connector.Open();
                string query = "INSERT INTO users(school_role, school_role_id, email, password) VALUES (@School_role, @School_role_id, @Email, @Password)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@School_role", 0);
                command.Parameters.AddWithValue("@School_role_id", 0);
                command.Parameters.AddWithValue("@Email", admin.Email);
                command.Parameters.AddWithValue("@Password", admin.Email);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddUser - 3 - succes log - User addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddUser - error log - Failed to add user");
                Console.WriteLine("DatabaseOperator - AddUser - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool AddUser(Admin admin, MySqlConnection connector)
        {
            try
            {
                string query = "INSERT INTO users(school_role, school_role_id, email, password) VALUES (@School_role, @School_role_id, @Email, @Password)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@School_role", 0);
                command.Parameters.AddWithValue("@School_role_id", 0);
                command.Parameters.AddWithValue("@Email", admin.Email);
                command.Parameters.AddWithValue("@Password", admin.Email);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddUser - 4 - succes log - User addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddUser - error log - Failed to add user");
                Console.WriteLine("DatabaseOperator - AddUser - exception message - " + ex.Message);
                return false;
            }
        }

        #endregion

        #region Teachers

        public static bool AddTeacher(string name, string surname, string subject, string classname, int classroom, int birthday, int age, byte sex)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(subject) || birthday <= 0 || age <= 0)
                return false;

            try
            {
                connector.Open();

                string query = "INSERT INTO teachers(name, surname, subject, class, classroom, birthday, age, sex) " +
                    "VALUES(@Name, @Surname, @Subject, @Class, @Classroom, @Birthday, @Age, @Sex)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Subject", subject);
                command.Parameters.AddWithValue("@Class", classname);
                command.Parameters.AddWithValue("@Classroom", classroom);
                command.Parameters.AddWithValue("@Birthday", birthday);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Sex", sex);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddTeacher - succes log - Teacher addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddTeacher - error log - Failed to add teacher");
                Console.WriteLine("DatabaseOperator - AddTeacher - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool AddTeacher(Teacher teacher)
        {
            try
            {
                connector.Open();

                string query = "INSERT INTO teachers(name, surname, subject, class, classroom, birthday, age, sex) " +
                    "VALUES(@Name, @Surname, @Subject, @Class, @Classroom, @Birthday, @Age, @Sex)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", teacher.Name);
                command.Parameters.AddWithValue("@Surname", teacher.Surname);
                command.Parameters.AddWithValue("@Subject", teacher.Subject);
                command.Parameters.AddWithValue("@Class", teacher.Classname);
                command.Parameters.AddWithValue("@Classroom", teacher.Classroom);
                command.Parameters.AddWithValue("@Birthday", teacher.Birthday);
                command.Parameters.AddWithValue("@Age", teacher.Age);
                command.Parameters.AddWithValue("@Sex", teacher.Sex);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddTeacher - succes log - Teacher addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddTeacher - error log - Failed to add teacher");
                Console.WriteLine("DatabaseOperator - AddTeacher - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool AddTeacher(Teacher teacher, MySqlConnection connector)
        {
            try
            {
                string query = "INSERT INTO teachers(name, surname, subject, class, classroom, birthday, age, sex) " +
                    "VALUES(@Name, @Surname, @Subject, @Class, @Classroom, @Birthday, @Age, @Sex)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", teacher.Name);
                command.Parameters.AddWithValue("@Surname", teacher.Surname);
                command.Parameters.AddWithValue("@Subject", teacher.Subject);
                command.Parameters.AddWithValue("@Class", teacher.Classname);
                command.Parameters.AddWithValue("@Classroom", teacher.Classroom);
                command.Parameters.AddWithValue("@Birthday", teacher.Birthday);
                command.Parameters.AddWithValue("@Age", teacher.Age);
                command.Parameters.AddWithValue("@Sex", teacher.Sex);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddTeacher - succes log - Teacher addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddTeacher - error log - Failed to add teacher");
                Console.WriteLine("DatabaseOperator - AddTeacher - exception message - " + ex.Message);
                return false;
            }
        }

        #endregion

        #region Students

        public static bool AddStudent(string name, string surname, string classname, int birthday, int age, byte sex, int parent1, int parent2)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(classname) || birthday <= 0 || age <= 0)
                return false;

            try
            {
                connector.Open();

                string query = "INSERT INTO students(name, surname, class, birthday, age, sex, parent_1_id, parent_2_id) VALUES (@Name, @Surname, @Class, @Birthday, @Age, @Sex, @Parent1, @Parent2)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Class", classname);
                command.Parameters.AddWithValue("@Birthday", birthday);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Sex", sex);
                command.Parameters.AddWithValue("@Parent1", parent1);
                command.Parameters.AddWithValue("@Parent2", parent2);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddStudent - succes log - Student addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddStudent - error log - Failed to add student");
                Console.WriteLine("DatabaseOperator - AddStudent - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool AddStudent(Student student)
        {
            try
            {
                connector.Open();

                string query = "INSERT INTO students(name, surname, class, birthday, age, sex, parent_1_id, parent_2_id) VALUES (@Name, @Surname, @Class, @Birthday, @Age, @Sex, @Parent1, @Parent2)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Surname", student.Surname);
                command.Parameters.AddWithValue("@Class", student.Classname);
                command.Parameters.AddWithValue("@Birthday", student.Birthday);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@Sex", student.Sex);
                command.Parameters.AddWithValue("@Parent1", student.Parent_1_id);
                command.Parameters.AddWithValue("@Parent2", student.Parent_2_id);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddStudent - succes log - Student addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddStudent - error log - Failed to add student");
                Console.WriteLine("DatabaseOperator - AddStudent - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool AddStudent(Student student, MySqlConnection connector)
        {
            try
            {

                string query = "INSERT INTO students(name, surname, class, birthday, age, sex, parent_1_id, parent_2_id) VALUES (@Name, @Surname, @Class, @Birthday, @Age, @Sex, @Parent1, @Parent2)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Surname", student.Surname);
                command.Parameters.AddWithValue("@Class", student.Classname);
                command.Parameters.AddWithValue("@Birthday", student.Birthday);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@Sex", student.Sex);
                command.Parameters.AddWithValue("@Parent1", student.Parent_1_id);
                command.Parameters.AddWithValue("@Parent2", student.Parent_2_id);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddStudent - succes log - Student addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddStudent - error log - Failed to add student");
                Console.WriteLine("DatabaseOperator - AddStudent - exception message - " + ex.Message);
                return false;
            }
        }

        #endregion

        #region Parents

        public static bool AddParent(string name, string surname, int birthday, byte sex)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || birthday <= 0)
                return false;

            try
            {
                connector.Open();
                string query = "INSERT INTO parents(name, surname, birthday, sex) VALUES (@Name, @Surname, @Birthday, @Sex)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Birthday", birthday);
                command.Parameters.AddWithValue("@Sex", sex);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddParent - succes log - Parent addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddParent - error log - Failed to add Parent");
                Console.WriteLine("DatabaseOperator - AddParent - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool AddParent(Person person)
        {
            try
            {
                connector.Open();
                string query = "INSERT INTO parents(name, surname, birthday, sex) VALUES (@Name, @Surname, @Birthday, @Sex)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@Birthday", person.Birthday);
                command.Parameters.AddWithValue("@Sex", person.Sex);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddParent - succes log - Parent addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddParent - error log - Failed to add Parent");
                Console.WriteLine("DatabaseOperator - AddParent - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool AddParent(Person person, MySqlConnection connector)
        {
            try
            {
                string query = "INSERT INTO parents(name, surname, birthday, sex) VALUES (@Name, @Surname, @Birthday, @Sex)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@Birthday", person.Birthday);
                command.Parameters.AddWithValue("@Sex", person.Sex);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddParent - succes log - Parent addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddParent - error log - Failed to add Parent");
                Console.WriteLine("DatabaseOperator - AddParent - exception message - " + ex.Message);
                return false;
            }
        }

        #endregion

        #region Lessons

        public static bool AddLesson(Lesson lesson)
        {
            try
            {
                connector.Open();
                string query = "INSERT INTO lessons(name, class, classroom, teacher_id, lesson, day) VALUES (@Name, @Class, @Classroom, @Teacher_id, @Lesson, @Day)";
                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", lesson.Name);
                command.Parameters.AddWithValue("@Class", lesson.Classname);
                command.Parameters.AddWithValue("@Classroom", lesson.Classroom);
                command.Parameters.AddWithValue("@Teacher_id", lesson.Teacher_id);
                command.Parameters.AddWithValue("@Lesson", lesson.Lesson_hour);
                command.Parameters.AddWithValue("@Day", lesson.Lesson_day);
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddLesson - succes log - Lesson addded successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddLesson - error log - Failed to add lesson");
                Console.WriteLine("DatabaseOperator - AddLesson - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        #endregion

        #region Messages and Notes
        public static bool AddMessage(Message message)
        {
            try
            {
                connector.Open();

                string query = "INSERT INTO messages(author_id, school_role, single_target, single_target_id, target_school_role, group_target_id, title, content) " +
                                "VALUES (@Author_id, @School_role, @Single_target, @Single_target_id, @Target_school_role, @Group_target_id, @Title, @Content)";

                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Author_id", message.Author_id);
                command.Parameters.AddWithValue("@School_role", message.School_role);
                command.Parameters.AddWithValue("@Single_target", message.Single_target);
                command.Parameters.AddWithValue("@Single_target_id", message.Target_id);
                command.Parameters.AddWithValue("@Target_school_role", message.Target_school_role);
                command.Parameters.AddWithValue("@Group_target_id", message.Group_id);
                command.Parameters.AddWithValue("@Title", message.Title);
                command.Parameters.AddWithValue("@Content", message.Content);

                command.ExecuteNonQuery();
                connector.Close();
                Console.WriteLine("DatabaseOperator - AddMessage - success log - Message added successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddMessage - error log - Failed to add message");
                Console.WriteLine("DatabaseOperator - AddMessage - exception message - " + ex.Message);
                return false;
            }
        }

        public static bool AddGrade(string name, string description, int weight, int teacher_id, string classname, int student_id)
        {
            try
            {
                connector.Open();

                string query = "INSERT INTO grades(name, description, weight, student_id, class, teacher_id, creation_date) " +
                                "VALUES (@Name, @Description, @Weight, @Student, @Class, @Teacher, @Creation)";

                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Student", student_id);
                command.Parameters.AddWithValue("@Class", classname);
                command.Parameters.AddWithValue("@Teacher", teacher_id);
                string todayDate = DateTime.Now.ToString("yyyyMMdd");
                command.Parameters.AddWithValue("@Creation", todayDate);

                command.ExecuteNonQuery();
                connector.Close();
                Console.WriteLine("DatabaseOperator - AddGrade - success log - Grade added successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddGrade - error log - Failed to add grade");
                Console.WriteLine("DatabaseOperator - AddGrade - exception message - " + ex.Message);
                return false;
            }
        }

        public static bool AddGrade(Grade grade, MySqlConnection connector)
        {
            try
            {

                string query = "INSERT INTO grades(name, description, weight, student_id, class, teacher_id, creation_date) " +
                                "VALUES (@Name, @Description, @Weight, @Student, @Class, @Teacher, @Creation)";

                using MySqlCommand command = new(query, connector);
                command.Parameters.AddWithValue("@Name", grade.Name);
                command.Parameters.AddWithValue("@Description", grade.Description);
                command.Parameters.AddWithValue("@Weight", grade.Weight);
                command.Parameters.AddWithValue("@Student", grade.Student_id);
                command.Parameters.AddWithValue("@Class", grade.Classname);
                command.Parameters.AddWithValue("@Teacher", grade.Teacher_id);
                string todayDate = DateTime.Now.ToString("yyyyMMdd");
                command.Parameters.AddWithValue("@Creation", todayDate);

                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - AddGrade - success log - Grade added successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - AddGrade - error log - Failed to add grade");
                Console.WriteLine("DatabaseOperator - AddGrade - exception message - " + ex.Message);
                return false;
            }
        }


        #endregion

        #endregion

        #region Getters

        #region Lists

        public static List<string> GetEmails()
        {
            List<string> emails = [];
            connector.Open();
            string querry = "SELECT email FROM users ORDER BY email ASC;";
            using MySqlCommand command = new(querry, connector);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                emails.Add(reader.GetString(0));
            }
            connector.Close();
            return emails;
        }

        public static List<string> GetClassesHeaders()
        {
            List<string> headers = [];
            connector.Open();
            string querry = "SELECT class FROM teachers GROUP BY class;";
            using MySqlCommand command = new(querry, connector);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                headers.Add(reader.GetString(0));
            }
            connector.Close();
            return headers;
        }

        public static List<string> GetClassesHeaders(int teacher_id)
        {
            List<string> headers = [];
            connector.Open();
            string querry = "SELECT class FROM lessons WHERE teacher_id = @Teacher GROUP BY class;";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Teacher", teacher_id);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                headers.Add(reader.GetString(0));
            }
            connector.Close();
            return headers;
        }

        public static List<string> GetSubjects()
        {
            List<string> subjects = [];
            subjects.Add("");
            connector.Open();
            string querry = "SELECT DISTINCT subject FROM teachers;";
            using MySqlCommand command = new(querry, connector);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                subjects.Add(reader.GetString(0));
            }
            connector.Close();
            return subjects;
        }

        public static List<Message> GetMessages(int id, int role)
        {
            List<Message> messages = [];
            connector.Open();
            string querry = "SELECT m.id, m.title, m.content, GetEmail(m.author_id,m.school_role) as AuthorEmail, GetEmail(m.single_target_id,m.target_school_role) as TargetInfo, m.group_target_id " +
                "FROM messages m INNER JOIN users u ON m.author_id = u.school_role_id " +
                "WHERE(m.single_target = 1 AND m.author_id = @Id AND m.school_role = @Role) " +
                "OR (m.single_target = 1 AND m.single_target_id = @Id AND target_school_role = @Role) GROUP BY m.id;";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Role", role);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                messages.Add(new Message
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Content = reader.GetString("content"),
                    AuthorEmail = reader.GetString("AuthorEmail"),
                    TargetInfo = reader.GetString("TargetInfo")
                });
            }
            connector.Close(); 
            foreach (Message message in messages)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(message.Id);
                Console.WriteLine(message.Title);
                Console.WriteLine(message.Content);
                Console.WriteLine(message.AuthorEmail);
                Console.WriteLine(message.TargetInfo);
            }
            return messages;
        }

        public static List<Message> GetMessages(string classname)
        {
            List<Message> messages = [];
            connector.Open();
            string querry = "SELECT m.id, m.title, m.content, u.email AS AuthorEmail, m.group_target_id AS TargetInfo " +
                "FROM messages m JOIN users u ON m.author_id = u.id WHERE m.group_target_id = @Classname";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Classname", classname);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                messages.Add(new Message
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Content = reader.GetString("content"),
                    AuthorEmail = reader.GetString("AuthorEmail"),
                    TargetInfo = reader.GetString("TargetInfo")
                });
            }
            connector.Close();
            return messages;
        }

        public static List<Person> GetParents()
        {
            List<Person> people = [];
            connector.Open();
            string querry = "SELECT id, name, surname, birthday, sex FROM parents";
            using MySqlCommand command = new(querry, connector);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Birthday = reader.GetInt32(3),
                    Sex = reader.GetByte(4)
                });
            }
            connector.Close();
            return people;
        }

        public static List<Student> GetStudents()
        {
            List<Student> people = [];
            connector.Open();
            string querry = "SELECT id, name, surname, class, birthday, age, sex, parent_1_id, parent_2_id FROM students";
            using MySqlCommand command = new(querry, connector);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Classname = reader.GetString(3),
                    Birthday = reader.GetInt32(4),
                    Age = reader.GetInt32(5),
                    Sex = reader.GetByte(6),
                    Parent_1_id = reader.GetInt32(7),
                    Parent_2_id = reader.GetInt32(8)
                });
            }
            connector.Close();
            return people;
        }

        public static List<Student> GetStudents(string classname)
        {
            List<Student> people = [];
            connector.Open();
            string querry = "SELECT id, name, surname, class, birthday, age, sex, parent_1_id, parent_2_id FROM students WHERE class = @Class";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Class", classname);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Classname = reader.GetString(3),
                    Birthday = reader.GetInt32(4),
                    Age = reader.GetInt32(5),
                    Sex = reader.GetByte(6),
                    Parent_1_id = reader.GetInt32(7),
                    Parent_2_id = reader.GetInt32(8)
                });
            }
            connector.Close();
            return people;
        }

        public static List<Teacher> GetTeachers()
        {
            List<Teacher> people = [];
            connector.Open();
            string querry = "SELECT id, name, surname, subject, class, classroom, birthday, age, sex FROM teachers";
            using MySqlCommand command = new(querry, connector);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Teacher
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Subject = reader.GetString(3),
                    Classname = reader.GetString(4),
                    Classroom = reader.GetInt32(5),
                    Birthday = reader.GetInt32(6),
                    Age = reader.GetInt32(7),
                    Sex = reader.GetByte(8)
                });
            }
            connector.Close();
            return people;
        }

        public static List<Admin> GetAdmins()
        {
            List<Admin> people = [];
            connector.Open();
            string querry = "SELECT id, email, password FROM users WHERE school_role=0";
            using MySqlCommand command = new(querry, connector);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Admin
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Password = reader.GetString(2)
                });
            }
            connector.Close();
            return people;
        }

        public static List<Class_data> GetClasses()
        {
            List<Class_data> classes = [];
            connector.Open();
            string querry = "SELECT t.class AS Classname, t.classroom AS Classroom, t.name AS HomeroomTeacher_name, t.surname AS HomeroomTeacher_surname, COUNT(s.id) AS Students_number " +
                "FROM teachers t " +
                "LEFT JOIN students s ON t.class = s.class " +
                "WHERE t.class IS NOT NULL AND t.class != '' " +
                "GROUP BY t.class, t.classroom, t.name, t.surname;";
            using MySqlCommand command = new(querry, connector);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                classes.Add(new Class_data
                {
                    Classname = reader.GetString(0),
                    Classroom = reader.GetInt32(1),
                    HomeroomTeacher_name = reader.GetString(2),
                    HomeroomTeacher_surname = reader.GetString(3),
                    Students_number = reader.GetInt32(4)
                });
            }
            connector.Close();
            return classes;
        }

        public static List<Lesson> GetLessons(string classname)
        {
            List<Lesson> classes = [];
            connector.Open();
            string querry = "SELECT * FROM lessons WHERE class=@Classname;";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Classname", classname);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                classes.Add(new Lesson
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Classname = reader.GetString(2),
                    Classroom = reader.GetInt32(3),
                    Teacher_id = reader.GetInt32(4),
                    Lesson_hour = reader.GetInt32(5),
                    Lesson_day = reader.GetInt32(6)
                });
            }
            connector.Close();
            return classes;
        }

        public static List<Lesson> GetLessons(int teacher_id)
        {
            List<Lesson> classes = [];
            connector.Open();
            string querry = "SELECT * FROM lessons WHERE teacher_id=@Teacher;";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Teacher", teacher_id);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                classes.Add(new Lesson
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Classname = reader.GetString(2),
                    Classroom = reader.GetInt32(3),
                    Teacher_id = reader.GetInt32(4),
                    Lesson_hour = reader.GetInt32(5),
                    Lesson_day = reader.GetInt32(6)
                });
            }
            connector.Close();
            return classes;
        }

        public static List<Grade> GetGrades(string classname, int teacher_id)
        {
            List<Grade> classes = [];
            connector.Open();
            string querry = "SELECT id, name, description, grade, weight, student_id, class, GetFullName(student_id), teacher_id, creation_date " +
                "FROM grades g WHERE class = @Classname AND teacher_id = @Teacher;";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Classname", classname);
            command.Parameters.AddWithValue("@Teacher", teacher_id);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                classes.Add(new Grade
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Mark = reader.GetString(3),
                    Weight = reader.GetInt32(4),
                    Student_id = reader.GetInt32(5),
                    Classname = reader.GetString(6),
                    Student_name = reader.GetString(7),
                    Teacher_id = reader.GetInt32(8),
                    Creation_date = reader.GetInt32(9)
                });
            }
            connector.Close();
            return classes;
        }

        #endregion

        #region IDs
        public static int GetParentId(string name, string surname, int birthday)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || birthday <= 0)
                return -1;

            try
            {
                connector.Open();
                string querry = "SELECT id FROM parents WHERE name=@Name AND surname=@Surname AND birthday=@Birthday";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Birthday", birthday);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetParentId - success log - Parent id retrieved successfully");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetParentId - error log - Parent not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetParentId - error log - Failed to retriev id");
                Console.WriteLine("DatabaseOperator - GetParentId - exception message - " + ex.Message);
                return -1;
            }
        }

        public static int GetUserId(string email, int school_id, int school_role)
        {
            if (string.IsNullOrEmpty(email) || school_id <= 0 || school_role <= 0)
                return -1;

            try
            {
                connector.Open();
                string querry = "SELECT id FROM users WHERE email=@Email AND school_role=@School_role AND school_role_id=@School_id";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@School_role", school_role);
                command.Parameters.AddWithValue("@School_id", school_id);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetUserId 1 - success log - user id retrieved successfully");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetUserId 1 - error log - User not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetUserId 1 - error log - Failed to retriev id");
                Console.WriteLine("DatabaseOperator - GetUserId 1 - exception message - " + ex.Message);
                return -1;
            }
        }

        public static int GetUserId(string email, int school_role)
        {
            if (string.IsNullOrEmpty(email) || school_role < 0)
                return -1;

            try
            {
                connector.Open();
                string querry = "SELECT school_role_id FROM users WHERE email=@Email AND school_role=@School_role";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@School_role", school_role);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetUserId 2 - success log - User id retrieved successfully");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetUserId 2 - error log - User not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetUserId 2 - error log - Failed to retriev id");
                Console.WriteLine("DatabaseOperator - GetUserId 2 - exception message - " + ex.Message);
                return -1;
            }
        }

        public static int GetUserId(string email)
        {
            if (string.IsNullOrEmpty(email))
                return -1;

            try
            {
                connector.Open();
                string querry = "SELECT id FROM users WHERE email=@Email";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Email", email);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetUserId 3 - success log - User id retrieved successfully");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetUserId 3 - error log - User not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetUserId 3- error log - Failed to retriev id");
                Console.WriteLine("DatabaseOperator - GetUserId 3 - exception message - " + ex.Message);
                return -1;
            }
        }

        public static int GetAdminId(string email)
        {
            if (string.IsNullOrEmpty(email))
                return -1;

            try
            {
                connector.Open();
                string querry = "SELECT id FROM users WHERE email=@Email AND school_role=@School_role";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@School_role", 0);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetAdminId - success log - Admin id retrieved successfully");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetAdminId - error log - Admin not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetUserId - error log - Failed to retriev id");
                Console.WriteLine("DatabaseOperator - GetUserId - exception message - " + ex.Message);
                return -1;
            }
        }

        public static int GetLastAdminId()
        {
            try
            {
                connector.Open();
                string querry = "SELECT school_role_id FROM users WHERE school_role = 0 ORDER BY school_role_id DESC LIMIT 1";
                using MySqlCommand command = new(querry, connector);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetLastAdminId - success log - Admin id retrieved successfully");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetLastAdminId - error log - Admin not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetLastAdminId - error log - Failed to retriev id");
                Console.WriteLine("DatabaseOperator - GetLastAdminId - exception message - " + ex.Message);
                return -1;
            }
        }

        public static int GetStudentId(string name, string surname, int birthday)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || birthday <= 0)
                return -1;

            try
            {
                connector.Open();
                string querry = "SELECT id FROM students WHERE name=@Name AND surname=@Surname AND birthday=@Birthday";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Birthday", birthday);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetStudentId - success log - Student id retrieved successfully");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetStudentId - error log - Student not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetStudentId - error log - Failed to retriev id");
                Console.WriteLine("DatabaseOperator - GetStudentId - exception message - " + ex.Message);
                return -1;
            }
        }

        public static int GetTeacherId(string name, string surname, int birthday)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || birthday <= 0)
                return -1;

            try
            {
                connector.Open();
                string querry = "SELECT id FROM teachers WHERE name=@Name AND surname=@Surname AND birthday=@Birthday";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Birthday", birthday);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetTeacherId - success log - Teacher id retrieved successfully");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetTeacherId - error log - Teacher not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetTeacherId - error log - Failed to retriev id");
                Console.WriteLine("DatabaseOperator - GetTeacherId - exception message - " + ex.Message);
                return -1;
            }
        }

        public static string GetClassnameParent(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                connector.Open();
                string querry = "SELECT class FROM students WHERE parent_1_id = @Id OR parent_2_id = @Id";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Id", id);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    Console.WriteLine("DatabaseOperator - GetClassnameParent - success log - Classname retrieved successfully");
                    return result.ToString();
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetClassnameParent - error log - Class not found in database");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetClassnameParent - error log - Failed to retriev classname");
                Console.WriteLine("DatabaseOperator - GetClassnameParent - exception message - " + ex.Message);
                return null;
            }
        }

        public static string GetClassnameStudent(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                connector.Open();
                string querry = "SELECT class FROM students WHERE id = @Id";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Id", id);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    Console.WriteLine("DatabaseOperator - GetClassnameStudent - success log - Classname retrieved successfully");
                    return result.ToString();
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetClassnameStudent - error log - Class not found in database");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetClassnameStudent - error log - Failed to retriev classname");
                Console.WriteLine("DatabaseOperator - GetClassnameStudent - exception message - " + ex.Message);
                return null;
            }
        }

        public static string GetClassnameTeacher(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                connector.Open();
                string querry = "SELECT class FROM teachers WHERE id = @Id";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Id", id);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    Console.WriteLine("DatabaseOperator - GetClassnameTeacher - success log - Classname retrieved successfully");
                    return result.ToString();
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetClassnameTeacher - error log - Class not found in database");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetClassnameTeacher - error log - Failed to retriev classname");
                Console.WriteLine("DatabaseOperator - GetClassnameTeacher - exception message - " + ex.Message);
                return null;
            }
        }

        #endregion

        #region Objects

        public static Teacher GetTeacher(string email, string password)
        {
            connector.Open();
            string querry = "SELECT t.* FROM teachers t JOIN users u ON u.school_role_id = t.id WHERE u.email = @Email AND u.password = @Password AND u.school_role = 1;";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", HashPassword(password));

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                Teacher teacher = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Subject = reader.GetString(3),
                    Classname = reader.GetString(4),
                    Classroom = reader.GetInt32(5),
                    Birthday = reader.GetInt32(6),
                    Age = reader.GetInt32(7),
                    Sex = reader.GetByte(8)
                };
                connector.Close();
                return teacher;
            }
            else
            {
                connector.Close();
                return null;
            }
        }

        public static Student GetStudent(string email, string password)
        {
            connector.Open();
            string querry = "SELECT s.* FROM students s JOIN users u ON u.school_role_id = s.id WHERE u.email = @Email AND u.password = @Password AND u.school_role = 2;";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", HashPassword(password));

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                Student student = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Classname = reader.GetString(3),
                    Birthday = reader.GetInt32(4),
                    Age = reader.GetInt32(5),
                    Sex = reader.GetByte(6),
                    Parent_1_id = reader.GetInt32(7),
                    Parent_2_id = reader.GetInt32(8)
                };
                connector.Close();
                return student;
            }
            else
            {
                connector.Close();
                return null;
            }
        }

        public static Person GetPerson(string email, string password)
        {
            connector.Open();
            string querry = "SELECT p.* FROM parents p JOIN users u ON u.school_role_id = p.id WHERE u.email = @Email AND u.password = @Password AND u.school_role = 3;";
            using MySqlCommand command = new(querry, connector);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", HashPassword(password));

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                Person parent = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Birthday = reader.GetInt32(3),
                    Sex = reader.GetByte(4)
                };
                connector.Close();
                return parent;
            }
            else
            {
                connector.Close();
                return null;
            }
        }


        #endregion

        #region Other

        public static int GetClassroom(int id)
        {
            try
            {
                connector.Open();
                string querry = "SELECT classroom FROM teachers WHERE id = @Id";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Id", id);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    Console.WriteLine("DatabaseOperator - GetClassroom - success log - Classroom number retrieved successfully");
                    return Convert.ToInt32(result);
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetClassroom - error log - Classroom not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetClassroom - error log - Failed to retriev classroom number");
                Console.WriteLine("DatabaseOperator - GetClassroom - exception message - " + ex.Message);
                return -1;
            }
        }

        public static string GetParentName(int id)
        {
            try
            {
                connector.Open();
                string querry = "SELECT CONCAT(name, ' ', surname) AS full_name FROM parents WHERE id = @Id;";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Id", id);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    Console.WriteLine("DatabaseOperator - GetParentName - success log - Parent full name retrieved successfully");
                    return result.ToString();
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetParentName - error log - Parent not found in database");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetParentName - error log - Failed to retriev parent name");
                Console.WriteLine("DatabaseOperator - GetParentName - exception message - " + ex.Message);
                return null;
            }
        }

        public static int GetLessonsCount(int Teacher_id)
        {
            try
            {
                connector.Open();
                string querry = "SELECT COUNT(*) AS total_lessons FROM lessons WHERE teacher_id = @TeacherId;";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@TeacherId", Teacher_id);

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    Console.WriteLine("DatabaseOperator - GetLessonsCount - success log - Lessons number retrieved successfully");
                    return Convert.ToInt32(result);
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetLessonsCount - error log - Teacger not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetLessonsCount - error log - Failed to retriev lessons number");
                Console.WriteLine("DatabaseOperator - GetLessonsCount - exception message - " + ex.Message);
                return -1;
            }
        }

        #endregion

        #endregion

        #region Updaters

        public static void UpdateUser(int school_role, int school_role_id, string email, string password)
        {
            try
            {
                connector.Open();

                string query = @"UPDATE users SET email = @Email, password = @Password WHERE school_role = @SchoolRole AND school_role_id = @SchoolRoleId;";

                using var command = new MySqlCommand(query, connector);
                command.Parameters.AddWithValue("@SchoolRole", school_role);
                command.Parameters.AddWithValue("@SchoolRoleId", school_role_id);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", HashPassword(password));
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    AddUser(school_role, school_role_id, email, password, connector);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user: " + ex.Message);
            }
            finally
            {
                connector.Close();
            }
        }

        public static void UpdateAdmin(Admin admin)
        {
            try
            {
                connector.Open();

                string query = @"UPDATE users SET email = @Email, password = @Password WHERE id = @Id;";

                using var command = new MySqlCommand(query, connector);
                command.Parameters.AddWithValue("@Id", admin.Id);
                command.Parameters.AddWithValue("@Email", admin.Email);
                command.Parameters.AddWithValue("@Password", admin.Password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    AddUser(admin, connector);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating admin: " + ex.Message);
            }
            finally
            {
                connector.Close();
            }
        }

        public static void UpdateTeacher(Teacher teacher)
        {
            try
            {
                connector.Open();

                string query = @"UPDATE teachers SET name = @Name, surname = @Surname, subject = @Subject, class = @Class, classroom = @Classroom, birthday = @Birthday, age = @Age, sex = @Sex WHERE id = @Id;";

                using var command = new MySqlCommand(query, connector);
                command.Parameters.AddWithValue("@Id", teacher.Id);
                command.Parameters.AddWithValue("@Name", teacher.Name);
                command.Parameters.AddWithValue("@Surname", teacher.Surname);
                command.Parameters.AddWithValue("@Subject", teacher.Subject);
                command.Parameters.AddWithValue("@Class", teacher.Classname);
                command.Parameters.AddWithValue("@Classroom", teacher.Classroom);
                command.Parameters.AddWithValue("@Birthday", teacher.Birthday);
                command.Parameters.AddWithValue("@Age", teacher.Age);
                command.Parameters.AddWithValue("@Sex", teacher.Sex);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    AddTeacher(teacher, connector);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating teacher: " + ex.Message);
            }
            finally
            {
                connector.Close();
            }
        }

        public static void UpdateStudent(Student student)
        {
            try
            {
                connector.Open();

                string query = @"UPDATE students SET name = @Name, surname = @Surname, class = @Class, birthday = @Birthday, age = @Age, sex = @Sex, parent_1_id = @Parent1, parent_2_id = @Parent2
                WHERE id = @Id;";

                using var command = new MySqlCommand(query, connector);
                command.Parameters.AddWithValue("@Id", student.Id);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Surname", student.Surname);
                command.Parameters.AddWithValue("@Class", student.Classname);
                command.Parameters.AddWithValue("@Birthday", student.Birthday);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@Sex", student.Sex);
                command.Parameters.AddWithValue("@Parent1", student.Parent_1_id);
                command.Parameters.AddWithValue("@Parent2", student.Parent_2_id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    AddStudent(student, connector);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating student: " + ex.Message);
            }
            finally
            {
                connector.Close();
            }
        }

        public static void UpdateParent(Person person)
        {
            try
            {
                connector.Open();

                string query = @"UPDATE parents SET name = @Name, surname = @Surname, birthday = @Birthday, sex = @Sex
                WHERE id = @Id;";

                using var command = new MySqlCommand(query, connector);
                command.Parameters.AddWithValue("@Id", person.Id);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@Birthday", person.Birthday);
                command.Parameters.AddWithValue("@Sex", person.Sex);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    AddParent(person, connector);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating parent: " + ex.Message);
            }
            finally
            {
                connector.Close();
            }
        }

        public static void UpdateGrade(Grade grade)
        {
            try
            {
                connector.Open();

                string query = "UPDATE grades SET grade = @Grade, creation_date = @Date WHERE id = @Id;";

                using var command = new MySqlCommand(query, connector);
                command.Parameters.AddWithValue("@Id", grade.Id);
                command.Parameters.AddWithValue("@Grade", grade.Mark); 
                string todayDate = DateTime.Now.ToString("yyyyMMdd");
                command.Parameters.AddWithValue("@Date", todayDate);


                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    AddGrade(grade, connector);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating grade: " + ex.Message);
            }
            finally
            {
                connector.Close();
            }
        }

        #endregion

        #region Uncategorized

        public static bool CheckLessons(Lesson lesson)
        {
            try
            {
                connector.Open();
                string query = "SELECT COUNT(*) FROM lessons WHERE class != @Class AND classroom = @Classroom AND teacher_id = @Teacher AND lesson = @Lesson AND day = @Day";

                using MySqlCommand command = new(query, connector);
                Console.WriteLine("Parameters - database operator");
                Console.WriteLine("Class " + lesson.Classname);
                Console.WriteLine("Classroom " + lesson.Classroom);
                Console.WriteLine("Teacher " + lesson.Teacher_id);
                Console.WriteLine("Day " + lesson.Lesson_day);
                Console.WriteLine("Hours " + lesson.Lesson_hour);
                Console.WriteLine("-------------------------");

                command.Parameters.AddWithValue("@Class", lesson.Classname);
                command.Parameters.AddWithValue("@Classroom", lesson.Classroom);
                command.Parameters.AddWithValue("@Teacher", lesson.Teacher_id);
                command.Parameters.AddWithValue("@Lesson", lesson.Lesson_hour);
                command.Parameters.AddWithValue("@Day", lesson.Lesson_day);

                int count = Convert.ToInt32(command.ExecuteScalar());
                
                bool tmp = count == 0;
                Console.WriteLine("Method outcome " + tmp);
                return tmp;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - Login - error log - Failed to check lesson");
                Console.WriteLine("DatabaseOperator - Login - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static bool Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return false;

            Console.WriteLine(HashPassword(password));


            try
            {
                connector.Open();
                string querry = "SELECT id FROM users WHERE email = @Login AND password = @Password";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", HashPassword(password));

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("DatabaseOperator - Login - succes log - Logged in successfully");
                    connector.Close();
                    return true;
                }
                connector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - Login - error log - Failed to log in");
                Console.WriteLine("DatabaseOperator - Login - exception message - " + ex.Message);
                return false;
            }
            connector.Close();
            return false;
        }

        public static int GetRole(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return -1;

            try
            {
                connector.Open();
                string querry = "SELECT school_role FROM users WHERE email = @Login AND password = @Password";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", HashPassword(password));

                object result = command.ExecuteScalar();
                connector.Close();
                if (result != null && result != DBNull.Value)
                {
                    int id = Convert.ToInt32(result);
                    Console.WriteLine("DatabaseOperator - GetRole - success log - Loged in successfuly");
                    return id;
                }
                else
                {
                    Console.WriteLine("DatabaseOperator - GetRole - error log - User not found in database");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - GetRole - error log - Failed to log in");
                Console.WriteLine("DatabaseOperator - GetRole - exception message - " + ex.Message);
                return -1;
            }
        }

        public static string HashPassword(string input)
        {
            return BitConverter.ToString(Sha3.Sha3256().ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", "").ToLower();
        }

        #endregion
    }
}