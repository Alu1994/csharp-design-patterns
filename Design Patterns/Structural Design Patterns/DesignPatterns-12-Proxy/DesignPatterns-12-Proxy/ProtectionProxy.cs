using static System.Console;

namespace DesignPatterns_12_Proxy.Protection
{
    class ProtectionProxy
    {
        static void Main_s(string[] args)
        {
            ICar car = new CarProxy(new Driver(16));
            car.Drive();
        }
    }

    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive() => 
            WriteLine("Car is being driven");
    }

    public class CarProxy : ICar
    {
        private Driver driver;
        private Car car = new Car();

        public CarProxy(Driver driver) => 
            this.driver = driver;

        public void Drive()
        {
            if (driver.Age >= 16)
            {
                car.Drive();
                return;
            }
            WriteLine("Too Young");
        }
    }

    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age) =>
            Age = age;
    }
}
