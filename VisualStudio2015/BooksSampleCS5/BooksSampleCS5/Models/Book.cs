using BooksSample.Framework;

namespace BooksSample.Models
{
    public class Book : BindableBase
    {
        public Book(int bookId)
        {
            BookId = bookId;
            Title = string.Empty;
            Publisher = string.Empty;
            Author = "Christian Nagel";
        }

        public int BookId { get; }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set { SetProperty(ref _publisher, value); }
        }


        public string Author { get; set; }

        // TODO: 07 - string interpolation
        public override string ToString()
        {
            return string.Format("{0}, {1}", Title, Publisher);
        }
       

    }
}
