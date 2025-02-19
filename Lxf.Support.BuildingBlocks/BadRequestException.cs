using System.Text;

namespace Lxf.Support.BuildingBlocks
{
    public class BadRequestException : Exception
    {
        public BadRequestException(Dictionary<string, string> args)
            : base()
        {
            Message = Msg(args);
            Args = args;
        }

        public string Message { get; }

        public Dictionary<string, string> Args { get; }

        private string Msg (Dictionary<string, string> args)
        {
            var message = new StringBuilder();

            if(args.Count == 1)
                foreach (var item in args)
                {
                    message.Append(item.Value);
                    return message.ToString();
                }

            foreach (var item in args)
            {
                message.Append($"{item.Value} ");
            }

            return message.ToString();
        }
    }
}
