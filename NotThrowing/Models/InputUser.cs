namespace NotThrowing.Models;

public class InputUser
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string GithubUsername { get; set; }

    public DateOnly DateOfBirth { get; set; }
}