namespace WordAssistant.Models
{
    public class Guess
    {
        public int ID { get; set; }
        public string Letter { get; set; }
        public string GreenCheck { get; set; }
        public string YellowCheck { get; set; }
        public string GreyCheck { get; set; }


        public Guess()
        {

        }
    }
}
