using System;
using System.Collections.Generic;

namespace schoolmanagement
{
    internal class UI
    {
      private sevice service = new sevice();

        // Main Driver
        public void start()
        {
            Student();
        }

        // driver code
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

                Console.Clear();


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
                Console.WriteLine("Incorrect Username or Password!!");
                return;
            }
            
            Console.Clear();
   
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
                Console.WriteLine("12. Give me the range of students :");

                Console.Write("Enter Choice: ");
                string option = Console.ReadLine();
                Console.Clear();


                if (option == "1")
                {
                    AddStudent();
                    Console.ReadKey();
                }
                else if (option == "2")
                {
                    ViewAllStudents();
                    Console.ReadKey();
                }
                else if (option == "3")
                {
                    DeleteStudent();
                    Console.ReadKey();
                }
                else if (option == "4")
                {
                    UpdateMarks();
                    Console.ReadKey();
                }
                else if (option == "5")
                {
                    SearchStudent();
                    Console.ReadKey();
                }
                else if (option == "6")
                {
                    ViewSortedStudents();
                    Console.ReadKey();
                }
                else if (option == "7")
                {
                    Console.WriteLine("Total Average :"+ service.ClassAverage());
                }
                else if (option == "8")
                {
                    Console.WriteLine("Total Admissions: " + service.TotalAdmissions());
                }
                else if (option == "9")
                {
                    Console.Write("Enter YES to Delete All: ");
                    string confirm = Console.ReadLine();
                    if (confirm == "YES")
                    {
                        service.DeleteAllData();
                        Console.WriteLine("All data is cleared ");
                    }
                    else
                    {
                        Console.WriteLine("Not confirmed Yet!!");
                    }
                   
                    
                }
                else if (option == "10")
                {
                    Console.WriteLine("Return to main manu");
                    break;
                }
                else if (option == "11")
                {
                    UpdateAdmin();

                }

                //range
                else if (option == "12")
                {
                    viewrange();
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
                Console.WriteLine("Added Sucessfully");
            }
            else
            {
                Console.WriteLine("Not Added Yet");
            }
            
       
            
        }

        // View All Students
        public void ViewAllStudents()
        {
            List<model> students = service.GetAllStudents();

            Console.WriteLine("Name \t RollNumber \t Marks");
            foreach(model student in students)
            {
                Console.WriteLine(student.GetName() +"\t\t"+ student.GetRollNumber()+"\t"+student.GetMarks() );
            }
        }

        // Display Students
        

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
            List<model>students= service.GetAllStudents();
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());
            for (int i = 0; i < students.Count; i++) 
            {
                if (students[i].GetRollNumber() == roll)
                {
                    Console.WriteLine("Name of the student : " + students[i].GetName());
                    Console.WriteLine("Previous Marks : " + students[i].GetMarks());
                }
            }
            

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

        // Search Student by roll
        public void SearchStudent()
        {
            Console.WriteLine("Enter the Roll number :");
            int roll= int.Parse(Console.ReadLine());
            List<model>students= service.GetAllStudents();
            bool found= false;
            for(int i = 0;i < students.Count; i++)
            {
                if (students[i].GetRollNumber() == roll)
                {
                    Console.WriteLine("Name of the Student is:" + students[i].GetName());
                    Console.WriteLine("Marks of the Student is: "+  students[i].GetMarks());
                    found= true;
                    break;
                }
                
            }
            if (found == false)
            {
                Console.WriteLine("Not found!");
            }

            
        }

        // Sort Students\\\\\\
        public void ViewSortedStudents()
        {
            List<model> students = service.SortByMarks();
            Console.WriteLine("Name \t RollNumber \t Marks");
            foreach (model student in students)
            {
                Console.WriteLine(student.GetName() + "\t\t" + student.GetRollNumber() + "\t" + student.GetMarks());
            }


        }
        ///range //////////

    public void viewrange()
        {
            Console.WriteLine("Enter the starting range :");
            int start= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the ending range : ");
            int end = int.Parse(Console.ReadLine());

            List<model>students= service.GetAllStudents();
            Console.WriteLine("Name\t Rollnumber \t Marks");
            for (int i = start; i < end; i++) {
                service.range(start, end);
                Console.WriteLine(students[i].GetName() + "\t" + students[i].GetRollNumber() + "\t\t" + students[i].GetMarks());
            }
            


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
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\n========== USER PANEL ==========");
                Console.WriteLine("1. View Result");
                Console.WriteLine("2. Highest Marks");
                Console.WriteLine("3. View All Names");
                Console.WriteLine("4. Search By Name :");
                Console.WriteLine("5. Main Menu");
               
                
                Console.WriteLine("6. Student you want to match Name:");

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


            //////matching  
            ///



                else if (option == "6")
                {


                    Console.WriteLine("Enter the name :");
                    string name = Console.ReadLine();
                    model student = service.match(name);
                    if (student != null)
                    {
                        Console.WriteLine("Name:" + student.GetName());
                        Console.WriteLine("Roll :" + student.GetRollNumber());
                        Console.WriteLine("Marks :" + student.GetMarks());
                    }
                    else
                    {
                        Console.WriteLine("Not found !!");
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

        /////matching 
       
    }
}