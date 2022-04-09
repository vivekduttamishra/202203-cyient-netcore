namespace HelloMVC.Data
{
    public class Person
    {
        public Person()
        {
        }

        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Hello I am {Name}. Contact me on {Email}";
        }
    }
}