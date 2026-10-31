using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanagement
{
    internal class Repo
    {
        string file = "students.txt";
        string adminFile = "admin.txt";

        //save
        public void SaveAllToFile(List<model> students)
        {
            using (StreamWriter writer = new StreamWriter(file, false))
            {
                foreach (model student in students)
                {
                    writer.WriteLine(student.ToString());
                }
            }
        }

        // Get
        public List<model> GetStudentsFromFile()
        {
            List<model> students = new List<model>();

            if (File.Exists(file))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        string name = parts[0];
                        int roll = int.Parse(parts[1]);
                        float marks = float.Parse(parts[2]);
                        model student =    new model(name, roll, marks);

                        students.Add(student);
                    }
                }
            }
            else
            {
                students.Add(new model("ali", 1, 1009));
                students.Add(new model("aminaa", 3, 1000));
                students.Add(new model("ammar", 4, 1001));
                students.Add(new model("hafsa", 5, 1054));
            }

            return students;
        }

        // Get Admin Data
        public string[] GetAdminFromFile()
        {
            if (File.Exists(adminFile))
            {
                using (StreamReader reader = new StreamReader(adminFile))
                {
                    string username = reader.ReadLine();
                    string password = reader.ReadLine();

                    return new string[] { username, password };
                }
            }

            return new string[] { "admin", "123" };
        }

        // Save Admin Data
        public void SaveAdminToFile(string username, string password)
        {
            using (StreamWriter writer = new StreamWriter(adminFile, false))
            {
                writer.WriteLine(username);
                writer.WriteLine(password);
            }
        }
    }
}
