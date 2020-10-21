using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShared
{
    public interface IShoeBUS
    {
        List<Shoe> GetAll();
        bool Delete(int code);
        List<Shoe> SearchByName(String keyword);
        Shoe GetDetails(int code);
        bool Update(Shoe newShoe);
        bool AddItem(Shoe newShoe);

    }
}
