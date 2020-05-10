using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Carlson_Alicia_DatabaseReview
{
    class Program
    {
        //Declaring the MySqlConnection variable
        MySqlConnection _con = null;

        static void Main(string[] args)
        {
            //Initailizing an instance of the program to reduce static code use
            Program instance = new Program();

            //Initializing a new instance of MySqlConnection
            instance._con = new MySqlConnection();

            //calling the connect function to connect to the database
            instance.Connect();

            Console.WriteLine("Conection Successful!");
            Console.ReadKey();

        }

        void Connect()
        {
            //Calling the build string function to assign the connection string
            BuildConString();
            //try to open the connection
            try
            {
                _con.Open();
            }
            //catch to handle any exceptions throughn if unable to connect
            catch(MySqlException e)
            {
                string msg = "";
                switch (e.Number)
                {
                    case 0:
                        {
                            msg = e.ToString();
                        }
                        break;
                    case 1042:
                        {
                            msg = "Can't resolve host address.\n" + _con.ConnectionString;
                        }
                        break;
                    case 1045:
                        {
                            msg = "Invail username/password";
                        }
                        break;
                    default:
                        {
                            msg = e.ToString();
                        }
                        break;
                }
                //write to console the exception instead of program crashing
                Console.WriteLine(msg);
            }
            
        }

        void BuildConString()
        {
            //Setup string to hold ip address retrieved from folder with File IO
            string ip = "";
            //Use StreamReader to read text file containing ip address
            using (StreamReader sr = new StreamReader("c:/VFW/connect.txt"))
            {
                ip = sr.ReadLine();
            }
            //connection string with sting interpolation to input the ip address
            string conString = $"Server={ip};uid=dbsAdmin;pwd=password;database=SampleAPIData;port=8889";
            //assigning the conString to the connection string function
            _con.ConnectionString = conString;
        }

    }
}
