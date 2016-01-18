using System;

namespace BooksSample.Events
{
    public class BookInfoEvent : EventArgs
    {
        public BookInfoEvent(int bookId)
        {
            _bookId = bookId;
        }

        // TODO:  02 readonly auto property
        private readonly int _bookId;

        public int BookId
        {
            get
            {
                return _bookId;
            }
        }


    }
}
