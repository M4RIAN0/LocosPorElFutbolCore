using System.Text;

namespace Lxf.Support.BuildingBlocks
{
    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException(string message, Dictionary<string,string> args) 
               : base(message)
        {
            Message = Msg(args);
            Args = args;
        }

        public string Message { get; }

        public Dictionary<string, string> Args { get; }

        private static string Msg(Dictionary<string, string> args)
        {
            if (args.Count == 1)
                return $"{args.First().Value} ya existe en un registro.";

            return $"{string.Join(", ", args.Values)} ya existen en uno o mas registros.";
        }
    }
}