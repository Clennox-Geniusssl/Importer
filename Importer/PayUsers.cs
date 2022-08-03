using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace Importer
{
    public class PayUsers
    {
        public static void Pay()
        {
            Console.Clear();
            Console.WriteLine("Please enter a link to the file you want to upload.");

            try
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString.ToString();

                using  (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                var lineNumber = 0;

                string fileName = Console.ReadLine();

                    using StreamReader reader = new StreamReader(fileName);
                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        if (lineNumber != 0)
                        {
                            string path = (reader.BaseStream as FileStream).Name;
                            var values = line.Split(',');

                            var sql = "INSERT INTO Info.PayInfo (AdeptRef, Amount, EffectiveDate, Source, Method, Comment, UserInfoID)"
                                + "VALUES (@AdeptRef, @Amount, @EffectiveDate, @Source, @Method, @Comment, @UserInfoID)"
                                + "SELECT SCOPE_IDENTITY()";


                            var cmd = new SqlCommand
                            {
                                CommandText = sql,
                                CommandType = System.Data.CommandType.Text,
                                Connection = con
                            };

                            cmd.Parameters.AddWithValue("@AdeptRef", values[0]);

                            bool isNumber = float.TryParse(values[1], out float amount);

                            DateTime resultDT = DateTime.Now;
                            bool isConverted = DateTime.TryParse(values[2].ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-gb"), DateTimeStyles.None, out resultDT);

                            if (!isConverted)
                                resultDT = DateTime.ParseExact(values[2].ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-us"));

                            cmd.Parameters.AddWithValue("@Amount", amount);
                            cmd.Parameters.AddWithValue("@EffectiveDate", resultDT);
                            cmd.Parameters.AddWithValue("@Source", values[3]);
                            cmd.Parameters.AddWithValue("@Method", values[4]);
                            cmd.Parameters.AddWithValue("@Comment", values[5]);
                            cmd.Parameters.AddWithValue("@UserInfoID", values[7]);

                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;
                    }
                }

                Console.WriteLine("Payments Import Complete");
            }

            catch (FileNotFoundException)
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
    