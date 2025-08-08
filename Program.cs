using RabbitMQ.Client;

ConnectionFactory factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest",
    ClientProvidedName = "test",
    AutomaticRecoveryEnabled = true,
};

var initialized = false;
while (!initialized)
{
    try
    {
        IConnection conn = await factory.CreateConnectionAsync();
        initialized = true;
    }
    catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException e)
    {
        Console.WriteLine($"Error: {e}");
        await Task.Delay(5000);
    }
}
Console.WriteLine("Connected to rabbitmq");
Console.ReadKey(); // wait until we can observe connections in the management ui
