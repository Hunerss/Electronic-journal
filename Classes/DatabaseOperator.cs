

using MySqlConnector;
using Org.BouncyCastle.Crypto.Digests;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace Electronic_journal.Classes
{
    internal class DatabaseOperator
    {
        private static string db_adress = "SERVER=localhost;DATABASE=electronic_journal;UID=root;PASSWORD=;ConvertZeroDateTime=True;";
        private static MySqlConnection connector = new(db_adress);

        public Boolean Register(int school_role, int school_role_id, string name, string surname, string email, string password)
        {
            if (school_role <= -1 || school_role_id <= -1 || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;

            if (!CheckPassword(password))
                return false;

            try
            {
                connector.Open();
                string querry = "INSERT INTO users(school_role, school_role_id, name, surname, email, password) " +
                                "VALUES(@SchoolRole, @SchoolRoleId, @Name, @Surname, @Email, @Password)";
                using MySqlCommand command = new(querry, connector);
                command.Parameters.AddWithValue("@SchoolRole", school_role);
                command.Parameters.AddWithValue("@SchoolRoleId", school_role_id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", ComputeSha3_256Hash(password));
                Console.WriteLine(BitConverter.ToString(ComputeSha3_256Hash(password)).Replace("-", "").ToLower());
                command.ExecuteNonQuery();
                Console.WriteLine("DatabaseOperator - Register - succes log - Registered successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseOperator - Register - error log - Failed to register");
                Console.WriteLine("DatabaseOperator - Register - exception message - " + ex.Message);
                return false;
            }
            finally
            {
                connector.Close();
            }
        }

        public static byte[] ComputeSha3_256Hash(string input)
        {
            return SHA3_256.HashData(Encoding.UTF8.GetBytes(input));
        }

        private static Boolean CheckPassword(string password)
        {
            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsPunctuation))
                return false;

            if (!password.Any(char.IsLower))
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            return true;
        }
    }
}

//namespace ToDoList.classes
//{
//    class DatabaseOperator
//    {
//        private static string db_adress = "SERVER=localhost;DATABASE=electronic_journal;UID=root;PASSWORD=;ConvertZeroDateTime=True;";
//        private static MySqlConnection connector = new(db_adress);
//        // admin password admin in sha3-512

//        public static void ShowScores(ListBox listBox)
//        {
//            try
//            {
//                using MySqlConnection connection = new MySqlConnection(db_adress);
//                connection.Open();
//                string query = "SELECT u.login, w.game, w.win, w.date FROM wins w JOIN users u ON w.user_id = u.id ORDER BY w.id DESC";
//                MySqlCommand command = new(query, connection);
//                MySqlDataReader reader = command.ExecuteReader();

//                listBox.Items.Clear();
//                while (reader.Read())
//                {
//                    string username = reader.GetString(0);
//                    int gameId = reader.GetInt32(1);
//                    int winAmount = reader.GetInt32(2);
//                    DateTime winDate = reader.GetDateTime(3);

//                    string gameName = InterpretGameById(gameId);

//                    string formattedData = $"{username} - {gameName} - Amount: {winAmount} - Date: {winDate}";

//                    listBox.Items.Add(formattedData);
//                }

//                reader.Close();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error occurred while retrieving data: " + ex.Message);
//            }
//        }

//        private static string InterpretGameById(int gameId)
//        {
//            switch (gameId)
//            {
//                case 1:
//                    return "Blackjack";
//                case 2:
//                    return "Roulette";
//                case 3:
//                    return "Slot Machine";
//                default:
//                    return "Unknown";
//            }
//        }

//        private Boolean ModifyChips(int id, int change)
//        {
//            if (id < 0) return false;
//            try
//            {
//                connector.Open();
//                string query = "UPDATE users SET chips=@Chips WHERE id = @Id";
//                using MySqlCommand command = new(query, connector);
//                command.Parameters.AddWithValue("@Chips", change);
//                command.Parameters.AddWithValue("@Id", id);
//                command.ExecuteNonQuery();

//                Console.WriteLine("DatabaseOperator - ModifyChips - succes log - Chips amount modified successfully");
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("DatabaseOperator - ModifyChips - error log - Failed to modify chips amount");
//                Console.WriteLine("DatabaseOperator - ModifyChips - exception message - " + ex.Message);
//                return false;
//            }
//            finally
//            {
//                connector.Close();
//            }
//        }

//        public Boolean UpdateChips(string login, int change)
//        {
//            if (string.IsNullOrEmpty(login))
//                return false;

//            try
//            {
//                connector.Open();
//                string getUserIdQuery = "SELECT id FROM users WHERE login=@Login";
//                using MySqlCommand getUserIdCommand = new MySqlCommand(getUserIdQuery, connector);
//                getUserIdCommand.Parameters.AddWithValue("@Login", login);
//                object userIdObj = getUserIdCommand.ExecuteScalar();

