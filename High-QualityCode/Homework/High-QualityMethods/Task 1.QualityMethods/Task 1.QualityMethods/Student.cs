namespace Task_1.QualityMethods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            DateTime firstDateOfBirth = this.GetDateOfBirth(this);
            DateTime secondDateOfBirth = this.GetDateOfBirth(otherStudent);

            return firstDateOfBirth < secondDateOfBirth;
        }

        private DateTime GetDateOfBirth(Student student)
        {
            return DateTime.Parse(student.OtherInfo.Substring(student.OtherInfo.Length - 10));
        }
    }
}
