using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanagement

{
    internal class sevice
    {
        private readonly Repo repo = new Repo();

        // Add Student
        public bool AddStudent(model student)
        {
            List<model> students = repo.GetStudentsFromFile();
            for(int i=0; i < students.Count; i++)
            {
                if (students[i].GetRollNumber() == student.GetRollNumber())
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
           List<model>students=repo.GetStudentsFromFile();
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
            List<model>students= repo.GetStudentsFromFile();
            for (int i = 0; i < students.Count; i++) 
            {
                if (students[i].GetRollNumber() == roll)
                {
                    students[i].SetMarks(newMarks);
                    repo.SaveAllToFile(students);
                    return true;
                }

            }
            return false;
        }

        // Search By Roll Number
        public model SearchStudent(int roll)
        {
          List<model>students= repo.GetStudentsFromFile();
            foreach(model s in students)
            {
                if (s.GetRollNumber() == roll)
                {
                    return s;

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
           List<model>student= repo.GetStudentsFromFile();
            for(int i = 0; i < student.Count - 1; i++)
            {
                for(int j = 0; j < student.Count - i - 1; j++)
                {
                    if (student[j].GetMarks() < student[j + 1].GetMarks())
                    {
                        model temp= student[j];
                        student[j] = student[j + 1];
                        student[j + 1] = temp;


                    }
                }
            }
            repo.SaveAllToFile(student);
            return student;

            
        }

        // Class Average
        public float ClassAverage()
        {
           List<model>student=repo.GetStudentsFromFile();
            
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
            List <model>student=repo.GetStudentsFromFile();
            if(student==null || student.Count== 0)
            {
                return 0;
            }
            
            float highest = student[0].GetMarks();
            for(int i=1; i<student.Count; i++)
            {
                if (student[i].GetMarks() > highest)
                {
                    highest = student[i].GetMarks();
                }

               
            }
            return highest;
           

           
        }

        

        //filter 2////////


        public List<model> range(int start, int end)
        {
            List<model> students = repo.GetStudentsFromFile();
            for (int i = start; i < end; )
            {
                return students;
            }
            List<model>range=new List<model>(students); 
            return range;


        }




         //filter 3/////

        public model match(string name)
        {
            List<model> Student = repo.GetStudentsFromFile();
            foreach (model st in Student)
            {
                if (st.GetName().ToLower() == name.ToLower()) 

                return st;
            }
            return null;
        }













        // Get All Names
        public List<string> GetAllNames()
        {
            List<model> student = repo.GetStudentsFromFile();
            List<string>names= new List<string>();
            foreach(model st in student)
            {
                names.Add(st.GetName());
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
        public void UpdateAdmin(string newusername, string newpassword)
        {
            repo.SaveAdminToFile(newusername, newpassword);
        }
    }
}
