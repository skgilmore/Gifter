using Gifter.Models;
using Gifter.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }
    public UserProfile GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                  SELECT p.Title, p.Caption, p.DateCreated, p.ImageUrl, p.id,
                                     p.UserProfileId,

                       up.Name, up.Bio, up.Email, up.DateCreated AS UserProfileDateCreated,
                       up.ImageUrl AS UserProfileImageUrl, up.Id AS PostUserProfileId

                            FROM UserProfile up
                             LEFT JOIN Post  p ON up.id = p.UserProfileId
                          WHERE up.id = @id";
                            // LEFT JOIN Comment c ON p.Id = c.PostId
                       //c.PostId, c.Message, c.Id as CommentId

                    DbUtils.AddParameter(cmd, "@id", id);

                    var reader = cmd.ExecuteReader();

                    UserProfile user= null;
                    if (reader.Read())
                    {
                        user = new UserProfile()
                        {
                            Id = id,
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            DateCreated = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
                            ImageUrl = DbUtils.GetString(reader, "UserProfileImageUrl"),
                            Post = new Post()
                            {
                                Id = DbUtils.GetInt(reader, "PostUserProfileId"),
                                Title = DbUtils.GetString(reader, "Title"),
                                Caption = DbUtils.GetString(reader, "Caption"),
                                DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                            },
                        };
                            /*//  Comments = new List<Comment>()

                          };

                          if (DbUtils.IsNotDbNull(reader, "CommentId"))
                          {
                              post.Comments.Add(new Comment()
                              {
                                  Id = DbUtils.GetInt(reader, "CommentId"),
                                  Message = DbUtils.GetString(reader, "Message"),
                                  // PostId = postId,
                                  //UserProfileId = DbUtils.GetInt(reader, "CommentUserProfileId")
                              });
                          } */
                        }
                    

                    reader.Close();

                    return user;
                }
            }
        }

    }
}
