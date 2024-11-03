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
            this.description = "��������� �����";
            this.customer = null;
            this.isCompleted = false;
        }
        public Quest(string name, string description = "��������� �����", string customer = null)
        {
            this.name = name;
            this.description = "��������� �����";
            this.customer = null;
            this.isCompleted = false;
        }

        public void CompleteQuest()
        {
            isCompleted = true;
        }
    }
}

