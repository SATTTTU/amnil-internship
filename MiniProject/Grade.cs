    public class Grade
    {
        public string Course { get; set; }
        public double Score { get; set; }

        public Grade(string course, double score)
        {
            Course = course;
            Score = score;
        }
    }