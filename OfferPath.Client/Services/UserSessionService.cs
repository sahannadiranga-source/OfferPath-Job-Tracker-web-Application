using OfferPath.Client.Models;

namespace OfferPath.Client.Services
{
    public class UserSessionService
    {
        public event Action? OnChange;

        private UserResponseModel? _currentUser;

        public UserResponseModel? CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                NotifyStateChanged();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;
        public bool IsRecruiter => CurrentUser?.Role == "Recruiter";

        public void Logout()
        {
            _currentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}