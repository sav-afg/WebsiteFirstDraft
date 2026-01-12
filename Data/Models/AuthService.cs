using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebsiteFirstDraft.Data.Models
{
    /// <summary>
    /// AuthService handles authentication-related database operations
    /// Updated to work with Entity Framework and In-Memory Database
    /// </summary>
    public class AuthService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor injection allows AppDbContext to be provided
        /// by ASP.NET Core's dependency injection system
        /// </summary>
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Attempts to log a user in by checking their credentials against the database
        /// Returns true if the username and password match a user record
        /// </summary>
        public async Task<bool> LoginAsync(string username, string password)
        {
            // Validate input to prevent null/empty username or password
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            // Find user by username using case-insensitive comparison
            var user = await _context.Users
                .FirstOrDefaultAsync(u => EF.Functions.Like(u.Username, username));

            // If user doesn't exist, login fails
            if (user == null)
            {
                return false;
            }

            // Hash the entered password and compare with stored hash
            var hashedPassword = PasswordHelper.HashPassword(password);
            return user.PasswordHash == hashedPassword;
        }

        /// <summary>
        /// Creates a new user account with the provided information
        /// Returns true if the account was successfully created, false if username already exists
        /// </summary>
        public async Task<bool> CreateAccountAsync(string username, string password, string email = "", string phoneNumber = "")
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            // Check if username already exists (case-insensitive)
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => EF.Functions.Like(u.Username, username));

            if (existingUser != null)
            {
                return false; // Username already taken
            }

            // Create new user with hashed password and default settings
            var newUser = new User
            {
                Username = username,
                PasswordHash = PasswordHelper.HashPassword(password),
                Email = email,
                Phone_Number = phoneNumber,
                Role = "User",
                Login_Streak = 0,
                Daily_Calories = 0,
                Daily_Carbs = 0,
                Daily_Protein = 0,
                Daily_Fat = 0,
                Weekly_Calories = 0,
                Weekly_Carbs = 0,
                Weekly_Protein = 0,
                Weekly_Fat = 0,
                Total_Calories = 0,
                High_Contrast_Mode = false,
                Dyslexia_Friendly_Font = false,
                Reduced_Animations = false,
                Larger_Font_Size = false,
                Visual_Rewards = true,
                Progress_Data = true,
                Minimal_Interface = false,
                Tracking_Preferences = ""
            };

            // Add user to database and save changes
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Checks if a username is already taken in the database
        /// </summary>
        public async Task<bool> UsernameExistsAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            // Check if any user exists with the given username (case-insensitive)
            return await _context.Users
                .AnyAsync(u => EF.Functions.Like(u.Username, username));
        }
    }
}