//                if (userIdObj == null || userIdObj == DBNull.Value)
//                {
//                    Console.WriteLine("DatabaseOperator - UpdateChips - error log - User with specified login not found");
//                    return false;
//                }

//                int userId = Convert.ToInt32(userIdObj);

//                string updateChipsQuery = "UPDATE users SET chips=chips+@Chips WHERE id = @Id";
//                using MySqlCommand updateChipsCommand = new MySqlCommand(updateChipsQuery, connector);
//                updateChipsCommand.Parameters.AddWithValue("@Chips", change);
//                updateChipsCommand.Parameters.AddWithValue("@Id", userId);
//                updateChipsCommand.ExecuteNonQuery();

//                Console.WriteLine("DatabaseOperator - UpdateChips - success log - Chips amount updated successfully");
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("DatabaseOperator - UpdateChips - error log - Failed to update chips amount");
//                Console.WriteLine("DatabaseOperator - UpdateChips - exception message - " + ex.Message);
//                return false;
//            }
//            finally
//            {
//                connector.Close();
//            }
//        }

//        public int GetChips(string login)
//        {
//            if (string.IsNullOrEmpty(login))
//                return -1;

//            try
//            {
//                connector.Open();
//                string query = "SELECT chips FROM users WHERE login = @Login";
//                using MySqlCommand command = new MySqlCommand(query, connector);
//                command.Parameters.AddWithValue("@Login", login);
//                object result = command.ExecuteScalar();
//                if (result != null && result != DBNull.Value)
//                {
//                    int chips = Convert.ToInt32(result);
//                    Console.WriteLine("DatabaseOperator - GetChips - success log - User chips retrieved successfully");
//                    return chips;
//                }
//                else
//                {
//                    Console.WriteLine("DatabaseOperator - GetChips - error log - User not found in database");
//                    return -1;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("DatabaseOperator - GetChips - error log - Failed to retrieve user chips");
//                Console.WriteLine("DatabaseOperator - GetChips - exception message - " + ex.Message);
//                return -1;
//            }
//            finally
//            {
//                connector.Close();
//            }
//        }

//        public Boolean Add(string login, int game, int win)
//        {
//            if (string.IsNullOrEmpty(login) || game > 3)
//                return false;

//            try
//            {
//                connector.Open();
//                string query1 = "SELECT id FROM users WHERE login=@Login";
//                using MySqlCommand command1 = new(query1, connector);
//                command1.Parameters.AddWithValue("@Login", login);
//                int userId = Convert.ToInt32(command1.ExecuteScalar());
//                if (userId > 0 || userId == -1)
//                {
//                    string query2 = "INSERT INTO wins(user_id, game, win) VALUES (@UserId, @Game, @Win)";
//                    using MySqlCommand command2 = new(query2, connector);
//                    command2.Parameters.AddWithValue("@UserId", userId);
//                    command2.Parameters.AddWithValue("@Game", game);
//                    command2.Parameters.AddWithValue("@Win", win);
//                    command2.ExecuteNonQuery();
//                    Console.WriteLine("DatabaseOperator - Add - succes log - Win addded successfully");
//                    ModifyChips(userId, win);
//                    return true;
//                }
//                else
//                {
//                    Console.WriteLine("DatabaseOperator - Add - error log - Error occured when adding the Win");
//                    return false;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("DatabaseOperator - Add - error log - Failed to add Win");
//                Console.WriteLine("DatabaseOperator - Add - exception message - " + ex.Message);
//                return false;
//            }
//            finally
//            {
//                connector.Close();
//            }
//        }

//        public Boolean Login(string login, string password)
//        {
//            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
//                return false;

//            try
//            {
//                connector.Open();
//                string querry = "SELECT id FROM users WHERE login = @Login AND password = @Password";
//                using MySqlCommand command = new(querry, connector);
//                command.Parameters.AddWithValue("@Login", login);
//                command.Parameters.AddWithValue("@Password", HashPassword(password));

//                using var reader = command.ExecuteReader();
//                if (reader.Read())
//                {
//                    Console.WriteLine("DatabaseOperator - Login - succes log - Logged in successfully");
//                    connector.Close();
//                    return true;
//                }
//                connector.Close();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("DatabaseOperator - Login - error log - Failed to log in");
//                Console.WriteLine("DatabaseOperator - Login - exception message - " + ex.Message);
//                return false;
//            }
//            connector.Close();
//            return false;
//        }

//        private int ReturnAge(DateTime birthday)
//        {
//            DateTime now = DateTime.Today;
//            int age = now.Year - birthday.Year;
//            if (now < birthday.AddYears(age))
//            {
//                age--;
//            }
//            return age;
//        }

//        
//        
//        
//        

//        
//        

//        
//        

//        
//        

//        
//        

//        
//        
//    }
//}
