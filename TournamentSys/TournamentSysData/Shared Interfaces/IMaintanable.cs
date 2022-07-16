using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSysLogic.Services.Interfaces
{
    public interface IMaintanable<T>
    {
        public void Create(T obj);
        public void Update(T obj);
        public void Delete(string id);
        public T GetOne(string id);
        public List<T> GetAll();
    }
}
