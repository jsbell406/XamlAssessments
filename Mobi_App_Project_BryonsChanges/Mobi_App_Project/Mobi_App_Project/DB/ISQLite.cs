using SQLite;

namespace Mobi_App_Project.Services
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
