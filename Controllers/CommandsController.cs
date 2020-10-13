using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dto;
using Commander.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommand()
        {
            var allCommands = _repository.GetAllAppCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(allCommands));
        }


        //Get api/commands/5
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommnadById(id);
            if (commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            return NotFound();
        }


        //Post api/command
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            //  var commandModel = _mapper.Map<CommandCreateDto, Command>(commandCreateDto);
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.saveChganges();

            CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            //   return Ok(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);

        }


        //Put api/command/{id}
        [HttpPut("{id}")]
        public ActionResult<CommandReadDto> UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandFromRepo = _repository.GetCommnadById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandFromRepo);
            _repository.UpdateCommand(commandFromRepo);
            _repository.saveChganges();
            return NoContent();

        }

        //Patch api/command/{id}
        [HttpPatch("{id}")]
        public ActionResult<CommandReadDto> PatchCommand(int id, JsonPatchDocument<CommandUpdateDto> jsonPatchDocument)
        {
            var commandFromRepo = _repository.GetCommnadById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandFromRepo);
            jsonPatchDocument.ApplyTo(commandToPatch,ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandFromRepo);
            _repository.UpdateCommand(commandFromRepo);
            _repository.saveChganges();
            return NoContent();

        }
    }
}
