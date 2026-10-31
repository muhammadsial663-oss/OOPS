using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanagement

{
    internal class sevice
    {
        private Repo repo = new Repo();

        // Add Student
        public bool AddStudent(model student)
        {
            List<model> students = repo.GetStudentsFromFile();

            if (students.Count >= 100)
            {
                return false;
            }

            foreach (model s in students)
            {
                if (s.GetRollNumber() == student.GetRollNumber())
                {
                    return false;
                }
            }

            students.Add(student);

            repo.SaveAllToFile(students);

            return true;
        }

        // View All Students
        public List<model> GetAllStudents()
        {
            return repo.GetStudentsFromFile();
        }

        // Delete Student
        public bool DeleteStudent(int roll)
        {
            List<model> students = repo.GetStudentsFromFile();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].GetRollNumber() == roll)
                {
                    students.RemoveAt(i);

                    repo.SaveAllToFile(students);

                    return true;
                }
            }

            return false;
        }

        // Update Marks
        public bool UpdateMarks(int roll, float newMarks)
        {
            List<model> students = repo.GetStudentsFromFile();

            foreach (model student in students)
            {
                if (student.GetRollNumber() == roll)
                {
                    student.SetMarks(newMarks);

                    repo.SaveAllToFile(students);

                    return true;
                }
            }

            return false;
        }

        // Search By Roll Number
        public model SearchStudent(int roll)
        {
            List<model> students = repo.GetStudentsFromFile();

            foreach (model student in students)
            {
                if (student.GetRollNumber() == roll)
                {
                    return student;
                }
            }

            return null;
        }

        // Search By Name
        public model SearchByName(string name)
        {
            List<model> students = repo.GetStudentsFromFile();

            foreach (model student in students)
            {
                if (student.GetName().ToLower() == name.ToLower())
                {
                    return student;
                }
            }

            return null;
        }

        // Sort By Marks
        public List<model> SortByMarks()
        {
            List<model> students = repo.GetStudentsFromFile();

            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - i - 1; j++)
                {
                    if (students[j].GetMarks() < students[j + 1].GetMarks())
                    {
                        model temp = students[j];

                        students[j] = students[j + 1];

                        students[j + 1] = temp;
                    }
                }
            }

            repo.SaveAllToFile(students);

            return students;
        }

        // Class Average
        public float ClassAverage()
        {
           List<model>student=repo.GetStudentsFromFile();
            if (student.Count == 0)
            {
                return 0;
            }
            float total = 0;
            for(int i = 0; i < student.Count; i++)
            {
                total = total + student[i].GetMarks();
            }
            float ave;
            ave=total/ student.Count;
           
            return ave;
        }

        // Total Admissions
        public int TotalAdmissions()
        {
            List<model> students = repo.GetStudentsFromFile();

            return students.Count;
        }

        // Delete All Data
        public void DeleteAllData()
        {
            List<model> students = new List<model>();

            repo.SaveAllToFile(students);
        }

        // Highest Marks
        public float HighestMarks()
        {
            List<model> students = repo.GetStudentsFromFile();

            if (students.Count == 0)
            {
                return 0;
            }

            float highest = students[0].GetMarks();
            for(int i = 1; i < students.Count; i++)
            {
                if (students[i].GetMarks() > highest)
                {
                    highest= students[i].GetMarks();
                }

            }
           

            return highest;
        }

        // Get All Names
        public List<string> GetAllNames()
        {
            List<model>students=repo.GetStudentsFromFile();

            List<string> names = new List<string>();

            foreach (model student in students) 
            {
                names.Add(student.GetName());           
            }

            return names;
           
        }

        // Admin Login
        public bool AdminLogin(string username, string password)
        {
            string[] admin = repo.GetAdminFromFile();

            if (username == admin[0] && password == admin[1])
            {
                return true;
            }

            return false;
        }

        // Update Admin
        public void UpdateAdmin(string username, string password)
        {
            repo.SaveAdminToFile(username, password);
        }
    }
}
