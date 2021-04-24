# Unique Email Addresses

Email addresses consist of a `local-part` and a `domain-name` separated by the `@` symbol. In addition to `numbers` and `lowercase letters`, the `local-part` may also contain `.` or `+`.

When a `.` is placed between characters in the `local-part`, the email is delivered to the same address as if the periods were not included. For example an email sent to `first.m.last@somewhere.com` will be delivered to the same address as `firstmlast@somewhere.com`.

When a `+` is placed in the `local-part`, everything after the `+` will be ignored. This would allow for additional filtering by the recipients.

These rules only apply to the `local-part` and do not apply to the `domain-name`. The `domain-name` can consist of `lowercase characters` and the `.` symbol.

Examples:

These would all go to the same email address:

- team1@somwhere.com
- team.1+bob@somewhere.com
- team1+jill+bob@somewhere.com

Thesee would go to different addresses:

- team2@somewhere.com
- team2@some.where.com

Given a list of email addresses, return the number of unique email addresses in C#.

The method stub for this is as follows:

```csharp
public class Solution
{
    public int NumberOfUniqueEmailAddresses(string[] emails) { }
}
```
