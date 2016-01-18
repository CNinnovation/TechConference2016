using System;

namespace BooksSample.Events
{
    public class BookInfoEvent : EventArgs
    {
        public BookInfoEvent(int bookId)
        {
            BookId = bookId;
        }


        public int BookId { get; }
    }
}
