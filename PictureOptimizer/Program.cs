using Microsoft.Azure.WebJobs;

namespace PictureOptimizer
{
    public class Program
    {
        static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.RunAndBlock();
        }
    }
}
