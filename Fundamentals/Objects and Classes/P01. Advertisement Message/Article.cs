using System.Globalization;

namespace P01._Advertisement_Message
{
    public  class Article
    {

        public Article(string titel, string content, string author)
        {
            this.Title= titel;
            this.Content= content;
            this.Author= author;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void EditContent(string newContent) 
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
