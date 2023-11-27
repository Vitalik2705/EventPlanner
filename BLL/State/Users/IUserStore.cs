namespace BLL.Services.State.Users
{
    using DAL.Models;

    public interface IUserStore
    {
        User CurrentUser { get; set; }

        event Action StateChanged;
    }
}