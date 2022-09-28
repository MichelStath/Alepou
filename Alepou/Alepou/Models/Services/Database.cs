using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace Alepou.Models.Services
{
    public static class Database
    {
        static SQLiteAsyncConnection _db = null;

        public static void Init()
        {
            if (_db != null)
                return;

            _db = new SQLiteAsyncConnection(
                Constants.DatabasePath,
                Constants.Flags
            );
            _db.CreateTableAsync<UserData>();
            _db.CreateTableAsync<CalendarEventData>();
            _db.CreateTableAsync<Notification>();
        }

        // =============== USER ================ //
        public static Task<int> AddUserAsync(UserData user)
        {
            return _db.InsertAsync(user);
        }

        public static Task<int> DeleteUserAsync(int id)
        {
            return _db.DeleteAsync<UserData>(id);
        }

        public static Task<UserData> GetUserAsync(int id)
        {
            return _db.Table<UserData>().Where(
                u => u.ID.Equals(id)).FirstAsync();
        }

        public static Task<UserData> GetUserAsync(string username)
        {
            return _db.Table<UserData>().Where(
                u => u.Username.Equals(username)).FirstAsync();
        }

        public static Task<UserData> GetUserFromCredentianls(string username, string password)
        {
            return _db.Table<UserData>().Where(
                u => u.Username.Equals(username)
                && u.Password.Equals(password)).FirstAsync();
        }

        public static Task<List<UserData>> GetUsersAsync()
        {
            return _db.Table<UserData>().ToListAsync();
        }

        // ========= CALENDAR EVENT ========== //
        public static Task<int> AddEventAsync(CalendarEventData cEvent)
        {
            return _db.InsertAsync(cEvent);
        }

        public static Task<int> EditEventAsync(CalendarEventData cEvent)
        {
            return _db.InsertOrReplaceAsync(cEvent);
        }

        public static Task DeleteEventAsync(int id)
        {
            return _db.DeleteAsync<CalendarEventData>(id);
        }

        public static Task<CalendarEventData> GetEventAsync(int id)
        {
            return _db.Table<CalendarEventData>().Where(
                i => i.ID.Equals(id)).FirstAsync();
        }

        public static Task<CalendarEventData> GetEventFromDataAsync(string description, DateTime date)
        {
            return _db.Table<CalendarEventData>().Where(
                i => i.Description.Equals(description) && i.Date.Equals(date)).FirstAsync();
        }

        public static Task<List<CalendarEventData>> GetUserEventsAsync(UserData user)
        {
            return _db.Table<CalendarEventData>().Where(
                i => i.Participants.Contains(user)).ToListAsync();
        }

        public static Task<List<CalendarEventData>> GetEventsAsync()
        {
            return _db.Table<CalendarEventData>().ToListAsync();
        }

        // ========== NOTIFICATION =========== //
        public static Task<int> AddNotificationAsync(Notification notification)
        {
            return _db.InsertAsync(notification);
        }

        public static Task DeletNotificationAsync(int id)
        {
            return _db.DeleteAsync<Notification>(id);
        }

        public static Task<Notification> GetNotificationAsync(int id)
        {
            return _db.Table<Notification>().Where(
                i => i.ID.Equals(id)).FirstAsync();
        }

        public static Task<List<Notification>> GetNotificationsFromUserAsync(int userID)
        {
            return _db.Table<Notification>().Where(
                i => i.UserID.Equals(userID)).ToListAsync();
        }

        public static Task<List<Notification>> GetNotificationsAsync()
        {
            return _db.Table<Notification>().ToListAsync();
        }
    }

    [Table("Users")]
    public class UserData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Unique]
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Table("Events")]
    public class CalendarEventData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        [OneToMany]
        public List<UserData> Participants { get; set; }
    }

    [Table("Notifications")]
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        [ForeignKey(typeof(UserData))]
        public int UserID { get; set; }
    }
}
