using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace schoolmanagement

{
    internal class model
    {
        private string name;
        private int rollNumber;
        private float marks;

        public model (string name, int rollNumber, float marks)
        {
            this.name = name;
            this.rollNumber = rollNumber;
            this.marks = marks;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetRollNumber()
        {
            return rollNumber;
        }

        public void SetRollNumber(int rollNumber)
        {
            this.rollNumber = rollNumber;
        }

        public float GetMarks()
        {
            return marks;
        }

        public void SetMarks(float marks)
        {
            this.marks = marks;
        }

        public override string ToString()
        {
            return name + "," + rollNumber + "," + marks;
        }
    }
}
