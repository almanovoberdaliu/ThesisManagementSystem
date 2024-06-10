namespace ThesisManagementSystem.Dtos
{
    public class SupervisorDto
    {
        public int SupervisorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Specializations { get; set; }
        public int AvailabilityId { get; set; }
    }
}
