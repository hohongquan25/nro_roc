namespace NRO_Server.Model.Info
{
    public class Test
    {
        public long DelayTest { get; set; }
        public bool IsTest { get; set; }
        public int TestCharacterId { get; set; }
        public int CheckId { get; set; }
        public int GoldTest { get; set; }
        
        public bool IsTestDisciple { get; set; }
        public int TestDiscipleId { get; set; }
        public int CheckDiscipleId { get; set; }

        public Test()
        {
            DelayTest = -1;
            IsTest = false;
            TestCharacterId = 1;
            GoldTest = 0;
            CheckId = -1;
            
            IsTestDisciple = false;
            TestDiscipleId = 1;
            CheckDiscipleId = -1;
        }
    }
}