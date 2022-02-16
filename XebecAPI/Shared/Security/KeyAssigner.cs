using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Shared.Security
{
    public class KeyAssigner
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Key { get; set; }
    }

    public class EmailModel
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string PlainText { get; set; }

        public string Htmlcontent { get; set; }
    }
}
