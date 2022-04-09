using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson_1
{
    public sealed class Post
    {
        private int _userId;
        private int _id;
        private string _title;
        private string _body;

        public int UserId
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public string Body
        {
            get
            {
                return _body;
            }

            set
            {
                _body = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(UserId.ToString());
            sb.AppendLine(Id.ToString());
            sb.AppendLine(Title);
            sb.AppendLine(Body);
            return sb.ToString();
        }
    }

    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string url = @"https://jsonplaceholder.typicode.com/posts/";
        static readonly string fileName = @"posts.txt";
        static readonly int postsCount = 10;
        static readonly int firstId = 4;

        static async Task Main(string[] args)
        {
            Task<Post>[] tasks = new Task<Post>[postsCount];

            for (int i = 0; i < postsCount; i++)
            {
                tasks[i] = GetPostAsync(firstId + i);
            }

            Task.WaitAll(tasks);

            using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
            {
                foreach (Task<Post> task in tasks)
                {
                    if (task.Result != null)
                    {
                        string text = task.Result.ToString();
                        await sw.WriteLineAsync(text);
                        Console.WriteLine(text);
                    }
                }
            }

            Console.WriteLine("All tasks has been done!!!\nPress ane key to exit.");
            Console.ReadKey();
        }

        static async Task<Post> GetPostAsync(int id)
        {
            try
            {
                string path = $"{url}{id}";
                string jsonText = await client.GetStringAsync(path);

                JsonSerializerOptions serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                Post post = JsonSerializer.Deserialize<Post>(jsonText, serializeOptions);
                Console.WriteLine($"Task with id = {id} has been done");
                return post;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with task id = {id}: {ex.Message}");
                return null;
            }
        }
    }
}
