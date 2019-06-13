using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repository
{
    public interface IHistoryRepository
    {
        void Log(string mensagem);
    }
}
