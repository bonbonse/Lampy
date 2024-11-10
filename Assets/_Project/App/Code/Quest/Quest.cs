namespace Quest
{
    public class Quest 
    {
        public string name;
        public string description;
        public string customer;
        public bool isCompleted;

        public Quest(string name)
        {
            this.name = name;
            this.description = "Выполните квест";
            this.customer = null;
            this.isCompleted = false;
        }
        public Quest(string name, string description = "Выполните квест", string customer = null)
        {
            this.name = name;
            this.description = "Выполните квест";
            this.customer = null;
            this.isCompleted = false;
        }

        public void CompleteQuest()
        {
            isCompleted = true;
        }
    }
}

