using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

namespace Importer
{
    class UsersInfo
    {

        public static void Users()
        {
            Console.Clear();
            Console.WriteLine("Please enter a link to the file you want to upload.");


            try
            {
            
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString.ToString();

           using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            var lineNumber = 0;

            string fileName = Console.ReadLine();

                using (StreamReader reader = new StreamReader(fileName))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (lineNumber != 0)
                        {
                            var values = line.Split(',');

                        //var sql = "INSERT INTO Info.UserInfo VALUES(@DebtType, @AccNum, @AccName, @DOB, @Balance, @Email, @Phone, @Addr1, @Addr2, @Addr3, @Postcode, @UserInfoID)";

                        var sql = "INSERT INTO Info.UserInfo(DebtType, AccNum, AccName, DOB, Balance, Email, Phone, Addr1, Addr2, Addr3, Postcode)"
                            + "VALUES(@DebtType, @AccNum, @AccName, @DOB, @Balance, @Email, @Phone, @Addr1, @Addr2, @Addr3, @Postcode)"
                            + "SELECT SCOPE_IDENTITY()";

                        var cmd = new SqlCommand
                            {
                                CommandText = sql,
                                CommandType = System.Data.CommandType.Text,
                                Connection = con
                            };
                            cmd.Parameters.AddWithValue("@DebtType", values[0]);

                            DateTime resultDT = DateTime.Now;
                            bool isConverted = DateTime.TryParse(values[3].ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-gb"), DateTimeStyles.None, out resultDT);

                            if (!isConverted)
                                resultDT = DateTime.ParseExact(values[3].ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-us"));

                            cmd.Parameters.AddWithValue("@AccNum", values[1]);
                            cmd.Parameters.AddWithValue("@AccName", values[2]);
                            cmd.Parameters.AddWithValue("@DOB", resultDT);
                            cmd.Parameters.AddWithValue("@Balance", values[4]);
                            cmd.Parameters.AddWithValue("@Email", values[5]);
                            cmd.Parameters.AddWithValue("@Phone", values[6]);
                            cmd.Parameters.AddWithValue("@Addr1", values[7]);
                            cmd.Parameters.AddWithValue("@Addr2", values[8]);
                            cmd.Parameters.AddWithValue("@Addr3", values[9]);
                            cmd.Parameters.AddWithValue("@Postcode", values[10]);
                    

                            cmd.ExecuteNonQuery();

                        }
                        lineNumber++;
                    }
                }
                         
        

                 Console.WriteLine("Users Import Complete");
            }

            catch (FileNotFoundException fileEx)
            {
                Console.WriteLine("No file found, Please enter a file path and correct file please.");
            }


            catch (ArgumentException)
            {
                Console.WriteLine("Can't find file path, Please enter a valid file directory");
            }

         

            Console.WriteLine();
            Console.ReadLine();
        }

        
    }
}
