using AltınayTask.Models;

namespace AltınayTask
{
    public static class Utility
    {

        public static void LogDbWrite(int id, int value)
        {
            LogToFile($"{DateTime.Now} - Yeni kayıt eklendi (ID: {id}, Değer: {value})");
        }

        public static void LogDbUpdate(int id,  int newValue)
        {
            LogToFile($"{DateTime.Now} - Kayıt güncellendi (ID: {id}, Değer:  {newValue})");
        }

        private static void LogToFile(string message)
        {
            var logMessage = $"{DateTime.Now} - {message}\n";
            var logFilePath = "log.txt";

            File.AppendAllText(logFilePath, logMessage);
        }

        public static void MethodA(AppDbContext context, int id, int value)
        {

            JobObject job = new JobObject() { id = id, attrA = value };
            context.JobObject.Add(job);
            context.SaveChanges();

            LogDbWrite(job.id, job.attrA);
        }

    }
}
