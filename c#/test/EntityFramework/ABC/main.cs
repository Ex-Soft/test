#define ADDNEW
//#define UPDATE
//#define DELETE

using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                #if ADDNEW
                    Console.Write("Enter a name for a new Blog: ");
                    var name = Console.ReadLine();

                    var blog = new Blog { Name = name };
                    blog.Posts = new List<Post>(new[] { new Post { Title = "Title", Content = "Content" }  });
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                #endif

                #if UPDATE
                    var blogWithoutPost = db.Blogs.Where(b => !b.Posts.Any());

                    foreach (var blog in blogWithoutPost)
                    {
                        blog.Posts.Add(new Post { Title = string.Format("Title# {0}", blog.BlogId), Content = string.Format("Content# {0}", blog.BlogId) } );
                    }

                    var corruptedPosts = db.Blogs.SelectMany(b => b.Posts).Where(p => !p.Title.Contains("#") || !p.Content.Contains("#"));
                    foreach (var post in corruptedPosts)
                    {
                        post.Title = string.Format("Title# {0}", post.BlogId);
                        post.Content = string.Format("Content# {0}", post.BlogId);
                    }

                    db.SaveChanges();
                #endif

                #if DELETE
                    Blog victimBlog = db.Blogs.FirstOrDefault(b => b.BlogId == 3);
                    if (victimBlog != null)
                    {
                        var victimPost = victimBlog.Posts.FirstOrDefault(p => p.PostId == 3);
                        if (victimPost != null)
                        {
                            victimBlog.Posts.Remove(victimPost);
                            db.Posts.Remove(victimPost); // http://www.kianryan.co.uk/2013/03/orphaned-child/
                        }
                    }

                    victimBlog = db.Blogs.FirstOrDefault(b => b.BlogId == 1);
                    //victimBlog = new Blog { BlogId = 1 };
                    //var result = db.Blogs.Attach(victimBlog);

                    if(victimBlog!=null)
                        db.Blogs.Remove(victimBlog);

                    db.SaveChanges();
                #endif

                    var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                var r1 = db.Blogs.Where(b => b.BlogId == 3).SelectMany(b => b.Posts);
                foreach (var p in r1)
                {
                    Console.WriteLine(p.Title);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 
        }
    }
}
