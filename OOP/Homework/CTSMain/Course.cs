namespace CTSMain
{
    public  class Course
    {
        public Course(string name, int length)
        {
            this.Name = name;
            this.Lenght = length;
        }

        public string Name { get; set; }
        public int Lenght { get; set; }
    }
}
