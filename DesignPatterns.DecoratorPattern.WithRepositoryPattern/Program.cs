Console.WriteLine("Repository");
Repository<Employee> repository = new Repository<Employee>();
repository.Get(3);
repository.GetAll();
repository.Add(new Employee());
repository.Delete(new Employee());
repository.Update(new Employee());


Console.WriteLine("\nSecurityRepositoryDecorator");
Console.WriteLine("****************");

SecurityRepositoryDecorator<Employee> securityRepositoryDecorator = new SecurityRepositoryDecorator<Employee>(repository);
securityRepositoryDecorator.Get(3);
securityRepositoryDecorator.GetAll();
securityRepositoryDecorator.Add(new Employee());
securityRepositoryDecorator.Delete(new Employee());
securityRepositoryDecorator.Update(new Employee());

Console.WriteLine("\nLoggingRepositoryDecorator");
Console.WriteLine("****************");
LoggingRepositoryDecorator<Employee> loggingRepositoryDecorator = new LoggingRepositoryDecorator<Employee>(repository);
loggingRepositoryDecorator.Get(3);
loggingRepositoryDecorator.GetAll();
loggingRepositoryDecorator.Add(new Employee());
loggingRepositoryDecorator.Delete(new Employee());
loggingRepositoryDecorator.Update(new Employee());





Console.WriteLine("\nSendCRMRepositoryDecorator");
Console.WriteLine("****************");
SendCRMRepositoryDecorator<Employee> sendCRMRepositoryDecorator = new SendCRMRepositoryDecorator<Employee>(repository);
sendCRMRepositoryDecorator.Get(3);
sendCRMRepositoryDecorator.GetAll();
sendCRMRepositoryDecorator.Add(new Employee());
sendCRMRepositoryDecorator.Delete(new Employee());
sendCRMRepositoryDecorator.Update(new Employee());



Console.WriteLine("\nSendMailRepositoryDecorator");
Console.WriteLine("****************");
SendMailRepositoryDecorator<Employee> sendMailRepositoryDecorator = new SendMailRepositoryDecorator<Employee>(repository);
sendMailRepositoryDecorator.Get(3);
sendMailRepositoryDecorator.GetAll();
sendMailRepositoryDecorator.Add(new Employee());
sendMailRepositoryDecorator.Delete(new Employee());
sendMailRepositoryDecorator.Update(new Employee());



Console.WriteLine("\nNotifyDeletionRepositoryDecorator");
Console.WriteLine("****************");

NotifyDeletionRepositoryDecorator<Employee> notifyDeletionRepositoryDecorator = new NotifyDeletionRepositoryDecorator<Employee>(repository);
notifyDeletionRepositoryDecorator.Delete(new Employee());







Console.ReadLine();





interface IRepository<T> where T : class
{
    void Add(T model);
    void Delete(T model);
    T Get(int id);
    T GetAll();
    void Update(T model);
}
class Repository<T> : IRepository<T> where T : class
{
    public T Get(int id)
    {
        Console.WriteLine("Id bazlı veri çekildi.");
        return null;
    }
    public T GetAll()
    {
        Console.WriteLine("Tüm veriler çekildi.");
        return null;
    }
    public void Add(T model)
    {
        Console.WriteLine("Model eklendi.");
    }
    public void Delete(T model)
    {
        Console.WriteLine("Model silindi.");
    }
    public void Update(T model)
    {
        Console.WriteLine("Model güncellendi.");
    }
}

class DecoratorRepository<T> : IRepository<T> where T : class
{
    readonly IRepository<T> _repository;

    public DecoratorRepository(IRepository<T> repository)
    {
        _repository = repository;
    }

    virtual public void Add(T model)
    {
        _repository.Add(model);
    }

    virtual public void Delete(T model)
    {
        _repository.Delete(model);
    }

    virtual public T Get(int id)
    {
        return _repository.Get(id);
    }

    virtual public T GetAll()
    {
        return _repository.GetAll();
    }

    virtual public void Update(T model)
    {
        _repository.Update(model);
    }
}


class SecurityRepositoryDecorator<T> : DecoratorRepository<T> where T: class
{
    // Select işleminden önce güvenlik kontrolü yapılsın ardından select işlemi gerçekleştirilsin

    readonly IRepository<T> _repository;

    public SecurityRepositoryDecorator(IRepository<T> repository) : base(repository)
    {
        _repository = repository;
    }

    public override T Get(int id)
    {
        Console.WriteLine("Güvenlik kontrolü yapılıyor.");
        return base.Get(id);
    }

    public override T GetAll()
    {
        Console.WriteLine("Güvenlik kontrolü yapılıyor.");
        return base.GetAll();
    }
}

class LoggingRepositoryDecorator<T> : DecoratorRepository<T> where T : class
{
    // Herhangi bir kayıt eklendiğinde, silindiğinde yahut güncellendiğinde işlemden sonra gerekli loglar tutulsun

    readonly IRepository<T> _repository;
    public LoggingRepositoryDecorator(IRepository<T> repository) : base(repository)
    {
        _repository= repository;
    }

    public override void Add(T model)
    {
        base.Add(model);
        Console.WriteLine($"LOG : {typeof(T).Name} eklenmiştir.");
    }

    public override void Delete(T model)
    {
        base.Delete(model);
        Console.WriteLine($"LOG : {typeof(T).Name} silinmiştir.");
    }

    public override void Update(T model)
    {
        base.Update(model);
        Console.WriteLine($"LOG : {typeof(T).Name} güncellenmiştir.");
    }


}


// Herhangi bir kayıt silindiğinde veya güncellendiğinde CRM veritabanına API’lar aracılığıyla bağlanılarak aynı değişiklikler oraya da yansıtılsın
class SendCRMRepositoryDecorator<T> : DecoratorRepository<T> where T : class
{
    readonly IRepository<T> _repository;
    public SendCRMRepositoryDecorator(IRepository<T> repository) : base(repository)
    {
        _repository = repository;
    }
    public override void Delete(T model)
    {
        base.Delete(model);
        Console.WriteLine("Kaydın silinmesi CRM veritabanına işlendi.");
    }

    public override void Update(T model)
    {
        base.Update(model);
        Console.WriteLine("Kaydın güncellenmesi CRM veritabanına işlendi.");
    }
}


// Herhangi bir kayıt güncellendiğinde kim tarafından hangi tarihte yapıldığına dair yöneticiye mail gönderilsin
class SendMailRepositoryDecorator<T> : DecoratorRepository<T> where T : class
{

    readonly IRepository<T> _repository;
    public SendMailRepositoryDecorator(IRepository<T> repository) : base(repository)
    {
        _repository = repository;
    }

    public override void Update(T model)
    {
        base.Update(model);
        Console.WriteLine($"{DateTime.Now} | Yöneticiye mail gönderildi...");

    }
}

// Kayıtlarda herhangi bir silme işlemi olduğunda kim tarafından hangi tarihte yapıldığına dair bilgilendirsin
class NotifyDeletionRepositoryDecorator<T> : DecoratorRepository<T> where T : class
{

    readonly IRepository<T> _repository;
    public NotifyDeletionRepositoryDecorator(IRepository<T> repository) : base(repository)
    {
        _repository = repository;
    }

    public override void Delete(T model)
    {
        base.Delete(model);
        Console.WriteLine($"{DateTime.Now} | {model} silindi.");
    }
}


class Employee
{
    string Name {get;set;}
}