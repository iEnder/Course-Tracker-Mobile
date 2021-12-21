using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace C971_CourseTracker
{
    public static class CourseDB
    {

        static SQLiteAsyncConnection db;

        static async Task Init()
        {

            if (db != null) return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Models.Term>();
            await db.CreateTableAsync<Models.Note>();
            await db.CreateTableAsync<Models.Course>();
            await db.CreateTableAsync<Models.Assessment>();
        }

        // *************************
        //
        // Util Functions
        //
        // *************************

        public static async void LoadSampleData()
        {
            await Init();

            var rnd = new Random();
            var statuses = new string[] { "in progress", "completed", "dropped", "plan to take" };

            var term1 = new Models.Term
            {
                title = "Winter",
                startDate = DateTime.Now.AddMonths(-3),
                endDate = DateTime.Now.AddMonths(2)
            };

            int termId = await AddTerm(term1);

            var courseTemplate = new Models.Course
            {
                instuctorName = "Seth Church",
                instuctorPhone = "123-456-7777",
                instuctorEmail = "gchurc2@example.edu",
            };

            var courseNames = new string[] { "Software I", "Software II", "Databases I", "User Experience Design", "IT Foundations", "Mobile Design I" };

            for (int i = 0; i < courseNames.Length; i++)
            {
                courseTemplate.name = courseNames[i];
                courseTemplate.startDate = DateTime.Now.AddMonths(rnd.Next(0, 24));
                courseTemplate.endDate = DateTime.Now.AddMonths(rnd.Next(0, 24));
                courseTemplate.status = statuses[rnd.Next(0, 3)];
                courseTemplate.termId = termId;

                int courseId = await AddCourse(courseTemplate);

                var coursePA = new Models.Assessment
                {
                    name = courseNames[i] + " PA",
                    type = "PA",
                    dueDate = DateTime.Now.AddMonths(rnd.Next(0, 24))
                };

                var courseOA = new Models.Assessment
                {
                    name = courseNames[i] + " OA",
                    type = "OA",
                    dueDate = DateTime.Now.AddMonths(rnd.Next(0, 24))
                };

                await AddAssessment(courseId, courseOA);
                await AddAssessment(courseId, coursePA);

                await AddNotes(courseId, new Models.Note
                {
                    content = "The FitnessGram™ Pacer Test is a multistage aerobic capacity test that progressively gets more difficult as it continues. The 20 meter pacer test will begin in 30 seconds. Line up at the start. The running speed starts slowly, but gets faster each minute after you hear this signal."
                });

                await AddNotes(courseId, new Models.Note
                {
                    content = "single lap should be completed each time you hear this sound. [ding] Remember to run in a straight line, and run as long as possible. The second time you fail to complete a lap before the sound, your test is over. The test will begin on the word start. On your mark, get ready, start."
                });
            }
        }

        // *************************
        //
        // Note Functions
        //
        // *************************

        public static async Task<int> AddNotes(int target, Models.Note data)
        {
            data.courseId = target;

            await Init();
            return await db.InsertAsync(data);
        }

        public static async Task<IEnumerable<Models.Note>> GetNotes(int target)
        {
            await Init();

            var list = await db.Table<Models.Note>().Where(tar => tar.courseId == target).ToListAsync();
            return list;
        }

        // *************************
        //
        // Assessment Functions
        //
        // *************************

        public static async Task<int> AddAssessment(int target, Models.Assessment data)
        {
            data.courseId = target;

            await Init();
            return await db.InsertAsync(data);
        }

        public static async Task<IEnumerable<Models.Assessment>> GetAssessments(int target)
        {
            await Init();

            var list = await db.Table<Models.Assessment>().Where(tar => tar.courseId == target).ToListAsync();
            return list;
        }

        // *************************
        //
        // Course Functions
        //
        // *************************

        public static async Task<int> AddCourse(Models.Course data)
        {
            await Init();
            await db.InsertAsync(data);
            return data.id;
        }

        public static async Task<IEnumerable<Models.Course>> GetCourses(int target)
        {
            await Init();

            var list = await db.Table<Models.Course>().Where(tar => tar.termId == target).ToListAsync();
            return list;
        }

        public static async Task<Models.Course> GetCourse(int target)
        {
            await Init();

            return (await db.Table<Models.Course>().Where(tar => tar.id == target).ToArrayAsync())[0];
        }

        // *************************
        //
        // Term Functions
        //
        // *************************

        public static async Task<int> AddTerm(Models.Term data)
        {
            await Init();
            await db.InsertAsync(data);
            return data.id;
        }

        public static async Task<IEnumerable<Models.Term>> GetTerms()
        {
            await Init();
            var terms = await db.Table<Models.Term>().ToListAsync();

            if (terms.Count == 0) return null;
            return terms;
        }

        // *************************
        //
        // Universal Functions
        //
        // *************************

        public static async Task<int> AddItem(Models.BaseDataModel data)
        {
            await Init();
            return await db.InsertAsync(data);
        }

        public static async Task UpdateItem(Models.BaseDataModel data)
        {
            await Init();
            await db.UpdateAsync(data);
        }

        public static async Task<int> DeleteItem(Models.BaseDataModel data)
        {
            await Init();
            return await db.DeleteAsync(data);
        }
    }
}
