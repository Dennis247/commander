using Commander.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllAppCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 1,HowTo = "How to create api",Platform = ".net"},
                new Command{Id = 1,HowTo = "How to create api",Platform = ".net"},
                new Command{Id = 1,HowTo = "How to create api",Platform = ".net"},
                new Command{Id = 1,HowTo = "How to create api",Platform = ".net"}
            };
            return commands;
        }

        public Command GetCommnadById(int id)
        {
            return new Command { Id = 1, HowTo = "How to create api", Platform = ".net" };
        }

        public bool saveChganges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
