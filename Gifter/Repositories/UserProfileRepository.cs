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
   
        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT up.Id, Up.FirebaseUserId, up.Name AS UserProfileName, up.Email, 
                               up.DateCreated, up.ImageUrl


                          FROM UserProfile up
                         WHERE FirebaseUserId = @FirebaseuserId";
                              //  p.Title, p.Caption, p.DateCreated, p.ImageUrl, p.id,
                                //     p.UserProfileId 
                         //LEFT JOIN Post  p ON up.id = p.UserProfileId

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            Name = DbUtils.GetString(reader, "UserProfileName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                        //    Post = new Post()
                          //  {
                            //    Id = DbUtils.GetInt(reader, "PostUserProfileId"),
                              //  Title = DbUtils.GetString(reader, "Title"),
                                //Caption = DbUtils.GetString(reader, "Caption"),
                             //   DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                              //  ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                              //  UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                            //},
                        };
                    }
                    reader.Close();

                    return userProfile;
                }
            }
        }
        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserProfile (FirebaseUserId, Name, Email,@)
                                        OUTPUT INSERTED.ID
                                        VALUES (@FirebaseUserId, @Name, @Email)";
                    DbUtils.AddParameter(cmd, "@FirebaseUserId", userProfile.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@Name", userProfile.Name);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                   


                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

    }

                  
}
