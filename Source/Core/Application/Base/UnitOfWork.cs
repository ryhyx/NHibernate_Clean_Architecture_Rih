using NHibernate;
using Domain.Contract.Base;
using Domain.Contract.Schema.HR;
using Application.Schema.HR;

namespace Application.Base;

public class UnitOfWork : IUnitOfWork
{

    private readonly ISessionFactory _sessionFactory;

    private readonly ITransaction _transaction;

    private readonly ISession _session;

    public UnitOfWork(ISessionFactory sessionFactory)
    {
        _sessionFactory = sessionFactory;

        _session = _sessionFactory.OpenSession();

        _transaction = _session.BeginTransaction();
    }

    private IRoleRepository _roleRepository = null!;
    private IPersonRepository _personRepository = null!;

    public IPersonRepository PersonRepository
    {
        get
        {
            _personRepository ??= new PersonRepository(_session);
            return _personRepository;
        }
    }

    public IRoleRepository RoleRepository
    {
        get
        {
            _roleRepository ??= new RoleRepository(_session);
            return _roleRepository;
        }
    }

    //Homework

    private IRoleRepository _getRoleIdRepository = null;
    private IRoleRepository _getRoleCodeRepository = null;

    private IPersonRepository _getPersonIdRepository = null;
    private IPersonRepository _getPersonCodeRepository = null;


    public IPersonRepository GetPersonById
    {
        get
        {
            _getPersonRepository ??= new PersonRepository(_id);
            return _getPersonIdRepository;
        }
    }

    public IPersonRepository GetPersonByCode
    {
        get
        {
            _getPersonRepository ??= new PersonRepository(_code);
            return _getPersonCodeRepository;
        }
    }

    public IRoleRepository GetRoleById
    {
        get
        {
            _getRoleRepository ??= new RoleRepository(_id);
            return _getRoleIdRepository;
        }
    }

    public IRoleRepository GetRoleByCode
    {
        get
        {
            _getRoleRepository ??= new RoleRepository(_code);
            return _getRoleCodeRepository;
        }
    }



    public void Commit()
    {
        if (!_transaction.IsActive)
        {
            throw new InvalidOperationException("No active transation");
        }

        _transaction.Commit();
    }

    public void Dispose()
    {
        if (_session.IsOpen)
        {
            _session.Close();
        }
    }

    public void RollBack()
    {
        if (_transaction.IsActive)
        {
            _transaction.Rollback();
        }
    }
}