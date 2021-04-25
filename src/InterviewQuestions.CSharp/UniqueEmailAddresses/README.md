# Unique Email Addresses

Email addresses consist of a `local-part` and a `domain-name` separated by the `@` symbol.

## Local Part

In addition to `numbers` and `lowercase letters`, the `local-part` may also contain `.` or `+`.

When a `.` is placed between characters, the email is delivered to the same address as if the periods were not included. For example an email sent to `first.m.last@somewhere.com` will be delivered to the same address as `firstmlast@somewhere.com`.

When a `+` is placed in the `local-part`, everything after the `+` will be ignored. This would allow for additional filtering by the recipients.

## Domain Name

The `domain-name` can consist of `lowercase characters` and the `.` symbol.

## Examples:

These would all go to the same email address:

- team1@somewhere.com
- team.1+bob@somewhere.com
- team1+jill+bob@somewhere.com

Thesee would go to different addresses:

- team2@somewhere.com
- team2@some.where.com

## Challenge

Given a list of email addresses, return the number of unique email addresses in C#.

## Starting Point

The method stub for this is as follows:

```csharp
public class Solution
{
    public int NumberOfUniqueEmailAddresses(string[] emails) { }
}
```

## Comments

I would change the method signature to take an `IEnumerable<string>` instead of `string[]` for flexibility. I'd also make the method static as-is; but for the sake of the exercise I'm leaving it alone.

My unit tests also caught a misspelling in one of the email addresses in the original problem description. I assume that was a misstake, and corrected it.

RegEx is a handy solution for situations like this; but aren't the most performant, and can easily get out-of-hand. Just something to watch for. But this solution should do for an initial pass.

If performance is a real concern, this method could be rewritten to manually loop through and inspect each character one-by-one, using iterator methods and `StringBuilder`. This would result in a lot more code; but would minimize the number of times we loop through the characters in each string, as well as the number of strings created/destroyed in memory during the process.
