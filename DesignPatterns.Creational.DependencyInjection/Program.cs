namespace DesignPatterns.Creational.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        //BusinessLogicLayer & SqlDataAccessLayer are must be add to DI container
        Console.ReadKey();
    }

    interface IDataAccessLayer
    {
        void SaveData(string data);
    }

    class SqlDataAccessLayer : IDataAccessLayer
    {
        public void SaveData(string data)
        {
            Console.WriteLine($"Sql data access layer saved => {data}");
        }
    }

    class BusinessLogicLayer
    {
        readonly SqlDataAccessLayer _dataAccessLayer;

        public BusinessLogicLayer(SqlDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public void SaveData(string data)
        {
            _dataAccessLayer.SaveData(data);
        }
    }
}
