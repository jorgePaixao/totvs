using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotvsPDV.Models;

namespace TotvsPDV.Repository
{
    public interface IPostRepository
    {
        Task<int> AddRegistro(RegistroCaixa registroCaixa);
    }
}
