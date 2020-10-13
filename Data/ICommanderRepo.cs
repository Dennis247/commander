using Commander.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool saveChganges();
        IEnumerable<Command> GetAllAppCommands();
        Command GetCommnadById(int id);
        void CreateCommand(Command command);

        void UpdateCommand(Command command);
    }
}
