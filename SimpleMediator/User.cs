namespace SimpleMediator
{
    public class User
    {
        private readonly ChatRoom _chatRoom;

        public User(ChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public string Name { get; set; }

        public void Send(string message)
        {
            _chatRoom.ShowMessage(this, message);
        }
    }
}