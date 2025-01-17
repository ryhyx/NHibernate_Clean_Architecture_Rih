﻿using Domain.Concrete.Schema.HR;
using Domain.Contract.Base;

namespace Domain.Contract.Schema.HR;

public interface IPersonRepository : IBaseRepository<Person>
{
    IPersonRepository GetPersonById(int id);
    IPersonRepository GetPersonByCode(short id);


}