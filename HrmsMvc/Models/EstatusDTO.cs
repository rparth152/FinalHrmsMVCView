namespace HrmsMvc.Models
{
    public class EstatusDTO
    {
        
            public int sactive { get; set; }
            public int sinactive { get; set; }
            public int ecount { get; set; }


        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
    }
}
