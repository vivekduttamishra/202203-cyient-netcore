namespace HelloMVC.Data
{
    public interface IMultiplicationTableGenerator
    {
        MultiplicationTable Generate(int number, int highestMultiple = 10);
    }
}