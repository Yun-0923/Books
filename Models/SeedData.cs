using Microsoft.EntityFrameworkCore;

namespace Homework.Models
{
    public class SeedData
    {
        //  (1)撰寫靜態方法 Initialize(IServiceProvider serviceProvider)
        // 動態方法使用時，類別需要鑄造成物件才能使用，靜態方法不用

        public static void Initialize(IServiceProvider serviceProvider)
        {
            //  (2)撰寫Book及ReBook資料表內的初始資料程式

            using (dbGuestBookContext context = new dbGuestBookContext
                (serviceProvider.GetRequiredService<DbContextOptions<dbGuestBookContext>>()))
            {
                if (!context.Book.Any())
                {
                    context.Book.AddRange(
                    new Book
                    {
                        Title = "消夜文",
                        Description = "這看起來好好吃哦!!!",
                        Photo = getFileBytes("wwwroot/SeedSourcePhoto/1.JPG"),
                        ImageType = "image/jpeg",
                        Author = "Jack",
                        TimeStamp = DateTime.Now
                    },
                    new Book
                    {
                        Title = "消夜文2",
                        Description = "好像稍微有點油....",
                        Photo = getFileBytes("wwwroot/SeedSourcePhoto/2.JPG"),
                        ImageType = "image/jpeg",
                        Author = "Mary",
                        TimeStamp = DateTime.Now
                    },
                    new Book
                    {
                        Title = "蛋餅",
                        Description = "消夜萬歲~",
                        Photo = getFileBytes("wwwroot/SeedSourcePhoto/3.jpg"),
                        ImageType = "image/jpeg",
                        Author = "王小花",
                        TimeStamp = DateTime.Now
                    },
                    new Book
                    {
                        Title = "燒烤",
                        Description = "串燒比較厲害！",
                        Photo = getFileBytes("wwwroot/SeedSourcePhoto/4.jpg"),
                        ImageType = "image/jpeg",
                        Author = "王小花",
                        TimeStamp = DateTime.Now
                    },
                    new Book
                    {
                        Title = "甜點",
                        Description = "小兔子好可愛",
                        Photo = getFileBytes("wwwroot/SeedSourcePhoto/5.jpg"),
                        ImageType = "image/jpeg",
                        Author = "Jack",
                        TimeStamp = DateTime.Now
                    });
                    context.SaveChanges();
                    context.ReBook.AddRange(
                    new ReBook
                    {
                        Description = "我覺得好吃！",
                        Author = "小蘭",
                        TimeStamp = DateTime.Now,
                        GId = 1
                    },
                    new ReBook
                    {
                        Description = "我不喜歡....",
                        Author = "柯南",
                        TimeStamp = DateTime.Now,
                        GId = 1
                    },
                    new ReBook
                    {
                        Description = "好羨慕喔..",
                        Author = "小蘭",
                        TimeStamp = DateTime.Now,
                        GId = 1
                    },
                    new ReBook
                    {
                        Description = "口水要留下來了~",
                        Author = "小英",
                        TimeStamp = DateTime.Now,
                        GId = 2
                    },
                    new ReBook
                    {
                        Description = "口味太重了吧",
                        Author = "阿狗",
                        TimeStamp = DateTime.Now,
                        GId = 3
                    },
                    new ReBook
                    {
                        Description = "我還是喜歡麻辣鍋",
                        Author = "嫩嫩",
                        TimeStamp = DateTime.Now,
                        GId = 4
                    },
                    new ReBook
                    {
                        Description = "這個不錯!!",
                        Author = "王小花",
                        TimeStamp = DateTime.Now,
                        GId = 4
                    },
                    new ReBook
                    {
                        Description = "三杯兔比較對味",
                        Author = "芷若",
                        TimeStamp = DateTime.Now,
                        GId = 5
                    });
                    context.SaveChanges();
                }
            }

            //  (3)撰寫getFileBytes，功能為將照片轉成二進位資料
            byte[] getFileBytes(string path)
            {
                FileStream file = new FileStream(path, FileMode.Open);

                byte[] filebytes;

                using (BinaryReader binaryReader = new BinaryReader(file))
                {
                    filebytes = binaryReader.ReadBytes((int)file.Length);
                }

                return filebytes;
            }

        }
    }
}
