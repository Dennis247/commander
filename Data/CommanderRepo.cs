using Commander.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class CommanderRepo : ICommanderRepo
    {
        public CommanderRepo(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }
        private readonly CommanderContext _commanderContext;
        public IEnumerable<Command> GetAllAppCommands()
        {
            return _commanderContext.Commands.ToList();
        }

        public Command GetCommnadById(int id)
        {
            return _commanderContext.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool saveChganges()
        {
            return _commanderContext.SaveChanges() > 1;
        }

        public void CreateCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _commanderContext.Add(command);
         
        }

        public void UpdateCommand(Command command)
        {
            _commanderContext.Update(command);

          
        }
    }
}
