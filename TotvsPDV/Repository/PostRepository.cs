using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotvsPDV.Models;

namespace TotvsPDV.Repository
{
    public class PostRepository : IPostRepository
    {

        TotvsPDVContext db;

        public PostRepository(TotvsPDVContext _db)
        {
            db = _db;
        }

        public async Task<int> AddRegistro(RegistroCaixa registroCaixa)
        {
            if (db != null)
            {
                await db.RegistroCaixa.AddAsync(registroCaixa);
                await db.SaveChangesAsync();

                return registroCaixa.Id;
            }

            return 0;
        }
    }
}
