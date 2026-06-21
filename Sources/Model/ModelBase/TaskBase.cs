using System.Collections.Generic;

namespace NRO_Server.Model.ModelBase
{
    public class TaskBase
    {
        public short Id { get; set; }
        public List<string> SubNames { get; set; }
        public List<short> Counts { get; set; }
        public List<string> ContentInfo { get; set; }
        public short TNSM { get; set; }
        public short Gem { get; set; }
        public short Gold { get;set; }
        public short Gender { get; set; }
        public TaskBase()
        {
            SubNames = new List<string>();
            Counts = new List<short>();
            ContentInfo = new List<string>();
            TNSM = 0;
            Gem = 0;
            Gold = 0;
            Gender = 0;
        }
    }
}