using LabsProject.BackEnd.Domain.Commands.Contracts;

namespace LabsProject.BackEnd.Domain.Commands
{
    public class GenericCommandsResult: ICommandResult
    {
        public GenericCommandsResult() { }
        public GenericCommandsResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
