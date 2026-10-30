using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_BLL.Models;

namespace SmaFlaCa_BLL.Interfaces
{
    public interface IDeckService
    {
        List<Deck> GetAllDecks();
    }
}
