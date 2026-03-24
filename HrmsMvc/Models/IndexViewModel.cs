namespace HrmsMvc.Models
{
    public class IndexViewModel
    {
        public int sactive { get; set; }
        public int sinactive { get; set; }
        public int ecount { get; set; }
        public List<EmpDTO> Employees { get; set; }
    }
}
