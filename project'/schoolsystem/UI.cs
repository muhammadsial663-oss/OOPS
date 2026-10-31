using System;
using System.Collections.Generic;

namespace schoolmanagement
{
    internal class UI
    {
      private sevice service = new sevice();

        // Main Driver
        public void Student()
        {
            while (true)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine(" SCHOOL MANAGEMENT SYSTEM");
                Console.WriteLine("==============================");

                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");

                Console.Write("Enter Choice: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    AdminMenu();
                }
                else if (option == "2")
                {
                    UserMenu();
                }
                else if (option == "3")
                {
                    Console.WriteLine("Exiting System...");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Option Selected!");
                }
            }
        }

        // Admin Menu
        public void AdminMenu()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (service.AdminLogin(username, password) == false)
            {
                Console.WriteLine("Incorrect Username or Password!");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n========== ADMIN PANEL ==========");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Update Marks");
                Console.WriteLine("5. Search By Roll Number");
                Console.WriteLine("6. Sort By Marks");
                Console.WriteLine("7. Class Average");
                Console.WriteLine("8. Total Admissions");
                Console.WriteLine("9. Delete All Data");
                Console.WriteLine("10. Main Menu");
                Console.WriteLine("11. Update Admin Password");

                Console.Write("Enter Choice: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    AddStudent();
                }
                else if (option == "2")
                {
                    ViewAllStudents();
                }
                else if (option == "3")
                {
                    DeleteStudent();
                }
                else if (option == "4")
                {
                    UpdateMarks();
                }
                else if (option == "5")
                {
                    SearchStudent();
                }
                else if (option == "6")
                {
                    ViewSortedStudents();
                }
                else if (option == "7")
                {
                    Console.WriteLine("Class Average: " + service.ClassAverage());
                }
                else if (option == "8")
                {
                    Console.WriteLine("Total Admissions: " + service.TotalAdmissions());
                }
                else if (option == "9")
                {
                    Console.Write("Enter YES to confirm: ");
                    string confirm = Console.ReadLine();

                    if (confirm == "YES")
                    {
                        service.DeleteAllData();
                        Console.WriteLine("All Data Clear!");
                    }
                    else
                    {
                        Console.WriteLine("Not Confirmed!");
                    }
                }
                else if (option == "10")
                {
                    break;
                }
                else if (option == "11")
                {
                    UpdateAdmin();
                }
                else
                {
                    Console.WriteLine("Wrong Option!");
                }
            }
        }

        // Add Student
        public void AddStudent()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            Console.Write("Enter Marks: ");
            float marks = float.Parse(Console.ReadLine());

            model student = new model(name, roll, marks);

            if (service.AddStudent(student))
            {
                Console.WriteLine("Student Added Successfully!");
            }
            else
            {
                Console.WriteLine("student not added!!");
            }
            
       
            
        }

        // View All Students
        public void ViewAllStudents()
        {
            List<model> students = service.GetAllStudents();

            DisplayStudents(students);
        }

        // Display Students
        public void DisplayStudents(List<model> students)
        {
            Console.WriteLine("\nName\tRoll Number\tMarks");

            foreach (model student in students)
            {
                Console.WriteLine(
                    student.GetName() + "\t" +
                    student.GetRollNumber() + "\t\t" +
                    student.GetMarks());
            }
        }

        // Delete Student
        public void DeleteStudent()
        {
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            if (service.DeleteStudent(roll))
            {
                Console.WriteLine("Student Deleted!");
            }
            else
            {
                Console.WriteLine("Student Not Found!");
            }
        }

        // Update Marks
        public void UpdateMarks()
        {
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            Console.Write("Enter New Marks: ");
            float marks = float.Parse(Console.ReadLine());

            if (service.UpdateMarks(roll, marks))
            {
                Console.WriteLine("Marks Updated!");
            }
            else
            {
                Console.WriteLine("Student Not Found!");
            }
        }

        // Search Student
        public void SearchStudent()
        {
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            model student = service.SearchStudent(roll);

            if (student != null)
            {
                Console.WriteLine("Name: " + student.GetName());
                Console.WriteLine("Roll Number: " + student.GetRollNumber());
                Console.WriteLine("Marks: " + student.GetMarks());
            }
            else
            {
                Console.WriteLine("Student Not Found!");
            }
        }

        // Sort Students
        public void ViewSortedStudents()
        {
            List<model> students = service.SortByMarks();

            DisplayStudents(students);
        }

        // Update Admin
        public void UpdateAdmin()
        {
            Console.Write("Enter New Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter New Password: ");
            string password = Console.ReadLine();

            service.UpdateAdmin(username, password);

            Console.WriteLine("Admin Details Updated!");
        }

        // User Menu
        public void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n========== USER PANEL ==========");
                Console.WriteLine("1. View Result");
                Console.WriteLine("2. Highest Marks");
                Console.WriteLine("3. View All Names");
                Console.WriteLine("4. Search By Name");
                Console.WriteLine("5. Main Menu");

                Console.Write("Enter Choice: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.Write("Enter Roll Number: ");
                    int roll = int.Parse(Console.ReadLine());

                    model student = service.SearchStudent(roll);

                    if (student != null)
                    {
                        Console.WriteLine("Name: " + student.GetName());
                        Console.WriteLine("Marks: " + student.GetMarks());
                    }
                    else
                    {
                        Console.WriteLine("Roll Number Not Found!");
                    }
                }
                else if (option == "2")
                {
                    Console.WriteLine("Highest Marks: " + service.HighestMarks());
                }
                else if (option == "3")
                {
                    List<string> names = service.GetAllNames();

                    foreach (string name in names)
                    {
                        Console.WriteLine(name);
                    }
                }
                else if (option == "4")
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    model student = service.SearchByName(name);

                    if (student != null)
                    {
                        Console.WriteLine("Name: " + student.GetName());
                        Console.WriteLine("Roll Number: " + student.GetRollNumber());
                        Console.WriteLine("Marks: " + student.GetMarks());
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found!");
                    }
                }
                else if (option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Option!");
                }
            }
        }
    }
}